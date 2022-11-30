namespace Azure.ResourceManager.Analysis
{
    public static partial class AnalysisServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Analysis.Models.CheckServerNameAvailabilityResult> CheckNameAvailabilityServer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Analysis.Models.CheckServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.Models.CheckServerNameAvailabilityResult>> CheckNameAvailabilityServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Analysis.Models.CheckServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> GetAnalysisServicesServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>> GetAnalysisServicesServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Analysis.AnalysisServicesServerResource GetAnalysisServicesServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Analysis.AnalysisServicesServerCollection GetAnalysisServicesServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> GetAnalysisServicesServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> GetAnalysisServicesServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GetOperationResultsServer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetOperationResultsServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Analysis.Models.OperationStatus> GetOperationStatusesServer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.Models.OperationStatus>> GetOperationStatusesServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Analysis.Models.ResourceSku> GetSkusForNewServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Analysis.Models.ResourceSku> GetSkusForNewServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalysisServicesServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>, System.Collections.IEnumerable
    {
        protected AnalysisServicesServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.Analysis.AnalysisServicesServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.Analysis.AnalysisServicesServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AnalysisServicesServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AnalysisServicesServerData(Azure.Core.AzureLocation location, Azure.ResourceManager.Analysis.Models.ResourceSku analysisServicesSKU) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Analysis.Models.ResourceSku AnalysisServicesServerSKU { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.ResourceSku AnalysisServicesSKU { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AsAdministratorIdentities { get { throw null; } }
        public System.Uri BackupBlobContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.GatewayDetails GatewayDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.IPv4FirewallSettings IPV4FirewallSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.ManagedMode? ManagedMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Analysis.Models.ConnectionMode? QuerypoolConnectionMode { get { throw null; } set { } }
        public string ServerFullName { get { throw null; } }
        public Azure.ResourceManager.Analysis.Models.ServerMonitorMode? ServerMonitorMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisServicesState? State { get { throw null; } }
    }
    public partial class AnalysisServicesServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AnalysisServicesServerResource() { }
        public virtual Azure.ResourceManager.Analysis.AnalysisServicesServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DissociateGateway(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DissociateGatewayAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.Models.GatewayListStatusLive> GetGatewayStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.Models.GatewayListStatusLive>> GetGatewayStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Analysis.Models.ExistingResourceSkuDetails> GetSkusForExisting(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Analysis.Models.ExistingResourceSkuDetails> GetSkusForExistingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Suspend(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SuspendAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Analysis.AnalysisServicesServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Analysis.Models.AnalysisServicesServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Analysis.AnalysisServicesServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Analysis.Models.AnalysisServicesServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Analysis.Models
{
    public partial class AnalysisServicesServerPatch
    {
        public AnalysisServicesServerPatch() { }
        public System.Collections.Generic.IList<string> AsAdministratorIdentities { get { throw null; } }
        public System.Uri BackupBlobContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.GatewayDetails GatewayDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.IPv4FirewallSettings IPV4FirewallSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.ManagedMode? ManagedMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.ConnectionMode? QuerypoolConnectionMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.ServerMonitorMode? ServerMonitorMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.ResourceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisServicesSkuTier : System.IEquatable<Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalysisServicesSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier Development { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier left, Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier left, Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisServicesState : System.IEquatable<Azure.ResourceManager.Analysis.Models.AnalysisServicesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalysisServicesState(string value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Failed { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Paused { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Pausing { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Resuming { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Suspended { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Suspending { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.AnalysisServicesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.AnalysisServicesState left, Azure.ResourceManager.Analysis.Models.AnalysisServicesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.AnalysisServicesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.AnalysisServicesState left, Azure.ResourceManager.Analysis.Models.AnalysisServicesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisServicesStatus : System.IEquatable<Azure.ResourceManager.Analysis.Models.AnalysisServicesStatus>
    {
        private readonly int _dummyPrimitive;
        public AnalysisServicesStatus(int value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.AnalysisServicesStatus _0 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.AnalysisServicesStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.AnalysisServicesStatus left, Azure.ResourceManager.Analysis.Models.AnalysisServicesStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.AnalysisServicesStatus (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.AnalysisServicesStatus left, Azure.ResourceManager.Analysis.Models.AnalysisServicesStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckServerNameAvailabilityContent
    {
        public CheckServerNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class CheckServerNameAvailabilityResult
    {
        internal CheckServerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public enum ConnectionMode
    {
        All = 0,
        ReadOnly = 1,
    }
    public partial class ExistingResourceSkuDetails
    {
        internal ExistingResourceSkuDetails() { }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.Analysis.Models.ResourceSku Sku { get { throw null; } }
    }
    public partial class GatewayDetails
    {
        public GatewayDetails() { }
        public System.Uri DmtsClusterUri { get { throw null; } }
        public string GatewayObjectId { get { throw null; } }
        public string GatewayResourceId { get { throw null; } set { } }
    }
    public partial class GatewayListStatusLive
    {
        internal GatewayListStatusLive() { }
        public Azure.ResourceManager.Analysis.Models.AnalysisServicesStatus? Status { get { throw null; } }
    }
    public partial class IPv4FirewallRule
    {
        public IPv4FirewallRule() { }
        public string FirewallRuleName { get { throw null; } set { } }
        public string RangeEnd { get { throw null; } set { } }
        public string RangeStart { get { throw null; } set { } }
    }
    public partial class IPv4FirewallSettings
    {
        public IPv4FirewallSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Analysis.Models.IPv4FirewallRule> FirewallRules { get { throw null; } }
        public bool? IsPowerBIServiceEnabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedMode : System.IEquatable<Azure.ResourceManager.Analysis.Models.ManagedMode>
    {
        private readonly int _dummyPrimitive;
        public ManagedMode(int value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.ManagedMode One { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ManagedMode Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.ManagedMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.ManagedMode left, Azure.ResourceManager.Analysis.Models.ManagedMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.ManagedMode (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.ManagedMode left, Azure.ResourceManager.Analysis.Models.ManagedMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationStatus
    {
        internal OperationStatus() { }
        public string EndTime { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Analysis.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Paused { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Pausing { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Resuming { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Suspended { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Suspending { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.ProvisioningState left, Azure.ResourceManager.Analysis.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.ProvisioningState left, Azure.ResourceManager.Analysis.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSku
    {
        public ResourceSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisServicesSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerMonitorMode : System.IEquatable<Azure.ResourceManager.Analysis.Models.ServerMonitorMode>
    {
        private readonly int _dummyPrimitive;
        public ServerMonitorMode(int value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.ServerMonitorMode One { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.ServerMonitorMode Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.ServerMonitorMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.ServerMonitorMode left, Azure.ResourceManager.Analysis.Models.ServerMonitorMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.ServerMonitorMode (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.ServerMonitorMode left, Azure.ResourceManager.Analysis.Models.ServerMonitorMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
