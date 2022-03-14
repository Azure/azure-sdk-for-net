namespace Azure.ResourceManager.StackHCI
{
    public partial class ArcExtension : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcExtension() { }
        public virtual Azure.ResourceManager.StackHCI.ArcExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.ArcExtension> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.ArcExtension>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StackHCI.ArcExtension> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StackHCI.ArcExtensionData extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StackHCI.ArcExtension>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StackHCI.ArcExtensionData extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcExtensionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHCI.ArcExtension>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHCI.ArcExtension>, System.Collections.IEnumerable
    {
        protected ArcExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StackHCI.ArcExtension> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.StackHCI.ArcExtensionData extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StackHCI.ArcExtension>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.StackHCI.ArcExtensionData extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.ArcExtension> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StackHCI.ArcExtension> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StackHCI.ArcExtension> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.ArcExtension>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.ArcExtension> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.ArcExtension>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StackHCI.ArcExtension> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHCI.ArcExtension>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StackHCI.ArcExtension> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHCI.ArcExtension>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcExtensionData : Azure.ResourceManager.Models.ResourceData
    {
        public ArcExtensionData() { }
        public Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState? AggregateState { get { throw null; } }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StackHCI.Models.PerNodeExtensionState> PerNodeExtensionDetails { get { throw null; } }
        public object ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesExtensionParametersType { get { throw null; } set { } }
    }
    public partial class ArcSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcSetting() { }
        public virtual Azure.ResourceManager.StackHCI.ArcSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.ArcSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.ArcExtension> GetArcExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.ArcExtension>> GetArcExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StackHCI.ArcExtensionCollection GetArcExtensions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.ArcSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcSettingCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHCI.ArcSetting>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHCI.ArcSetting>, System.Collections.IEnumerable
    {
        protected ArcSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StackHCI.ArcSetting> CreateOrUpdate(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.StackHCI.ArcSettingData arcSetting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StackHCI.ArcSetting>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.StackHCI.ArcSettingData arcSetting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.ArcSetting> Get(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StackHCI.ArcSetting> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StackHCI.ArcSetting> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.ArcSetting>> GetAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.ArcSetting> GetIfExists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.ArcSetting>> GetIfExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StackHCI.ArcSetting> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHCI.ArcSetting>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StackHCI.ArcSetting> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHCI.ArcSetting>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public ArcSettingData() { }
        public Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState? AggregateState { get { throw null; } }
        public string ArcInstanceResourceGroup { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StackHCI.Models.PerNodeState> PerNodeDetails { get { throw null; } }
        public Azure.ResourceManager.StackHCI.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.StackHCI.ArcExtension GetArcExtension(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StackHCI.ArcSetting GetArcSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StackHCI.HciCluster GetHciCluster(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HciCluster : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciCluster() { }
        public virtual Azure.ResourceManager.StackHCI.HciClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.HciCluster> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.HciCluster>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.HciCluster> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.ArcSetting> GetArcSetting(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.ArcSetting>> GetArcSettingAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StackHCI.ArcSettingCollection GetArcSettings() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.HciCluster>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.HciCluster> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.HciCluster>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.HciCluster> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.HciCluster>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.HciCluster> Update(Azure.ResourceManager.StackHCI.Models.PatchableHciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.HciCluster>> UpdateAsync(Azure.ResourceManager.StackHCI.Models.PatchableHciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHCI.HciCluster>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHCI.HciCluster>, System.Collections.IEnumerable
    {
        protected HciClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StackHCI.HciCluster> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.StackHCI.HciClusterData cluster, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StackHCI.HciCluster>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.StackHCI.HciClusterData cluster, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.HciCluster> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StackHCI.HciCluster> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StackHCI.HciCluster> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.HciCluster>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHCI.HciCluster> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.HciCluster>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StackHCI.HciCluster> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHCI.HciCluster>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StackHCI.HciCluster> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHCI.HciCluster>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AadClientId { get { throw null; } set { } }
        public string AadTenantId { get { throw null; } set { } }
        public string BillingModel { get { throw null; } }
        public string CloudId { get { throw null; } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.ClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public System.DateTimeOffset? LastBillingTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        public Azure.ResourceManager.StackHCI.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RegistrationTimestamp { get { throw null; } }
        public Azure.ResourceManager.StackHCI.Models.ClusterReportedProperties ReportedProperties { get { throw null; } }
        public Azure.ResourceManager.StackHCI.Models.HciClusterStatus? Status { get { throw null; } }
        public float? TrialDaysRemaining { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StackHCI.HciCluster> GetHciCluster(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHCI.HciCluster>> GetHciClusterAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StackHCI.HciClusterCollection GetHciClusters(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.StackHCI.HciCluster> GetHciClusters(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StackHCI.HciCluster> GetHciClustersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StackHCI.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSettingAggregateState : System.IEquatable<Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSettingAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState left, Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState left, Azure.ResourceManager.StackHCI.Models.ArcSettingAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterDesiredProperties
    {
        public ClusterDesiredProperties() { }
        public Azure.ResourceManager.StackHCI.Models.DiagnosticLevel? DiagnosticLevel { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } set { } }
    }
    public partial class ClusterNode
    {
        internal ClusterNode() { }
        public float? CoreCount { get { throw null; } }
        public float? Id { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public float? MemoryInGiB { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } }
        public string OsName { get { throw null; } }
        public string OsVersion { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } }
    }
    public partial class ClusterReportedProperties
    {
        internal ClusterReportedProperties() { }
        public string ClusterId { get { throw null; } }
        public string ClusterName { get { throw null; } }
        public string ClusterVersion { get { throw null; } }
        public Azure.ResourceManager.StackHCI.Models.DiagnosticLevel? DiagnosticLevel { get { throw null; } }
        public Azure.ResourceManager.StackHCI.Models.ImdsAttestation? ImdsAttestation { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StackHCI.Models.ClusterNode> Nodes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.StackHCI.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.CreatedByType left, Azure.ResourceManager.StackHCI.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.CreatedByType left, Azure.ResourceManager.StackHCI.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiagnosticLevel : System.IEquatable<Azure.ResourceManager.StackHCI.Models.DiagnosticLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnosticLevel(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.DiagnosticLevel Basic { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.DiagnosticLevel Enhanced { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.DiagnosticLevel Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.DiagnosticLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.DiagnosticLevel left, Azure.ResourceManager.StackHCI.Models.DiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.DiagnosticLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.DiagnosticLevel left, Azure.ResourceManager.StackHCI.Models.DiagnosticLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionAggregateState : System.IEquatable<Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState left, Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState left, Azure.ResourceManager.StackHCI.Models.ExtensionAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterStatus : System.IEquatable<Azure.ResourceManager.StackHCI.Models.HciClusterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterStatus(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.HciClusterStatus ConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.HciClusterStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.HciClusterStatus Error { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.HciClusterStatus NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.HciClusterStatus NotYetRegistered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.HciClusterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.HciClusterStatus left, Azure.ResourceManager.StackHCI.Models.HciClusterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.HciClusterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.HciClusterStatus left, Azure.ResourceManager.StackHCI.Models.HciClusterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImdsAttestation : System.IEquatable<Azure.ResourceManager.StackHCI.Models.ImdsAttestation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImdsAttestation(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.ImdsAttestation Disabled { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ImdsAttestation Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.ImdsAttestation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.ImdsAttestation left, Azure.ResourceManager.StackHCI.Models.ImdsAttestation right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.ImdsAttestation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.ImdsAttestation left, Azure.ResourceManager.StackHCI.Models.ImdsAttestation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeArcState : System.IEquatable<Azure.ResourceManager.StackHCI.Models.NodeArcState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeArcState(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Connected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Creating { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Deleted { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Error { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Moving { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeArcState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.NodeArcState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.NodeArcState left, Azure.ResourceManager.StackHCI.Models.NodeArcState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.NodeArcState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.NodeArcState left, Azure.ResourceManager.StackHCI.Models.NodeArcState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeExtensionState : System.IEquatable<Azure.ResourceManager.StackHCI.Models.NodeExtensionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeExtensionState(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Connected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Creating { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Error { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Moving { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.NodeExtensionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.NodeExtensionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.NodeExtensionState left, Azure.ResourceManager.StackHCI.Models.NodeExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.NodeExtensionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.NodeExtensionState left, Azure.ResourceManager.StackHCI.Models.NodeExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatchableHciClusterData
    {
        public PatchableHciClusterData() { }
        public string AadClientId { get { throw null; } set { } }
        public string AadTenantId { get { throw null; } set { } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.StackHCI.Models.ClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PerNodeExtensionState
    {
        internal PerNodeExtensionState() { }
        public string Extension { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.StackHCI.Models.NodeExtensionState? State { get { throw null; } }
    }
    public partial class PerNodeState
    {
        internal PerNodeState() { }
        public string ArcInstance { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.StackHCI.Models.NodeArcState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.StackHCI.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.ProvisioningState left, Azure.ResourceManager.StackHCI.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.ProvisioningState left, Azure.ResourceManager.StackHCI.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsServerSubscription : System.IEquatable<Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsServerSubscription(string value) { throw null; }
        public static Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription Disabled { get { throw null; } }
        public static Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription left, Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription left, Azure.ResourceManager.StackHCI.Models.WindowsServerSubscription right) { throw null; }
        public override string ToString() { throw null; }
    }
}
