namespace Azure.ResourceManager.ResourceConnector
{
    public partial class ApplianceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceConnector.ApplianceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.ApplianceResource>, System.Collections.IEnumerable
    {
        protected ApplianceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceConnector.ApplianceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ResourceConnector.ApplianceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceConnector.ApplianceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ResourceConnector.ApplianceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceConnector.ApplianceResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceConnector.ApplianceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceConnector.ApplianceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceConnector.ApplianceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.ApplianceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplianceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ApplianceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ApplianceData>
    {
        public ApplianceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ResourceConnector.Models.Distro? Distro { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.Event> Events { get { throw null; } }
        public Azure.ResourceManager.ResourceConnector.Models.Identity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.Provider? InfrastructureConfigProvider { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.Status? Status { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.ApplianceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.ApplianceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ApplianceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ApplianceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplianceResource() { }
        public virtual Azure.ResourceManager.ResourceConnector.ApplianceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults> GetClusterUserCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults>> GetClusterUserCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults> GetKeys(string artifactType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults>> GetKeysAsync(string artifactType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph> GetUpgradeGraph(string upgradeGraph, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph>> GetUpgradeGraphAsync(string upgradeGraph, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResourceConnector.ApplianceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.ApplianceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.ApplianceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> Update(Azure.ResourceManager.ResourceConnector.Models.AppliancePatch appliancePatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> UpdateAsync(Azure.ResourceManager.ResourceConnector.Models.AppliancePatch appliancePatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerResourceConnectorContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourceConnectorContext() { }
        public static Azure.ResourceManager.ResourceConnector.AzureResourceManagerResourceConnectorContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ResourceConnectorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAppliance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> GetApplianceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ApplianceResource GetApplianceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ApplianceCollection GetAppliances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAppliances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAppliancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult> GetTelemetryConfig(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>> GetTelemetryConfigAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceConnector.Mocking
{
    public partial class MockableResourceConnectorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceConnectorArmClient() { }
        public virtual Azure.ResourceManager.ResourceConnector.ApplianceResource GetApplianceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourceConnectorResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceConnectorResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAppliance(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> GetApplianceAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceConnector.ApplianceCollection GetAppliances() { throw null; }
    }
    public partial class MockableResourceConnectorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceConnectorSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAppliances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAppliancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult> GetTelemetryConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>> GetTelemetryConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ApplianceGetTelemetryConfigResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>
    {
        internal ApplianceGetTelemetryConfigResult() { }
        public string TelemetryInstrumentationKey { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceListCredentialResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults>
    {
        internal ApplianceListCredentialResults() { }
        public Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig HybridConnectionConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> Kubeconfigs { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplianceListKeysResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults>
    {
        internal ApplianceListKeysResults() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile> ArtifactProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> Kubeconfigs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.SSHKey> SshKeys { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppliancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.AppliancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.AppliancePatch>
    {
        public AppliancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.AppliancePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.AppliancePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.AppliancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.AppliancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.AppliancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.AppliancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.AppliancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.AppliancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.AppliancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourceConnectorModelFactory
    {
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig ApplianceCredentialKubeconfig(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType? name = default(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType?), string value = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ApplianceData ApplianceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ResourceConnector.Models.Distro? distro = default(Azure.ResourceManager.ResourceConnector.Models.Distro?), string provisioningState = null, string publicKey = null, Azure.ResourceManager.ResourceConnector.Models.Status? status = default(Azure.ResourceManager.ResourceConnector.Models.Status?), string version = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.Event> events = null, Azure.ResourceManager.ResourceConnector.Models.NetworkProfile networkProfile = null, Azure.ResourceManager.ResourceConnector.Models.Provider? infrastructureConfigProvider = default(Azure.ResourceManager.ResourceConnector.Models.Provider?), Azure.ResourceManager.ResourceConnector.Models.Identity identity = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult ApplianceGetTelemetryConfigResult(string telemetryInstrumentationKey = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults ApplianceListCredentialResults(Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig hybridConnectionConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults ApplianceListKeysResults(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile> artifactProfiles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> kubeconfigs = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.SSHKey> sshKeys = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.AppliancePatch AppliancePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile ArtifactProfile(string endpoint = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.Event Event(string type = null, string code = null, string status = null, string message = null, string severity = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig HybridConnectionConfig(long? expirationTime = default(long?), string hybridConnectionName = null, string relay = null, string token = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.Identity Identity(string principalId = null, string tenantId = null, Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType? type = default(Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType?)) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.SSHKey SSHKey(string certificate = null, long? creationTimeStamp = default(long?), long? expirationTimeStamp = default(long?), string privateKey = null, string publicKey = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.SupportedVersion SupportedVersion(Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion metadataCatalogVersion = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion SupportedVersionCatalogVersion(Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField data = null, string name = null, string @namespace = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField SupportedVersionCatalogVersionDataField(string audience = null, string catalog = null, string offer = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph UpgradeGraph(string id = null, string name = null, Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties UpgradeGraphProperties(string applianceVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion> supportedVersions = null) { throw null; }
    }
    public partial class ArtifactProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile>
    {
        internal ArtifactProfile() { }
        public string Endpoint { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Distro : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.Distro>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Distro(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.Distro AKSEdge { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.Distro other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.Distro left, Azure.ResourceManager.ResourceConnector.Models.Distro right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.Distro (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.Distro? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.Distro left, Azure.ResourceManager.ResourceConnector.Models.Distro right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Event : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.Event>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.Event>
    {
        internal Event() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Severity { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.Event JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.Event PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.Event System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.Event>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.Event>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.Event System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.Event>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.Event>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.Event>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class Identity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.Identity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.Identity>
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.Identity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.Identity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.Identity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.Identity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.Identity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.Identity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.Identity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.Identity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.Identity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.NetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.NetworkProfile>
    {
        public NetworkProfile() { }
        public string DnsVersion { get { throw null; } set { } }
        public string GatewayVersion { get { throw null; } set { } }
        public string ProxyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.NetworkProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.NetworkProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.NetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.NetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.NetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.NetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.NetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.NetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.NetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Provider : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.Provider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Provider(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.Provider HCI { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Provider SCVMM { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Provider VMWare { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.Provider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.Provider left, Azure.ResourceManager.ResourceConnector.Models.Provider right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.Provider (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.Provider? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.Provider left, Azure.ResourceManager.ResourceConnector.Models.Provider right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceIdentityType : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType left, Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType left, Azure.ResourceManager.ResourceConnector.Models.ResourceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SSHKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SSHKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SSHKey>
    {
        internal SSHKey() { }
        public string Certificate { get { throw null; } }
        public long? CreationTimeStamp { get { throw null; } }
        public long? ExpirationTimeStamp { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.SSHKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.SSHKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.SSHKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SSHKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SSHKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.SSHKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SSHKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SSHKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SSHKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ArcGatewayUpdateComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ArcGatewayUpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ArcGatewayUpdatePreparing { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ArcGatewayUpdating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Connected { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Connecting { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ETCDSnapshotFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageDeprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageDownloaded { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageDownloading { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImagePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageProvisioned { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageProvisioning { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageUnknown { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status NetworkDNSUpdateComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status NetworkDNSUpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status NetworkDNSUpdatePreparing { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status NetworkDNSUpdating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status NetworkProxyUpdateComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status NetworkProxyUpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status NetworkProxyUpdatePreparing { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status NetworkProxyUpdating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status None { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Offline { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status PostUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status PreparingForUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status PreUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Running { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpdatingCAPI { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpdatingCloudOperator { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpdatingCluster { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradeClusterExtensionFailedToDelete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradeComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradePrerequisitesCompleted { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradingKVAIO { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Validating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ValidatingETCDHealth { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ValidatingImageDownload { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ValidatingImageUpload { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ValidatingSFSConnectivity { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status WaitingForCloudOperator { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status WaitingForHeartbeat { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status WaitingForKVAIO { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.Status other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.Status left, Azure.ResourceManager.ResourceConnector.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.Status (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.Status? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.Status left, Azure.ResourceManager.ResourceConnector.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportedVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion>
    {
        internal SupportedVersion() { }
        public Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion MetadataCatalogVersion { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.SupportedVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.SupportedVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.SupportedVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.SupportedVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedVersionCatalogVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion>
    {
        internal SupportedVersionCatalogVersion() { }
        public Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField Data { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedVersionCatalogVersionDataField : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField>
    {
        internal SupportedVersionCatalogVersionDataField() { }
        public string Audience { get { throw null; } }
        public string Catalog { get { throw null; } }
        public string Offer { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionDataField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeGraph : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph>
    {
        internal UpgradeGraph() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeGraphProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties>
    {
        internal UpgradeGraphProperties() { }
        public string ApplianceVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion> SupportedVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
