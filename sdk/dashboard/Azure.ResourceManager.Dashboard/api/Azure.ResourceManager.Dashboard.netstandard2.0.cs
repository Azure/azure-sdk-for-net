namespace Azure.ResourceManager.Dashboard
{
    public static partial class DashboardExtensions
    {
        public static Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource GetDashboardPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource GetDashboardPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetManagedGrafana(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> GetManagedGrafanaAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dashboard.ManagedGrafanaResource GetManagedGrafanaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dashboard.ManagedGrafanaCollection GetManagedGrafanas(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetManagedGrafanas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetManagedGrafanasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DashboardPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected DashboardPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DashboardPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public DashboardPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Dashboard.Models.DashboardPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DashboardPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DashboardPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DashboardPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DashboardPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Dashboard.DashboardPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DashboardPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected DashboardPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DashboardPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DashboardPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.Dashboard.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class ManagedGrafanaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>, System.Collections.IEnumerable
    {
        protected ManagedGrafanaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Dashboard.ManagedGrafanaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Dashboard.ManagedGrafanaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedGrafanaData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedGrafanaData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.ManagedGrafanaProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class ManagedGrafanaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedGrafanaResource() { }
        public virtual Azure.ResourceManager.Dashboard.ManagedGrafanaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource> GetDashboardPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionResource>> GetDashboardPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionCollection GetDashboardPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource> GetDashboardPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.DashboardPrivateLinkResource>> GetDashboardPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dashboard.DashboardPrivateLinkResourceCollection GetDashboardPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> Update(Azure.ResourceManager.Dashboard.Models.ManagedGrafanaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> UpdateAsync(Azure.ResourceManager.Dashboard.Models.ManagedGrafanaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dashboard.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiKey : System.IEquatable<Azure.ResourceManager.Dashboard.Models.ApiKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiKey(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.ApiKey Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ApiKey Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.ApiKey other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.ApiKey left, Azure.ResourceManager.Dashboard.Models.ApiKey right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.ApiKey (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.ApiKey left, Azure.ResourceManager.Dashboard.Models.ApiKey right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureMonitorWorkspaceIntegration
    {
        public AzureMonitorWorkspaceIntegration() { }
        public string AzureMonitorWorkspaceResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DashboardPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DashboardPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DashboardPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DashboardPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DashboardPrivateLinkServiceConnectionState
    {
        public DashboardPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.DashboardPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeterministicOutboundIP : System.IEquatable<Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeterministicOutboundIP(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP left, Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP left, Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedGrafanaPatch
    {
        public ManagedGrafanaPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.ManagedGrafanaPropertiesUpdateParameters Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ManagedGrafanaProperties
    {
        public ManagedGrafanaProperties() { }
        public Azure.ResourceManager.Dashboard.Models.ApiKey? ApiKey { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dashboard.Models.AzureMonitorWorkspaceIntegration> AzureMonitorWorkspaceIntegrations { get { throw null; } }
        public Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP? DeterministicOutboundIP { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public string GrafanaVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OutboundIPs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Dashboard.DashboardPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Dashboard.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.ZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
    }
    public partial class ManagedGrafanaPropertiesUpdateParameters
    {
        public ManagedGrafanaPropertiesUpdateParameters() { }
        public Azure.ResourceManager.Dashboard.Models.ApiKey? ApiKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dashboard.Models.AzureMonitorWorkspaceIntegration> AzureMonitorWorkspaceIntegrations { get { throw null; } }
        public Azure.ResourceManager.Dashboard.Models.DeterministicOutboundIP? DeterministicOutboundIP { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.ZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Dashboard.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.ProvisioningState left, Azure.ResourceManager.Dashboard.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.ProvisioningState left, Azure.ResourceManager.Dashboard.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess left, Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess left, Azure.ResourceManager.Dashboard.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneRedundancy : System.IEquatable<Azure.ResourceManager.Dashboard.Models.ZoneRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.ZoneRedundancy Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ZoneRedundancy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.ZoneRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.ZoneRedundancy left, Azure.ResourceManager.Dashboard.Models.ZoneRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.ZoneRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.ZoneRedundancy left, Azure.ResourceManager.Dashboard.Models.ZoneRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
