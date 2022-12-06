namespace Azure.ResourceManager.Analysis
{
    public static partial class AnalysisExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Analysis.Models.AnalysisServerNameAvailabilityResult> CheckAnalysisServerNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Analysis.Models.AnalysisServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.Models.AnalysisServerNameAvailabilityResult>> CheckAnalysisServerNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Analysis.Models.AnalysisServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource> GetAnalysisServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource>> GetAnalysisServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Analysis.AnalysisServerResource GetAnalysisServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Analysis.AnalysisServerCollection GetAnalysisServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Analysis.AnalysisServerResource> GetAnalysisServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Analysis.AnalysisServerResource> GetAnalysisServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Analysis.Models.AnalysisResourceSku> GetEligibleSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Analysis.Models.AnalysisResourceSku> GetEligibleSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnalysisServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Analysis.AnalysisServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Analysis.AnalysisServerResource>, System.Collections.IEnumerable
    {
        protected AnalysisServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Analysis.AnalysisServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.Analysis.AnalysisServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Analysis.AnalysisServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.Analysis.AnalysisServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Analysis.AnalysisServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Analysis.AnalysisServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Analysis.AnalysisServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Analysis.AnalysisServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Analysis.AnalysisServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Analysis.AnalysisServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AnalysisServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AnalysisServerData(Azure.Core.AzureLocation location, Azure.ResourceManager.Analysis.Models.AnalysisResourceSku analysisSku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Analysis.Models.AnalysisResourceSku AnalysisServerSku { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisResourceSku AnalysisSku { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AsAdministratorIdentities { get { throw null; } }
        public System.Uri BackupBlobContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisGatewayDetails GatewayDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisIPv4FirewallSettings IPv4FirewallSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisManagedMode? ManagedMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Analysis.Models.AnalysisConnectionMode? QueryPoolConnectionMode { get { throw null; } set { } }
        public string ServerFullName { get { throw null; } }
        public Azure.ResourceManager.Analysis.Models.ServerMonitorMode? ServerMonitorMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisState? State { get { throw null; } }
    }
    public partial class AnalysisServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AnalysisServerResource() { }
        public virtual Azure.ResourceManager.Analysis.AnalysisServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DissociateGateway(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DissociateGatewayAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Analysis.Models.AnalysisExistingSku> GetExistingSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Analysis.Models.AnalysisExistingSku> GetExistingSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.Models.AnalysisGatewayStatus> GetGatewayStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.Models.AnalysisGatewayStatus>> GetGatewayStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Analysis.AnalysisServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Suspend(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SuspendAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Analysis.AnalysisServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Analysis.Models.AnalysisServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Analysis.AnalysisServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Analysis.Models.AnalysisServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Analysis.Models
{
    public enum AnalysisConnectionMode
    {
        All = 0,
        ReadOnly = 1,
    }
    public partial class AnalysisExistingSku
    {
        internal AnalysisExistingSku() { }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.Analysis.Models.AnalysisResourceSku Sku { get { throw null; } }
    }
    public partial class AnalysisGatewayDetails
    {
        public AnalysisGatewayDetails() { }
        public System.Uri DmtsClusterUri { get { throw null; } }
        public string GatewayObjectId { get { throw null; } }
        public string GatewayResourceId { get { throw null; } set { } }
    }
    public partial class AnalysisGatewayStatus
    {
        internal AnalysisGatewayStatus() { }
        public Azure.ResourceManager.Analysis.Models.AnalysisStatus? Status { get { throw null; } }
    }
    public partial class AnalysisIPv4FirewallRule
    {
        public AnalysisIPv4FirewallRule() { }
        public string FirewallRuleName { get { throw null; } set { } }
        public string RangeEnd { get { throw null; } set { } }
        public string RangeStart { get { throw null; } set { } }
    }
    public partial class AnalysisIPv4FirewallSettings
    {
        public AnalysisIPv4FirewallSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Analysis.Models.AnalysisIPv4FirewallRule> FirewallRules { get { throw null; } }
        public bool? IsPowerBIServiceEnabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisManagedMode : System.IEquatable<Azure.ResourceManager.Analysis.Models.AnalysisManagedMode>
    {
        private readonly int _dummyPrimitive;
        public AnalysisManagedMode(int value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.AnalysisManagedMode One { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisManagedMode Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.AnalysisManagedMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.AnalysisManagedMode left, Azure.ResourceManager.Analysis.Models.AnalysisManagedMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.AnalysisManagedMode (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.AnalysisManagedMode left, Azure.ResourceManager.Analysis.Models.AnalysisManagedMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisProvisioningState : System.IEquatable<Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalysisProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Paused { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Pausing { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Resuming { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Suspended { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Suspending { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState left, Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState left, Azure.ResourceManager.Analysis.Models.AnalysisProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalysisResourceSku
    {
        public AnalysisResourceSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisSkuTier? Tier { get { throw null; } set { } }
    }
    public partial class AnalysisServerNameAvailabilityContent
    {
        public AnalysisServerNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class AnalysisServerNameAvailabilityResult
    {
        internal AnalysisServerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class AnalysisServerPatch
    {
        public AnalysisServerPatch() { }
        public System.Collections.Generic.IList<string> AsAdministratorIdentities { get { throw null; } }
        public System.Uri BackupBlobContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisGatewayDetails GatewayDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisIPv4FirewallSettings IPV4FirewallSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisManagedMode? ManagedMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisConnectionMode? QuerypoolConnectionMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.ServerMonitorMode? ServerMonitorMode { get { throw null; } set { } }
        public Azure.ResourceManager.Analysis.Models.AnalysisResourceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisSkuTier : System.IEquatable<Azure.ResourceManager.Analysis.Models.AnalysisSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalysisSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.AnalysisSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisSkuTier Development { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.AnalysisSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.AnalysisSkuTier left, Azure.ResourceManager.Analysis.Models.AnalysisSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.AnalysisSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.AnalysisSkuTier left, Azure.ResourceManager.Analysis.Models.AnalysisSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisState : System.IEquatable<Azure.ResourceManager.Analysis.Models.AnalysisState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalysisState(string value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Failed { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Paused { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Pausing { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Resuming { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Suspended { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Suspending { get { throw null; } }
        public static Azure.ResourceManager.Analysis.Models.AnalysisState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.AnalysisState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.AnalysisState left, Azure.ResourceManager.Analysis.Models.AnalysisState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.AnalysisState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.AnalysisState left, Azure.ResourceManager.Analysis.Models.AnalysisState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalysisStatus : System.IEquatable<Azure.ResourceManager.Analysis.Models.AnalysisStatus>
    {
        private readonly int _dummyPrimitive;
        public AnalysisStatus(int value) { throw null; }
        public static Azure.ResourceManager.Analysis.Models.AnalysisStatus Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Analysis.Models.AnalysisStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Analysis.Models.AnalysisStatus left, Azure.ResourceManager.Analysis.Models.AnalysisStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Analysis.Models.AnalysisStatus (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Analysis.Models.AnalysisStatus left, Azure.ResourceManager.Analysis.Models.AnalysisStatus right) { throw null; }
        public override string ToString() { throw null; }
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
