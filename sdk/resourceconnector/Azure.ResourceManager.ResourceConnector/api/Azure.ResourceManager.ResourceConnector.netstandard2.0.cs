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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceConnector.ApplianceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceConnector.ApplianceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceConnector.ApplianceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.ApplianceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplianceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplianceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ResourceConnector.Models.Distro? Distro { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.Provider? InfrastructureConfigProvider { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceConnector.Models.Status? Status { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ApplianceResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> Update(Azure.ResourceManager.ResourceConnector.Models.AppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> UpdateAsync(Azure.ResourceManager.ResourceConnector.Models.AppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourceConnectorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAppliance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.ApplianceResource>> GetApplianceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ApplianceResource GetApplianceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ApplianceCollection GetAppliances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAppliances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.ApplianceResource> GetAppliancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceConnector.Models.ApplianceOperation> GetOperationsAppliances(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceConnector.Models.ApplianceOperation> GetOperationsAppliancesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult> GetTelemetryConfigAppliance(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult>> GetTelemetryConfigApplianceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ApplianceCredentialKubeconfig
    {
        internal ApplianceCredentialKubeconfig() { }
        public Azure.ResourceManager.ResourceConnector.Models.AccessProfileType? Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ApplianceGetTelemetryConfigResult
    {
        internal ApplianceGetTelemetryConfigResult() { }
        public string TelemetryInstrumentationKey { get { throw null; } }
    }
    public partial class ApplianceListCredentialResults
    {
        internal ApplianceListCredentialResults() { }
        public Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig HybridConnectionConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> Kubeconfigs { get { throw null; } }
    }
    public partial class ApplianceListKeysResults
    {
        internal ApplianceListKeysResults() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile> ArtifactProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> Kubeconfigs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.SSHKey> SshKeys { get { throw null; } }
    }
    public partial class ApplianceOperation
    {
        internal ApplianceOperation() { }
        public string Description { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Origin { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class AppliancePatch
    {
        public AppliancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public static partial class ArmResourceConnectorModelFactory
    {
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig ApplianceCredentialKubeconfig(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType? name = default(Azure.ResourceManager.ResourceConnector.Models.AccessProfileType?), string value = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.ApplianceData ApplianceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ResourceConnector.Models.Distro? distro = default(Azure.ResourceManager.ResourceConnector.Models.Distro?), Azure.ResourceManager.ResourceConnector.Models.Provider? infrastructureConfigProvider = default(Azure.ResourceManager.ResourceConnector.Models.Provider?), string provisioningState = null, string publicKey = null, Azure.ResourceManager.ResourceConnector.Models.Status? status = default(Azure.ResourceManager.ResourceConnector.Models.Status?), string version = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceGetTelemetryConfigResult ApplianceGetTelemetryConfigResult(string telemetryInstrumentationKey = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceListCredentialResults ApplianceListCredentialResults(Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig hybridConnectionConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceListKeysResults ApplianceListKeysResults(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile> artifactProfiles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.ApplianceCredentialKubeconfig> kubeconfigs = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.ResourceConnector.Models.SSHKey> sshKeys = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ApplianceOperation ApplianceOperation(bool? isDataAction = default(bool?), string name = null, string origin = null, string description = null, string operation = null, string provider = null, string resource = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.ArtifactProfile ArtifactProfile(string endpoint = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.HybridConnectionConfig HybridConnectionConfig(long? expirationTime = default(long?), string hybridConnectionName = null, string relay = null, string token = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.SSHKey SSHKey(string certificate = null, long? creationTimeStamp = default(long?), long? expirationTimeStamp = default(long?), string privateKey = null, string publicKey = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.SupportedVersion SupportedVersion(Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion metadataCatalogVersion = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion SupportedVersionCatalogVersion(Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionData data = null, string name = null, string @namespace = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionData SupportedVersionCatalogVersionData(string audience = null, string catalog = null, string offer = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.UpgradeGraph UpgradeGraph(string id = null, string name = null, Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties UpgradeGraphProperties(string applianceVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion> supportedVersions = null) { throw null; }
    }
    public partial class ArtifactProfile
    {
        internal ArtifactProfile() { }
        public string Endpoint { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Distro : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.Distro>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Distro(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.Distro AKSEdge { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.Distro other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.Distro left, Azure.ResourceManager.ResourceConnector.Models.Distro right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.Distro (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.Distro left, Azure.ResourceManager.ResourceConnector.Models.Distro right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridConnectionConfig
    {
        internal HybridConnectionConfig() { }
        public long? ExpirationTime { get { throw null; } }
        public string HybridConnectionName { get { throw null; } }
        public string Relay { get { throw null; } }
        public string Token { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Provider : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.Provider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Provider(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.Provider HCI { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Provider Scvmm { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Provider VmWare { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.Provider other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.Provider left, Azure.ResourceManager.ResourceConnector.Models.Provider right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.Provider (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.Provider left, Azure.ResourceManager.ResourceConnector.Models.Provider right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SSHKey
    {
        internal SSHKey() { }
        public string Certificate { get { throw null; } }
        public long? CreationTimeStamp { get { throw null; } }
        public long? ExpirationTimeStamp { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.ResourceConnector.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Connected { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Connecting { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status EtcdSnapshotFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageDeprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageDownloaded { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageDownloading { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImagePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageProvisioned { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageProvisioning { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ImageUnknown { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status None { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Offline { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status PostUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status PreparingForUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status PreUpgrade { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Running { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpdatingCapi { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpdatingCloudOperator { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpdatingCluster { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradeClusterExtensionFailedToDelete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradeComplete { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradePrerequisitesCompleted { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status UpgradingKvaio { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status Validating { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ValidatingEtcdHealth { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ValidatingImageDownload { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ValidatingImageUpload { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status ValidatingSFSConnectivity { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status WaitingForCloudOperator { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status WaitingForHeartbeat { get { throw null; } }
        public static Azure.ResourceManager.ResourceConnector.Models.Status WaitingForKvaio { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceConnector.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceConnector.Models.Status left, Azure.ResourceManager.ResourceConnector.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceConnector.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceConnector.Models.Status left, Azure.ResourceManager.ResourceConnector.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportedVersion
    {
        internal SupportedVersion() { }
        public Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersion MetadataCatalogVersion { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class SupportedVersionCatalogVersion
    {
        internal SupportedVersionCatalogVersion() { }
        public Azure.ResourceManager.ResourceConnector.Models.SupportedVersionCatalogVersionData Data { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
    }
    public partial class SupportedVersionCatalogVersionData
    {
        internal SupportedVersionCatalogVersionData() { }
        public string Audience { get { throw null; } }
        public string Catalog { get { throw null; } }
        public string Offer { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class UpgradeGraph
    {
        internal UpgradeGraph() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ResourceConnector.Models.UpgradeGraphProperties Properties { get { throw null; } }
    }
    public partial class UpgradeGraphProperties
    {
        internal UpgradeGraphProperties() { }
        public string ApplianceVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceConnector.Models.SupportedVersion> SupportedVersions { get { throw null; } }
    }
}
