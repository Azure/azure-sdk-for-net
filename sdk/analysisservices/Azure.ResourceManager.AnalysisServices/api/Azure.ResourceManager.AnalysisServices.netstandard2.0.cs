namespace Azure.ResourceManager.AnalysisServices
{
    public static partial class AnalysisServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AnalysisServices.Models.CheckServerNameAvailabilityResult> CheckNameAvailabilityServer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AnalysisServices.Models.CheckServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AnalysisServices.Models.CheckServerNameAvailabilityResult>> CheckNameAvailabilityServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AnalysisServices.Models.CheckServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> GetAnalysisServicesServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>> GetAnalysisServicesServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource GetAnalysisServicesServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AnalysisServices.AnalysisServicesServerCollection GetAnalysisServicesServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> GetAnalysisServicesServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> GetAnalysisServicesServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GetOperationResultsServer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetOperationResultsServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AnalysisServices.Models.OperationStatus> GetOperationStatusesServer(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AnalysisServices.Models.OperationStatus>> GetOperationStatusesServerAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AnalysisServices.Models.ResourceSku> GetSkusForNewServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AnalysisServices.Models.ResourceSku> GetSkusForNewServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalysisServicesServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>, System.Collections.IEnumerable
    {
        protected AnalysisServicesServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.AnalysisServices.AnalysisServicesServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.AnalysisServices.AnalysisServicesServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AnalysisServicesServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AnalysisServicesServerData(Azure.Core.AzureLocation location, Azure.ResourceManager.AnalysisServices.Models.ResourceSku analysisServicesSKU) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.AnalysisServices.Models.ResourceSku AnalysisServicesServerSKU { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.ResourceSku AnalysisServicesSKU { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AsAdministratorIdentities { get { throw null; } }
        public System.Uri BackupBlobContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.GatewayDetails GatewayDetails { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.IPv4FirewallSettings IPV4FirewallSettings { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.ManagedMode? ManagedMode { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AnalysisServices.Models.ConnectionMode? QuerypoolConnectionMode { get { throw null; } set { } }
        public string ServerFullName { get { throw null; } }
        public Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode? ServerMonitorMode { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState? State { get { throw null; } }
    }
    public partial class AnalysisServicesServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AnalysisServicesServerResource() { }
        public virtual Azure.ResourceManager.AnalysisServices.AnalysisServicesServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DissociateGateway(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DissociateGatewayAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AnalysisServices.Models.GatewayListStatusLive> GetGatewayStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AnalysisServices.Models.GatewayListStatusLive>> GetGatewayStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AnalysisServices.Models.ExistingResourceSkuDetails> GetSkusForExisting(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AnalysisServices.Models.ExistingResourceSkuDetails> GetSkusForExistingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Suspend(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SuspendAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AnalysisServices.AnalysisServicesServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AnalysisServices.Models
{
    public partial class AnalysisServicesServerPatch
    {
        public AnalysisServicesServerPatch() { }
        public System.Collections.Generic.IList<string> AsAdministratorIdentities { get { throw null; } }
        public System.Uri BackupBlobContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.GatewayDetails GatewayDetails { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.IPv4FirewallSettings IPV4FirewallSettings { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.ManagedMode? ManagedMode { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.ConnectionMode? QuerypoolConnectionMode { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode? ServerMonitorMode { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.ResourceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisServicesSkuTier : System.IEquatable<Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalysisServicesSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier Development { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier left, Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier left, Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisServicesState : System.IEquatable<Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalysisServicesState(string value) { throw null; }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Failed { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Paused { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Pausing { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Preparing { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Resuming { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Scaling { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Suspended { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Suspending { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState left, Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState left, Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisServicesStatus : System.IEquatable<Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesStatus>
    {
        private readonly int _dummyPrimitive;
        public AnalysisServicesStatus(int value) { throw null; }
        public static Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesStatus _0 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesStatus left, Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesStatus (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesStatus left, Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesStatus right) { throw null; }
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
        public Azure.ResourceManager.AnalysisServices.Models.ResourceSku Sku { get { throw null; } }
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
        public Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesStatus? Status { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.AnalysisServices.Models.IPv4FirewallRule> FirewallRules { get { throw null; } }
        public bool? IsPowerBIServiceEnabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedMode : System.IEquatable<Azure.ResourceManager.AnalysisServices.Models.ManagedMode>
    {
        private readonly int _dummyPrimitive;
        public ManagedMode(int value) { throw null; }
        public static Azure.ResourceManager.AnalysisServices.Models.ManagedMode One { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ManagedMode Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AnalysisServices.Models.ManagedMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AnalysisServices.Models.ManagedMode left, Azure.ResourceManager.AnalysisServices.Models.ManagedMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.AnalysisServices.Models.ManagedMode (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AnalysisServices.Models.ManagedMode left, Azure.ResourceManager.AnalysisServices.Models.ManagedMode right) { throw null; }
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
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.AnalysisServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Paused { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Pausing { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Preparing { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Resuming { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Suspended { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Suspending { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AnalysisServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AnalysisServices.Models.ProvisioningState left, Azure.ResourceManager.AnalysisServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AnalysisServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AnalysisServices.Models.ProvisioningState left, Azure.ResourceManager.AnalysisServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSku
    {
        public ResourceSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.AnalysisServices.Models.AnalysisServicesSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerMonitorMode : System.IEquatable<Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode>
    {
        private readonly int _dummyPrimitive;
        public ServerMonitorMode(int value) { throw null; }
        public static Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode One { get { throw null; } }
        public static Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode left, Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode left, Azure.ResourceManager.AnalysisServices.Models.ServerMonitorMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
