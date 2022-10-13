namespace Azure.ResourceManager.ResourceMover
{
    public partial class MoverResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MoverResource() { }
        public virtual Azure.ResourceManager.ResourceMover.MoverResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string moverResourceSetName, string moverResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.MoverResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.MoverResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MoverResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceMover.MoverResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.MoverResource>, System.Collections.IEnumerable
    {
        protected MoverResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string moverResourceName, Azure.ResourceManager.ResourceMover.MoverResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string moverResourceName, Azure.ResourceManager.ResourceMover.MoverResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource> Get(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceMover.MoverResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.MoverResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource>> GetAsync(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceMover.MoverResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceMover.MoverResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceMover.MoverResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.MoverResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MoverResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MoverResourceData() { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class MoverResourceSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>, System.Collections.IEnumerable
    {
        protected MoverResourceSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string moverResourceSetName, Azure.ResourceManager.ResourceMover.MoverResourceSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string moverResourceSetName, Azure.ResourceManager.ResourceMover.MoverResourceSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> Get(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> GetAsync(string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MoverResourceSetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MoverResourceSetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceSetProperties Properties { get { throw null; } set { } }
    }
    public partial class MoverResourceSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MoverResourceSetResource() { }
        public virtual Azure.ResourceManager.ResourceMover.MoverResourceSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> BulkRemove(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> BulkRemoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverBulkRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> Commit(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverCommitContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> CommitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverCommitContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string moverResourceSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> Discard(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> DiscardAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverDiscardContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource> GetMoverResource(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResource>> GetMoverResourceAsync(string moverResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceMover.MoverResourceCollection GetMoverResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList> GetRequiredForResources(Azure.Core.ResourceIdentifier sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.Models.RequiredForResourcesList>> GetRequiredForResourcesAsync(Azure.Core.ResourceIdentifier sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency> GetUnresolvedDependencies(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel? dependencyLevel = default(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel?), string orderby = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.Models.MoverUnresolvedDependency> GetUnresolvedDependenciesAsync(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel? dependencyLevel = default(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel?), string orderby = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> InitiateMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> InitiateMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> Prepare(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> PrepareAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceMover.Models.MoverPrepareContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus> ResolveDependencies(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatus>> ResolveDependenciesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> Update(Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> UpdateAsync(Azure.ResourceManager.ResourceMover.Models.MoverResourceSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourceMoverExtensions
    {
        public static Azure.ResourceManager.ResourceMover.MoverResource GetMoverResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetMoverResourceSet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceMover.MoverResourceSetResource>> GetMoverResourceSetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string moverResourceSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceMover.MoverResourceSetResource GetMoverResourceSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceMover.MoverResourceSetCollection GetMoverResourceSets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetMoverResourceSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.MoverResourceSetResource> GetMoverResourceSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery> GetOperationsDiscoveries(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceMover.Models.MoverOperationsDiscovery> GetOperationsDiscoveriesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceMover.Models
{
    public partial class AffectedMoverResourceInfo
    {
        internal AffectedMoverResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo> MoverResources { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } }
    }
    public partial class DiskEncryptionSetResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public DiskEncryptionSetResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    public partial class KeyVaultResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public KeyVaultResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    public partial class LoadBalancerBackendAddressPoolReferenceInfo : Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo
    {
        public LoadBalancerBackendAddressPoolReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) : base (default(Azure.Core.ResourceIdentifier)) { }
    }
    public partial class LoadBalancerBackendAddressPoolResourceSettings
    {
        public LoadBalancerBackendAddressPoolResourceSettings() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class LoadBalancerFrontendIPConfigurationResourceSettings
    {
        public LoadBalancerFrontendIPConfigurationResourceSettings() { }
        public string Name { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public string PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo Subnet { get { throw null; } set { } }
        public string Zones { get { throw null; } set { } }
    }
    public partial class LoadBalancerNatRuleReferenceInfo : Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo
    {
        public LoadBalancerNatRuleReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) : base (default(Azure.Core.ResourceIdentifier)) { }
    }
    public partial class LoadBalancerResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public LoadBalancerResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolResourceSettings> BackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.LoadBalancerFrontendIPConfigurationResourceSettings> FrontendIPConfigurations { get { throw null; } }
        public string Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Zones { get { throw null; } set { } }
    }
    public partial class MoverAvailabilitySetResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public MoverAvailabilitySetResourceSettings(string targetResourceName) : base (default(string)) { }
        public int? FaultDomain { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? UpdateDomain { get { throw null; } set { } }
    }
    public partial class MoverBulkRemoveContent
    {
        public MoverBulkRemoveContent() { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    public partial class MoverCommitContent
    {
        public MoverCommitContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> moverResources) { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverDependencyLevel : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverDependencyLevel(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel Descendant { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel Direct { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel left, Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel left, Azure.ResourceManager.ResourceMover.Models.MoverDependencyLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverDependencyType : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverDependencyType RequiredForMove { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverDependencyType RequiredForPrepare { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverDependencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverDependencyType left, Azure.ResourceManager.ResourceMover.Models.MoverDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverDependencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverDependencyType left, Azure.ResourceManager.ResourceMover.Models.MoverDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverDiscardContent
    {
        public MoverDiscardContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> moverResources) { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    public partial class MoverDisplayInfo
    {
        internal MoverDisplayInfo() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class MoverOperationErrorAdditionalInfo
    {
        internal MoverOperationErrorAdditionalInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.AffectedMoverResourceInfo> InfoMoverResources { get { throw null; } }
        public string OperationErrorAdditionalInfoType { get { throw null; } }
    }
    public partial class MoverOperationsDiscovery
    {
        internal MoverOperationsDiscovery() { }
        public Azure.ResourceManager.ResourceMover.Models.MoverDisplayInfo Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
    }
    public partial class MoverOperationStatus
    {
        internal MoverOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class MoverOperationStatusError
    {
        internal MoverOperationStatusError() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.MoverOperationErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.MoverOperationStatusError> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class MoverPrepareContent
    {
        public MoverPrepareContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> moverResources) { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverProvisioningState : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState left, Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState left, Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverResourceDependency
    {
        internal MoverResourceDependency() { }
        public Azure.Core.ResourceIdentifier AutomaticResolutionResourceId { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverDependencyType? DependencyType { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool? IsOptional { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManualResolutionTargetId { get { throw null; } }
        public string ResolutionStatus { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType? ResolutionType { get { throw null; } }
    }
    public partial class MoverResourceDependencyOverride
    {
        public MoverResourceDependencyOverride() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverResourceInputType : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverResourceInputType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType MoverResourceId { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType MoverResourceSourceId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType left, Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType left, Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverResourceJobName : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverResourceJobName(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName InitialSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName left, Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName left, Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverResourceJobStatus
    {
        internal MoverResourceJobStatus() { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceJobName? JobName { get { throw null; } }
        public string JobProgress { get { throw null; } }
    }
    public partial class MoverResourceMoveContent
    {
        public MoverResourceMoveContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> moverResources) { }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceInputType? MoverResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MoverResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverResourceMoveState : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverResourceMoveState(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState AssignmentPending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState CommitFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState CommitInProgress { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState CommitPending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState Committed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState DeleteSourcePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState DiscardFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState DiscardInProgress { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState MoveFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState MoveInProgress { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState MovePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState PrepareFailed { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState PrepareInProgress { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState PreparePending { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState ResourceMoveCompleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState left, Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState left, Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverResourceProperties
    {
        public MoverResourceProperties(Azure.Core.ResourceIdentifier sourceId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependency> DependsOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.MoverResourceDependencyOverride> DependsOnOverrides { get { throw null; } }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier ExistingTargetId { get { throw null; } set { } }
        public bool? IsResolveRequired { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourcePropertiesMoveStatus MoveStatus { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings ResourceSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings SourceResourceSettings { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } }
    }
    public partial class MoverResourcePropertiesMoveStatus : Azure.ResourceManager.ResourceMover.Models.MoverResourceStatus
    {
        internal MoverResourcePropertiesMoveStatus() { }
    }
    public partial class MoverResourceReferenceInfo
    {
        public MoverResourceReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) { }
        public Azure.Core.ResourceIdentifier SourceArmResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverResourceResolutionType : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverResourceResolutionType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType Automatic { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType left, Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType left, Azure.ResourceManager.ResourceMover.Models.MoverResourceResolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverResourceSetPatch
    {
        public MoverResourceSetPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MoverResourceSetProperties
    {
        public MoverResourceSetProperties(Azure.Core.AzureLocation sourceRegion, Azure.Core.AzureLocation targetRegion) { }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.AzureLocation SourceRegion { get { throw null; } set { } }
        public Azure.Core.AzureLocation TargetRegion { get { throw null; } set { } }
    }
    public abstract partial class MoverResourceSettings
    {
        protected MoverResourceSettings(string targetResourceName) { }
        public string TargetResourceName { get { throw null; } set { } }
    }
    public partial class MoverResourceStatus
    {
        internal MoverResourceStatus() { }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceJobStatus JobStatus { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.MoverResourceMoveState? MoveState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverTargetAvailabilityZone : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverTargetAvailabilityZone(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone NA { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone One { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone Three { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone Two { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone left, Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone left, Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverUnresolvedDependency
    {
        internal MoverUnresolvedDependency() { }
        public int? Count { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
    }
    public partial class MoverVirtualNetworkResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public MoverVirtualNetworkResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IList<string> AddressSpace { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } set { } }
        public bool? EnableDdosProtection { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.SubnetResourceSettings> Subnets { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class NetworkInterfaceResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public NetworkInterfaceResourceSettings(string targetResourceName) : base (default(string)) { }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.NicIPConfigurationResourceSettings> IPConfigurations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkSecurityGroupResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public NetworkSecurityGroupResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.NetworkSecurityGroupSecurityRule> SecurityRules { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkSecurityGroupSecurityRule
    {
        public NetworkSecurityGroupSecurityRule() { }
        public string Access { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DestinationAddressPrefix { get { throw null; } set { } }
        public string DestinationPortRange { get { throw null; } set { } }
        public string Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public string SourcePortRange { get { throw null; } set { } }
    }
    public partial class NicIPConfigurationResourceSettings
    {
        public NicIPConfigurationResourceSettings() { }
        public bool? IsPrimary { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.LoadBalancerBackendAddressPoolReferenceInfo> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceMover.Models.LoadBalancerNatRuleReferenceInfo> LoadBalancerNatRules { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public string PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPSourceArmResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.SubnetReferenceInfo Subnet { get { throw null; } set { } }
    }
    public partial class ProxyResourceReferenceInfo : Azure.ResourceManager.ResourceMover.Models.MoverResourceReferenceInfo
    {
        public ProxyResourceReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) : base (default(Azure.Core.ResourceIdentifier)) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class PublicIPAddressResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public PublicIPAddressResourceSettings(string targetResourceName) : base (default(string)) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        public string PublicIPAllocationMethod { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Zones { get { throw null; } set { } }
    }
    public partial class RequiredForResourcesList
    {
        internal RequiredForResourcesList() { }
        public System.Collections.Generic.IReadOnlyList<string> SourceIds { get { throw null; } }
    }
    public partial class ResourceGroupResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public ResourceGroupResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceZoneRedundantSetting : System.IEquatable<Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceZoneRedundantSetting(string value) { throw null; }
        public static Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting Disable { get { throw null; } }
        public static Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting left, Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting left, Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlDatabaseResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public SqlDatabaseResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class SqlElasticPoolResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public SqlElasticPoolResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ResourceMover.Models.ResourceZoneRedundantSetting? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class SqlServerResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public SqlServerResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    public partial class SubnetReferenceInfo : Azure.ResourceManager.ResourceMover.Models.ProxyResourceReferenceInfo
    {
        public SubnetReferenceInfo(Azure.Core.ResourceIdentifier sourceArmResourceId) : base (default(Azure.Core.ResourceIdentifier)) { }
    }
    public partial class SubnetResourceSettings
    {
        public SubnetResourceSettings() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupSourceArmResourceId { get { throw null; } set { } }
    }
    public partial class VirtualMachineResourceSettings : Azure.ResourceManager.ResourceMover.Models.MoverResourceSettings
    {
        public VirtualMachineResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetAvailabilitySetId { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceMover.Models.MoverTargetAvailabilityZone? TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> UserManagedIdentities { get { throw null; } }
    }
}
