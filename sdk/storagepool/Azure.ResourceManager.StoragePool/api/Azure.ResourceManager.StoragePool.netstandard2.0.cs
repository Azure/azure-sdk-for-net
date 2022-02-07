namespace Azure.ResourceManager.StoragePool
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.StoragePool.DiskPool GetDiskPool(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.StoragePool.IscsiTarget GetIscsiTarget(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DiskPool : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskPool() { }
        public virtual Azure.ResourceManager.StoragePool.DiskPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPool> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskPoolName) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.Models.DiskPoolDeallocateOperation Deallocate(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StoragePool.Models.DiskPoolDeallocateOperation> DeallocateAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.Models.DiskPoolDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StoragePool.Models.DiskPoolDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPool> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.IscsiTargetCollection GetIscsiTargets() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPool> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPool> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.Models.DiskPoolStartOperation Start(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StoragePool.Models.DiskPoolStartOperation> StartAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.Models.DiskPoolUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.StoragePool.Models.DiskPoolUpdate diskPoolUpdatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StoragePool.Models.DiskPoolUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.StoragePool.Models.DiskPoolUpdate diskPoolUpdatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.Models.DiskPoolUpgradeOperation Upgrade(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StoragePool.Models.DiskPoolUpgradeOperation> UpgradeAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskPoolCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.DiskPool>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.DiskPool>, System.Collections.IEnumerable
    {
        protected DiskPoolCollection() { }
        public virtual Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string diskPoolName, Azure.ResourceManager.StoragePool.Models.DiskPoolCreate diskPoolCreatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StoragePool.Models.DiskPoolCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string diskPoolName, Azure.ResourceManager.StoragePool.Models.DiskPoolCreate diskPoolCreatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPool> Get(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.DiskPool> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.DiskPool> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> GetAsync(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.DiskPool> GetIfExists(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> GetIfExistsAsync(string diskPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StoragePool.DiskPool> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.DiskPool>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StoragePool.DiskPool> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.DiskPool>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskPoolData : Azure.ResourceManager.Models.TrackedResource
    {
        public DiskPoolData(Azure.Core.AzureLocation location, Azure.ResourceManager.StoragePool.Models.ProvisioningStates provisioningState, System.Collections.Generic.IEnumerable<string> availabilityZones, Azure.ResourceManager.StoragePool.Models.OperationalStatus status, string subnetId) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> AdditionalCapabilities { get { throw null; } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Disks { get { throw null; } }
        public string ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagedByExtended { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.ProvisioningStates ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.StoragePool.Models.OperationalStatus Status { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class IscsiTarget : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IscsiTarget() { }
        public virtual Azure.ResourceManager.StoragePool.IscsiTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskPoolName, string iscsiTargetName) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.Models.IscsiTargetDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StoragePool.Models.IscsiTargetDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.StoragePool.Models.IscsiTargetUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.StoragePool.Models.IscsiTargetUpdate iscsiTargetUpdatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StoragePool.Models.IscsiTargetUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.StoragePool.Models.IscsiTargetUpdate iscsiTargetUpdatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IscsiTargetCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.IscsiTarget>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.IscsiTarget>, System.Collections.IEnumerable
    {
        protected IscsiTargetCollection() { }
        public virtual Azure.ResourceManager.StoragePool.Models.IscsiTargetCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string iscsiTargetName, Azure.ResourceManager.StoragePool.Models.IscsiTargetCreate iscsiTargetCreatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.StoragePool.Models.IscsiTargetCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string iscsiTargetName, Azure.ResourceManager.StoragePool.Models.IscsiTargetCreate iscsiTargetCreatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget> Get(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.StoragePool.IscsiTarget> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.StoragePool.IscsiTarget> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget>> GetAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget> GetIfExists(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget>> GetIfExistsAsync(string iscsiTargetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.StoragePool.IscsiTarget> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.StoragePool.IscsiTarget>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.StoragePool.IscsiTarget> System.Collections.Generic.IEnumerable<Azure.ResourceManager.StoragePool.IscsiTarget>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IscsiTargetData : Azure.ResourceManager.Models.Resource
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
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.StoragePool.DiskPoolCollection GetDiskPools(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.StoragePool.DiskPool> GetDiskPools(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StoragePool.DiskPool> GetDiskPoolsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo> GetDiskPoolZones(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.DiskPoolZoneInfo> GetDiskPoolZonesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.StoragePool.Models.ResourceSkuInfo> GetResourceSkus(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.StoragePool.Models.ResourceSkuInfo> GetResourceSkusAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.StoragePool.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.StoragePool.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.StoragePool.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.StoragePool.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.StoragePool.Models.CreatedByType left, Azure.ResourceManager.StoragePool.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.StoragePool.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.StoragePool.Models.CreatedByType left, Azure.ResourceManager.StoragePool.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskPoolCreate : Azure.ResourceManager.Models.Resource
    {
        public DiskPoolCreate(Azure.ResourceManager.StoragePool.Models.Sku sku, string location, string subnetId) { }
        public System.Collections.Generic.IList<string> AdditionalCapabilities { get { throw null; } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Disks { get { throw null; } }
        public string Location { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.Sku Sku { get { throw null; } }
        public string SubnetId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DiskPoolCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.StoragePool.DiskPool>
    {
        protected DiskPoolCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.StoragePool.DiskPool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskPoolDeallocateOperation : Azure.Operation
    {
        protected DiskPoolDeallocateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskPoolDeleteOperation : Azure.Operation
    {
        protected DiskPoolDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskPoolStartOperation : Azure.Operation
    {
        protected DiskPoolStartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskPoolUpdate
    {
        public DiskPoolUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Disks { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DiskPoolUpdateOperation : Azure.Operation<Azure.ResourceManager.StoragePool.DiskPool>
    {
        protected DiskPoolUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.StoragePool.DiskPool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StoragePool.DiskPool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskPoolUpgradeOperation : Azure.Operation
    {
        protected DiskPoolUpgradeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskPoolZoneInfo
    {
        internal DiskPoolZoneInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> AdditionalCapabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.StoragePool.Models.Sku Sku { get { throw null; } }
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
        public string IpAddress { get { throw null; } }
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
    public partial class IscsiTargetCreate : Azure.ResourceManager.Models.Resource
    {
        public IscsiTargetCreate(Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode aclMode) { }
        public Azure.ResourceManager.StoragePool.Models.IscsiTargetAclMode AclMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.IscsiLun> Luns { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.Acl> StaticAcls { get { throw null; } }
        public string TargetIqn { get { throw null; } set { } }
    }
    public partial class IscsiTargetCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.StoragePool.IscsiTarget>
    {
        protected IscsiTargetCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.StoragePool.IscsiTarget Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IscsiTargetDeleteOperation : Azure.Operation
    {
        protected IscsiTargetDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IscsiTargetUpdate : Azure.ResourceManager.Models.Resource
    {
        public IscsiTargetUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.IscsiLun> Luns { get { throw null; } }
        public string ManagedBy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.StoragePool.Models.Acl> StaticAcls { get { throw null; } }
    }
    public partial class IscsiTargetUpdateOperation : Azure.Operation<Azure.ResourceManager.StoragePool.IscsiTarget>
    {
        protected IscsiTargetUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.StoragePool.IscsiTarget Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.StoragePool.IscsiTarget>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.StoragePool.Models.ResourceSkuRestrictionsType? Type { get { throw null; } }
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
    public partial class Sku
    {
        public Sku(string name) { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
}
