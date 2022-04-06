namespace Azure.ResourceManager.StoragePool
{
    public partial class DiskPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.DiskPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.DiskPoolResource>, System.Collections.IEnumerable
    {
        protected DiskPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diskPoolName, Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diskPoolName, Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> Get(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> GetAsync(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StoragePool.DiskPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.DiskPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StoragePool.DiskPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.DiskPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DiskPoolData(Azure.Core.AzureLocation location, Azure.ResourceManager.StoragePool.Models.ProvisioningStates provisioningState, System.Collections.Generic.IEnumerable<string> availabilityZones, Azure.ResourceManager.StoragePool.Models.OperationalStatus status, string subnetId) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> AdditionalCapabilities { get { throw null; } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Disks { get { throw null; } }
        public string ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagedByExtended { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.ProvisioningStates ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.StoragePool.Models.OperationalStatus Status { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class DiskPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskPoolResource() { }
        public virtual Azure.ResourceManager.StoragePool.DiskPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.IscsiTargetResource> GetIscsiTarget(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTargetResource>> GetIscsiTargetAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.IscsiTargetCollection GetIscsiTargets() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StoragePool.Models.DiskPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.DiskPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StoragePool.Models.DiskPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IscsiTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.IscsiTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.IscsiTargetResource>, System.Collections.IEnumerable
    {
        protected IscsiTargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.IscsiTargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string iscsiTargetName, Azure.ResourceManager.StoragePool.Models.IscsiTargetCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.IscsiTargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string iscsiTargetName, Azure.ResourceManager.StoragePool.Models.IscsiTargetCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.IscsiTargetResource> Get(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.IscsiTargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.IscsiTargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTargetResource>> GetAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StoragePool.IscsiTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.IscsiTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StoragePool.IscsiTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.IscsiTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IscsiTargetData : Azure.ResourceManager.Models.ResourceData
    {
        public IscsiTargetData(Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode aclMode, string targetIqn, Azure.ResourceManager.StoragePool.Models.ProvisioningStates provisioningState, Azure.ResourceManager.StoragePool.Models.OperationalStatus status) { }
        public Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode AclMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.IscsiLun> Luns { get { throw null; } }
        public string ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagedByExtended { get { throw null; } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.StoragePool.Models.ProvisioningStates ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Sessions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.Acl> StaticAcls { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.OperationalStatus Status { get { throw null; } set { } }
        public string TargetIqn { get { throw null; } set { } }
    }
    public partial class IscsiTargetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IscsiTargetResource() { }
        public virtual Azure.ResourceManager.StoragePool.IscsiTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskPoolName, string iscsiTargetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.IscsiTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.IscsiTargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.StoragePool.Models.IscsiTargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.StoragePool.IscsiTargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.StoragePool.Models.IscsiTargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StoragePoolExtensions
    {
        public static Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource> GetDiskPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPoolResource>> GetDiskPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StoragePool.DiskPoolResource GetDiskPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StoragePool.DiskPoolCollection GetDiskPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetDiskPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StoragePool.DiskPoolResource> GetDiskPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo> GetDiskPoolZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo> GetDiskPoolZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.StoragePool.IscsiTargetResource GetIscsiTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StoragePool.Models.ResourceSkuInfo> GetResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.ResourceSkuInfo> GetResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.StoragePool.Models
{
    public partial class Acl
    {
        public Acl(string initiatorIqn, System.Collections.Generic.IEnumerable<string> mappedLuns) { }
        public string InitiatorIqn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MappedLuns { get { throw null; } }
    }
    public partial class DiskPoolCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public DiskPoolCreateOrUpdateContent(Azure.ResourceManager.StoragePool.Models.StoragePoolSku sku, string location, string subnetId) { }
        public System.Collections.Generic.IList<string> AdditionalCapabilities { get { throw null; } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Disks { get { throw null; } }
        public string Location { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSku Sku { get { throw null; } }
        public string SubnetId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DiskPoolPatch
    {
        public DiskPoolPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Disks { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DiskPoolZoneInfo
    {
        internal DiskPoolZoneInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> AdditionalCapabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.StoragePoolSku Sku { get { throw null; } }
    }
    public partial class EndpointDependency
    {
        internal EndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.EndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class EndpointDetail
    {
        internal EndpointDetail() { }
        public string IPAddress { get { throw null; } }
        public bool? IsAccessible { get { throw null; } }
        public double? Latency { get { throw null; } }
        public int? Port { get { throw null; } }
    }
    public partial class IscsiLun
    {
        public IscsiLun(string name, string managedDiskAzureResourceId) { }
        public int? Lun { get { throw null; } }
        public string ManagedDiskAzureResourceId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IscsiTargetAclMode : System.IEquatable<Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IscsiTargetAclMode(string value) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode Dynamic { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode left, Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode left, Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IscsiTargetCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public IscsiTargetCreateOrUpdateContent(Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode aclMode) { }
        public Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode AclMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.IscsiLun> Luns { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.Acl> StaticAcls { get { throw null; } }
        public string TargetIqn { get { throw null; } set { } }
    }
    public partial class IscsiTargetPatch : Azure.ResourceManager.Models.ResourceData
    {
        public IscsiTargetPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.IscsiLun> Luns { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.Acl> StaticAcls { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalStatus : System.IEquatable<Azure.ResourceManager.StoragePool.Models.OperationalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalStatus(string value) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.OperationalStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.OperationalStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.OperationalStatus Running { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.OperationalStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.OperationalStatus StoppedDeallocated { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.OperationalStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.OperationalStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.OperationalStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StoragePool.Models.OperationalStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StoragePool.Models.OperationalStatus left, Azure.ResourceManager.StoragePool.Models.OperationalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.StoragePool.Models.OperationalStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StoragePool.Models.OperationalStatus left, Azure.ResourceManager.StoragePool.Models.OperationalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutboundEnvironmentEndpoint
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.EndpointDependency> Endpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStates : System.IEquatable<Azure.ResourceManager.StoragePool.Models.ProvisioningStates>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStates(string value) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.ProvisioningStates Canceled { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.ProvisioningStates Creating { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.ProvisioningStates Deleting { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.ProvisioningStates Failed { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.ProvisioningStates Invalid { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.ProvisioningStates Pending { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.ProvisioningStates Succeeded { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.ProvisioningStates Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StoragePool.Models.ProvisioningStates other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StoragePool.Models.ProvisioningStates left, Azure.ResourceManager.StoragePool.Models.ProvisioningStates right) { throw null; }
        public static implicit operator Azure.ResourceManager.StoragePool.Models.ProvisioningStates (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StoragePool.Models.ProvisioningStates left, Azure.ResourceManager.StoragePool.Models.ProvisioningStates right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSkuCapability
    {
        internal ResourceSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ResourceSkuInfo
    {
        internal ResourceSkuInfo() { }
        public string ApiVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.ResourceSkuCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.ResourceSkuLocationInfo LocationInfo { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ResourceSkuLocationInfo
    {
        internal ResourceSkuLocationInfo() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictionInfo
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictions
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.StoragePool.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.ResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.ResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public enum ResourceSkuRestrictionsReasonCode
    {
        QuotaId = 0,
        NotAvailableForSubscription = 1,
    }
    public enum ResourceSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class ResourceSkuZoneDetails
    {
        internal ResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.StoragePool.Models.ResourceSkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
    }
    public partial class StoragePoolSku
    {
        public StoragePoolSku(string name) { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
}
