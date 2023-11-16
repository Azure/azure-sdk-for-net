namespace Azure.ResourceManager.ResourceConnector
{
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
    public partial class ResourceConnectorApplianceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ResourceConnectorApplianceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro? Distro { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider? InfrastructureConfigProvider { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus? Status { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ResourceConnectorApplianceResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceClusterUserCredentialResult> GetClusterUserCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceClusterUserCredentialResult>> GetClusterUserCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceClusterUserKeysResult> GetKeys(string artifactType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceClusterUserKeysResult>> GetKeysAsync(string artifactType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph> GetUpgradeGraph(string upgradeGraph, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph>> GetUpgradeGraphAsync(string upgradeGraph, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> Update(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> UpdateAsync(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorAppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourceConnectorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource>> GetResourceConnectorApplianceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource GetResourceConnectorApplianceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceCollection GetResourceConnectorAppliances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult> GetTelemetryConfigAppliance(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>> GetTelemetryConfigApplianceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceResource> GetResourceConnectorAppliancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult> GetTelemetryConfigAppliance(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult>> GetTelemetryConfigApplianceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType left, Azure.ResourceManager.ResourceConnector.Models.AccessProfileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.AccessProfileType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType left, Azure.ResourceManager.ResourceConnector.Models.AccessProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplianceArtifactProfile
    {
        internal ApplianceArtifactProfile() { }
        public string Endpoint { get { throw null; } }
    }
    public partial class ApplianceClusterUserCredentialResult
    {
        internal ApplianceClusterUserCredentialResult() { }
        public Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig HybridConnectionConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> Kubeconfigs { get { throw null; } }
    }
    public partial class ApplianceClusterUserKeysResult
    {
        internal ApplianceClusterUserKeysResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile> ArtifactProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> Kubeconfigs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey> SshKeys { get { throw null; } }
    }
    public partial class ApplianceCredentialKubeconfig
    {
        internal ApplianceCredentialKubeconfig() { }
        public Azure.ResourceManager.ResourceConnector.Models.AccessProfileType? Name { get { throw null; } }
        public string Value { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider left, Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider left, Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplianceSshKey
    {
        internal ApplianceSshKey() { }
        public string Certificate { get { throw null; } }
        public long? CreationTimeStamp { get { throw null; } }
        public long? ExpirationTimeStamp { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
    }
    public partial class ApplianceSupportedVersion
    {
        internal ApplianceSupportedVersion() { }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion MetadataCatalogVersion { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ApplianceSupportedVersionCatalogVersion
    {
        internal ApplianceSupportedVersionCatalogVersion() { }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties Data { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
    }
    public partial class ApplianceSupportedVersionCatalogVersionProperties
    {
        internal ApplianceSupportedVersionCatalogVersionProperties() { }
        public string Audience { get { throw null; } }
        public string Catalog { get { throw null; } }
        public string Offer { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ApplianceTelemetryConfigResult
    {
        internal ApplianceTelemetryConfigResult() { }
        public string TelemetryInstrumentationKey { get { throw null; } }
    }
    public partial class ApplianceUpgradeGraph
    {
        internal ApplianceUpgradeGraph() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties Properties { get { throw null; } }
    }
    public partial class ApplianceUpgradeGraphProperties
    {
        internal ApplianceUpgradeGraphProperties() { }
        public string ApplianceVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion> SupportedVersions { get { throw null; } }
    }
    public static partial class ArmResourceConnectorModelFactory
    {
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile ApplianceArtifactProfile(string endpoint = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceClusterUserCredentialResult ApplianceClusterUserCredentialResult(Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig hybridConnectionConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceClusterUserKeysResult ApplianceClusterUserKeysResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ApplianceArtifactProfile> artifactProfiles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> kubeconfigs = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey> sshKeys = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig ApplianceCredentialKubeconfig(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType? name = default(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType?), string value = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceSshKey ApplianceSshKey(string certificate = null, long? creationTimeStamp = default(long?), long? expirationTimeStamp = default(long?), string privateKey = null, string publicKey = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion ApplianceSupportedVersion(Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion metadataCatalogVersion = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersion ApplianceSupportedVersionCatalogVersion(Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties data = null, string name = null, string @namespace = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersionCatalogVersionProperties ApplianceSupportedVersionCatalogVersionProperties(string audience = null, string catalog = null, string offer = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceTelemetryConfigResult ApplianceTelemetryConfigResult(string telemetryInstrumentationKey = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraph ApplianceUpgradeGraph(string id = null, string name = null, Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceUpgradeGraphProperties ApplianceUpgradeGraphProperties(string applianceVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceSupportedVersion> supportedVersions = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig HybridConnectionConfig(long? expirationTime = default(long?), string hybridConnectionName = null, string relay = null, string token = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ResourceConnectorApplianceData ResourceConnectorApplianceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro? distro = default(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro?), Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider? infrastructureConfigProvider = default(Azure.ResourceManager.ResourceConnector.Models.ApplianceProvider?), string provisioningState = null, string publicKey = null, Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus? status = default(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus?), string version = null) { throw null; }
    }
    public partial class HybridConnectionConfig
    {
        internal HybridConnectionConfig() { }
        public long? ExpirationTime { get { throw null; } }
        public string HybridConnectionName { get { throw null; } }
        public string Relay { get { throw null; } }
        public string Token { get { throw null; } }
    }
    public partial class ResourceConnectorAppliancePatch
    {
        public ResourceConnectorAppliancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceConnectorDistro : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceConnectorDistro(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro AksEdge { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro left, Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro left, Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorDistro right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceConnectorStatus : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceConnectorStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus Connecting { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus EtcdSnapshotFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ImageDeprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ImageDownloaded { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ImageDownloading { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ImagePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ImageProvisioned { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ImageProvisioning { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ImageUnknown { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus None { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus PostUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus PreparingForUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus PreUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus Running { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus UpdatingCapi { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus UpdatingCloudOperator { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus UpdatingCluster { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus UpgradeClusterExtensionFailedToDelete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus UpgradeComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus UpgradePrerequisitesCompleted { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus UpgradingKvaio { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus Validating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ValidatingEtcdHealth { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ValidatingImageDownload { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ValidatingImageUpload { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus ValidatingSFSConnectivity { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus WaitingForCloudOperator { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus WaitingForHeartbeat { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus WaitingForKvaio { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus left, Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus left, Azure.ResourceManager.ResourceConnector.Models.ResourceConnectorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
