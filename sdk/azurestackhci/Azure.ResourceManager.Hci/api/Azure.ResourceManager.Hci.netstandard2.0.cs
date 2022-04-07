namespace Azure.ResourceManager.Hci
{
    public partial class ArcExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>, System.Collections.IEnumerable
    {
        protected ArcExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ArcExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ArcExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ArcExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ArcExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcExtensionData : Azure.ResourceManager.Models.ResourceData
    {
        public ArcExtensionData() { }
        public Azure.ResourceManager.Hci.Models.ExtensionAggregateState? AggregateState { get { throw null; } }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> PerNodeExtensionDetails { get { throw null; } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesExtensionParametersType { get { throw null; } set { } }
    }
    public partial class ArcExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcExtensionResource() { }
        public virtual Azure.ResourceManager.Hci.ArcExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>, System.Collections.IEnumerable
    {
        protected ArcSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.Hci.ArcSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.Hci.ArcSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Get(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ArcSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ArcSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ArcSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ArcSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public ArcSettingData() { }
        public Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? AggregateState { get { throw null; } }
        public string ArcInstanceResourceGroup { get { throw null; } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeState> PerNodeDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ArcSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcSettingResource() { }
        public virtual Azure.ResourceManager.Hci.ArcSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> GetArcExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetArcExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcExtensionCollection GetArcExtensions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterResource>, System.Collections.IEnumerable
    {
        protected HciClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.HciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.HciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string BillingModel { get { throw null; } }
        public System.Guid? CloudId { get { throw null; } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public System.DateTimeOffset? LastBillingTimestamp { get { throw null; } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RegistrationTimestamp { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ClusterReportedProperties ReportedProperties { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        public float? TrialDaysRemaining { get { throw null; } }
    }
    public partial class HciClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> GetArcSetting(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetArcSettingAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcSettingCollection GetArcSettings() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Update(Azure.ResourceManager.Hci.Models.HciClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> UpdateAsync(Azure.ResourceManager.Hci.Models.HciClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HciExtensions
    {
        public static Azure.ResourceManager.Hci.ArcExtensionResource GetArcExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingResource GetArcSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> GetHciCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetHciClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterResource GetHciClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterCollection GetHciClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSettingAggregateState : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcSettingAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSettingAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcSettingAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterDesiredProperties
    {
        public ClusterDesiredProperties() { }
        public Azure.ResourceManager.Hci.Models.DiagnosticLevel? DiagnosticLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } set { } }
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
        public string OSName { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } }
    }
    public partial class ClusterReportedProperties
    {
        internal ClusterReportedProperties() { }
        public System.Guid? ClusterId { get { throw null; } }
        public string ClusterName { get { throw null; } }
        public string ClusterVersion { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.DiagnosticLevel? DiagnosticLevel { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ImdsAttestation? ImdsAttestation { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.ClusterNode> Nodes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.Hci.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.CreatedByType left, Azure.ResourceManager.Hci.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.CreatedByType left, Azure.ResourceManager.Hci.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiagnosticLevel : System.IEquatable<Azure.ResourceManager.Hci.Models.DiagnosticLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnosticLevel(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DiagnosticLevel Basic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DiagnosticLevel Enhanced { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.DiagnosticLevel Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.DiagnosticLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.DiagnosticLevel left, Azure.ResourceManager.Hci.Models.DiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.DiagnosticLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.DiagnosticLevel left, Azure.ResourceManager.Hci.Models.DiagnosticLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionAggregateState : System.IEquatable<Azure.ResourceManager.Hci.Models.ExtensionAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionAggregateState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ExtensionAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ExtensionAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ExtensionAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ExtensionAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterPatch
    {
        public HciClusterPatch() { }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotYetRegistered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImdsAttestation : System.IEquatable<Azure.ResourceManager.Hci.Models.ImdsAttestation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImdsAttestation(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestation Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestation Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ImdsAttestation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ImdsAttestation left, Azure.ResourceManager.Hci.Models.ImdsAttestation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ImdsAttestation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ImdsAttestation left, Azure.ResourceManager.Hci.Models.ImdsAttestation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeArcState : System.IEquatable<Azure.ResourceManager.Hci.Models.NodeArcState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeArcState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.NodeArcState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeArcState left, Azure.ResourceManager.Hci.Models.NodeArcState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeArcState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.NodeArcState left, Azure.ResourceManager.Hci.Models.NodeArcState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeExtensionState : System.IEquatable<Azure.ResourceManager.Hci.Models.NodeExtensionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeExtensionState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.NodeExtensionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeExtensionState left, Azure.ResourceManager.Hci.Models.NodeExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeExtensionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.NodeExtensionState left, Azure.ResourceManager.Hci.Models.NodeExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PerNodeExtensionState
    {
        internal PerNodeExtensionState() { }
        public string Extension { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeExtensionState? State { get { throw null; } }
    }
    public partial class PerNodeState
    {
        internal PerNodeState() { }
        public string ArcInstance { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeArcState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Hci.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ProvisioningState left, Azure.ResourceManager.Hci.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ProvisioningState left, Azure.ResourceManager.Hci.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsServerSubscription : System.IEquatable<Azure.ResourceManager.Hci.Models.WindowsServerSubscription>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsServerSubscription(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.WindowsServerSubscription Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.WindowsServerSubscription Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.WindowsServerSubscription other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.WindowsServerSubscription (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public override string ToString() { throw null; }
    }
}
