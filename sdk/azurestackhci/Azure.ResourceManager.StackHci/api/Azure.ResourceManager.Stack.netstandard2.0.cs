namespace Azure.ResourceManager.StackHci
{
    public partial class ArcExtension : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcExtension() { }
        public virtual Azure.ResourceManager.StackHci.ArcExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.StackHci.Models.ArcExtensionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StackHci.Models.ArcExtensionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.ArcExtension> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.ArcExtension>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StackHci.Models.ArcExtensionUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.StackHci.ArcExtensionData extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StackHci.Models.ArcExtensionUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.StackHci.ArcExtensionData extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcExtensionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHci.ArcExtension>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHci.ArcExtension>, System.Collections.IEnumerable
    {
        protected ArcExtensionCollection() { }
        public virtual Azure.ResourceManager.StackHci.Models.ArcExtensionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string extensionName, Azure.ResourceManager.StackHci.ArcExtensionData extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StackHci.Models.ArcExtensionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string extensionName, Azure.ResourceManager.StackHci.ArcExtensionData extension, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.ArcExtension> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StackHci.ArcExtension> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StackHci.ArcExtension> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.ArcExtension>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.ArcExtension> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.ArcExtension>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StackHci.ArcExtension> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHci.ArcExtension>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StackHci.ArcExtension> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHci.ArcExtension>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcExtensionData : Azure.ResourceManager.Models.Resource
    {
        public ArcExtensionData() { }
        public Azure.ResourceManager.StackHci.Models.ExtensionAggregateState? AggregateState { get { throw null; } }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StackHci.Models.PerNodeExtensionState> PerNodeExtensionDetails { get { throw null; } }
        public object ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesExtensionParametersType { get { throw null; } set { } }
    }
    public partial class ArcSetting : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcSetting() { }
        public virtual Azure.ResourceManager.StackHci.ArcSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName) { throw null; }
        public virtual Azure.ResourceManager.StackHci.Models.ArcSettingDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StackHci.Models.ArcSettingDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.ArcSetting> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StackHci.ArcExtensionCollection GetArcExtensions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.ArcSetting>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcSettingCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHci.ArcSetting>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHci.ArcSetting>, System.Collections.IEnumerable
    {
        protected ArcSettingCollection() { }
        public virtual Azure.ResourceManager.StackHci.Models.ArcSettingCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string arcSettingName, Azure.ResourceManager.StackHci.ArcSettingData arcSetting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StackHci.Models.ArcSettingCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string arcSettingName, Azure.ResourceManager.StackHci.ArcSettingData arcSetting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.ArcSetting> Get(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StackHci.ArcSetting> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StackHci.ArcSetting> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.ArcSetting>> GetAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.ArcSetting> GetIfExists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.ArcSetting>> GetIfExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StackHci.ArcSetting> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHci.ArcSetting>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StackHci.ArcSetting> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHci.ArcSetting>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcSettingData : Azure.ResourceManager.Models.Resource
    {
        public ArcSettingData() { }
        public Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState? AggregateState { get { throw null; } }
        public string ArcInstanceResourceGroup { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StackHci.Models.PerNodeState> PerNodeDetails { get { throw null; } }
        public Azure.ResourceManager.StackHci.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.StackHci.ArcExtension GetArcExtension(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StackHci.ArcSetting GetArcSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StackHci.HciCluster GetHciCluster(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HciCluster : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciCluster() { }
        public virtual Azure.ResourceManager.StackHci.HciClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.HciCluster> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.HciCluster>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.StackHci.Models.HciClusterDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StackHci.Models.HciClusterDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.HciCluster> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StackHci.ArcSettingCollection GetArcSettings() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.HciCluster>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.HciCluster> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.HciCluster>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.HciCluster> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.HciCluster>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.HciCluster> Update(Azure.ResourceManager.StackHci.Models.ClusterPatch cluster, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.HciCluster>> UpdateAsync(Azure.ResourceManager.StackHci.Models.ClusterPatch cluster, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHci.HciCluster>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHci.HciCluster>, System.Collections.IEnumerable
    {
        protected HciClusterCollection() { }
        public virtual Azure.ResourceManager.StackHci.Models.HciClusterCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string clusterName, Azure.ResourceManager.StackHci.HciClusterData cluster, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StackHci.Models.HciClusterCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string clusterName, Azure.ResourceManager.StackHci.HciClusterData cluster, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.HciCluster> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StackHci.HciCluster> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StackHci.HciCluster> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.HciCluster>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StackHci.HciCluster> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StackHci.HciCluster>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StackHci.HciCluster> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StackHci.HciCluster>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StackHci.HciCluster> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StackHci.HciCluster>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterData : Azure.ResourceManager.Models.TrackedResource
    {
        public HciClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AadClientId { get { throw null; } set { } }
        public string AadTenantId { get { throw null; } set { } }
        public string BillingModel { get { throw null; } }
        public string CloudId { get { throw null; } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.CreatedByType? CreatedByType { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.ClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public System.DateTimeOffset? LastBillingTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.CreatedByType? LastModifiedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        public Azure.ResourceManager.StackHci.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RegistrationTimestamp { get { throw null; } }
        public Azure.ResourceManager.StackHci.Models.ClusterReportedProperties ReportedProperties { get { throw null; } }
        public Azure.ResourceManager.StackHci.Models.HciClusterStatus? Status { get { throw null; } }
        public float? TrialDaysRemaining { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.StackHci.HciClusterCollection GetHciClusters(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.StackHci.HciCluster> GetHciClusters(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StackHci.HciCluster> GetHciClustersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StackHci.Models
{
    public partial class ArcExtensionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.StackHci.ArcExtension>
    {
        protected ArcExtensionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.StackHci.ArcExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StackHci.ArcExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StackHci.ArcExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcExtensionDeleteOperation : Azure.Operation
    {
        protected ArcExtensionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcExtensionUpdateOperation : Azure.Operation<Azure.ResourceManager.StackHci.ArcExtension>
    {
        protected ArcExtensionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.StackHci.ArcExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StackHci.ArcExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StackHci.ArcExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSettingAggregateState : System.IEquatable<Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSettingAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState left, Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState left, Azure.ResourceManager.StackHci.Models.ArcSettingAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.StackHci.ArcSetting>
    {
        protected ArcSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.StackHci.ArcSetting Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StackHci.ArcSetting>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StackHci.ArcSetting>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcSettingDeleteOperation : Azure.Operation
    {
        protected ArcSettingDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterDesiredProperties
    {
        public ClusterDesiredProperties() { }
        public Azure.ResourceManager.StackHci.Models.DiagnosticLevel? DiagnosticLevel { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } set { } }
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
        public Azure.ResourceManager.StackHci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } }
    }
    public partial class ClusterPatch
    {
        public ClusterPatch() { }
        public string AadClientId { get { throw null; } set { } }
        public string AadTenantId { get { throw null; } set { } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.StackHci.Models.ClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ClusterReportedProperties
    {
        internal ClusterReportedProperties() { }
        public string ClusterId { get { throw null; } }
        public string ClusterName { get { throw null; } }
        public string ClusterVersion { get { throw null; } }
        public Azure.ResourceManager.StackHci.Models.DiagnosticLevel? DiagnosticLevel { get { throw null; } }
        public Azure.ResourceManager.StackHci.Models.ImdsAttestation? ImdsAttestation { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StackHci.Models.ClusterNode> Nodes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.StackHci.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.CreatedByType left, Azure.ResourceManager.StackHci.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.CreatedByType left, Azure.ResourceManager.StackHci.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiagnosticLevel : System.IEquatable<Azure.ResourceManager.StackHci.Models.DiagnosticLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnosticLevel(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.DiagnosticLevel Basic { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.DiagnosticLevel Enhanced { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.DiagnosticLevel Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.DiagnosticLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.DiagnosticLevel left, Azure.ResourceManager.StackHci.Models.DiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.DiagnosticLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.DiagnosticLevel left, Azure.ResourceManager.StackHci.Models.DiagnosticLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionAggregateState : System.IEquatable<Azure.ResourceManager.StackHci.Models.ExtensionAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ExtensionAggregateState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.ExtensionAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.ExtensionAggregateState left, Azure.ResourceManager.StackHci.Models.ExtensionAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.ExtensionAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.ExtensionAggregateState left, Azure.ResourceManager.StackHci.Models.ExtensionAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.StackHci.HciCluster>
    {
        protected HciClusterCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.StackHci.HciCluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StackHci.HciCluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StackHci.HciCluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterDeleteOperation : Azure.Operation
    {
        protected HciClusterDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterStatus : System.IEquatable<Azure.ResourceManager.StackHci.Models.HciClusterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterStatus(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.HciClusterStatus ConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.HciClusterStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.HciClusterStatus Error { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.HciClusterStatus NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.HciClusterStatus NotYetRegistered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.HciClusterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.HciClusterStatus left, Azure.ResourceManager.StackHci.Models.HciClusterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.HciClusterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.HciClusterStatus left, Azure.ResourceManager.StackHci.Models.HciClusterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImdsAttestation : System.IEquatable<Azure.ResourceManager.StackHci.Models.ImdsAttestation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImdsAttestation(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.ImdsAttestation Disabled { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ImdsAttestation Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.ImdsAttestation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.ImdsAttestation left, Azure.ResourceManager.StackHci.Models.ImdsAttestation right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.ImdsAttestation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.ImdsAttestation left, Azure.ResourceManager.StackHci.Models.ImdsAttestation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeArcState : System.IEquatable<Azure.ResourceManager.StackHci.Models.NodeArcState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeArcState(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Connected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Creating { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Deleted { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Error { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Moving { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeArcState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.NodeArcState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.NodeArcState left, Azure.ResourceManager.StackHci.Models.NodeArcState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.NodeArcState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.NodeArcState left, Azure.ResourceManager.StackHci.Models.NodeArcState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeExtensionState : System.IEquatable<Azure.ResourceManager.StackHci.Models.NodeExtensionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeExtensionState(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Connected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Creating { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Error { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Moving { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.NodeExtensionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.NodeExtensionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.NodeExtensionState left, Azure.ResourceManager.StackHci.Models.NodeExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.NodeExtensionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.NodeExtensionState left, Azure.ResourceManager.StackHci.Models.NodeExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PerNodeExtensionState
    {
        internal PerNodeExtensionState() { }
        public string Extension { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.StackHci.Models.NodeExtensionState? State { get { throw null; } }
    }
    public partial class PerNodeState
    {
        internal PerNodeState() { }
        public string ArcInstance { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.StackHci.Models.NodeArcState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.StackHci.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.ProvisioningState left, Azure.ResourceManager.StackHci.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.ProvisioningState left, Azure.ResourceManager.StackHci.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsServerSubscription : System.IEquatable<Azure.ResourceManager.StackHci.Models.WindowsServerSubscription>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsServerSubscription(string value) { throw null; }
        public static Azure.ResourceManager.StackHci.Models.WindowsServerSubscription Disabled { get { throw null; } }
        public static Azure.ResourceManager.StackHci.Models.WindowsServerSubscription Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StackHci.Models.WindowsServerSubscription other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StackHci.Models.WindowsServerSubscription left, Azure.ResourceManager.StackHci.Models.WindowsServerSubscription right) { throw null; }
        public static implicit operator Azure.ResourceManager.StackHci.Models.WindowsServerSubscription (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StackHci.Models.WindowsServerSubscription left, Azure.ResourceManager.StackHci.Models.WindowsServerSubscription right) { throw null; }
        public override string ToString() { throw null; }
    }
}
