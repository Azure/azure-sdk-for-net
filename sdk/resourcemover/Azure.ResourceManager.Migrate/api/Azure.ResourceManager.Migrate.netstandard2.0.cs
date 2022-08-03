namespace Azure.ResourceManager.Migrate
{
    public static partial class MigrateExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource> GetMoveCollection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string moveCollectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource>> GetMoveCollectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string moveCollectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migrate.MoveCollectionResource GetMoveCollectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MoveCollectionCollection GetMoveCollections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Migrate.MoveCollectionResource> GetMoveCollections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Migrate.MoveCollectionResource> GetMoveCollectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migrate.MoveResource GetMoveResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Migrate.Models.MoverOperationsDiscovery> GetOperationsDiscoveries(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Migrate.Models.MoverOperationsDiscovery> GetOperationsDiscoveriesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MoveCollectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MoveCollectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MoveCollectionResource>, System.Collections.IEnumerable
    {
        protected MoveCollectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveCollectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string moveCollectionName, Azure.ResourceManager.Migrate.MoveCollectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveCollectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string moveCollectionName, Azure.ResourceManager.Migrate.MoveCollectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string moveCollectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string moveCollectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource> Get(string moveCollectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MoveCollectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MoveCollectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource>> GetAsync(string moveCollectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MoveCollectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MoveCollectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MoveCollectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MoveCollectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MoveCollectionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MoveCollectionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MoveCollectionProperties Properties { get { throw null; } set { } }
    }
    public partial class MoveCollectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MoveCollectionResource() { }
        public virtual Azure.ResourceManager.Migrate.MoveCollectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus> BulkRemove(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverBulkRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus>> BulkRemoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverBulkRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus> Commit(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverCommitContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus>> CommitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverCommitContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string moveCollectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus> Discard(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverDiscardContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus>> DiscardAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverDiscardContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveResource> GetMoveResource(string moveResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveResource>> GetMoveResourceAsync(string moveResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MoveResourceCollection GetMoveResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.Models.RequiredForResourcesList> GetRequiredFor(string sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.RequiredForResourcesList>> GetRequiredForAsync(string sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.Models.MoverUnresolvedDependency> GetUnresolvedDependencies(Azure.ResourceManager.Migrate.Models.MoverDependencyLevel? dependencyLevel = default(Azure.ResourceManager.Migrate.Models.MoverDependencyLevel?), string orderby = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.Models.MoverUnresolvedDependency> GetUnresolvedDependenciesAsync(Azure.ResourceManager.Migrate.Models.MoverDependencyLevel? dependencyLevel = default(Azure.ResourceManager.Migrate.Models.MoverDependencyLevel?), string orderby = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus> InitiateMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverResourceMoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus>> InitiateMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverResourceMoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus> Prepare(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverPrepareContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus>> PrepareAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MoverPrepareContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus> ResolveDependencies(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus>> ResolveDependenciesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource> Update(Azure.ResourceManager.Migrate.Models.MoveCollectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource>> UpdateAsync(Azure.ResourceManager.Migrate.Models.MoveCollectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MoveResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MoveResource() { }
        public virtual Azure.ResourceManager.Migrate.MoveResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string moveCollectionName, string moveResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.MoverOperationStatus>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MoveResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MoveResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MoveResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MoveResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MoveResource>, System.Collections.IEnumerable
    {
        protected MoveResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string moveResourceName, Azure.ResourceManager.Migrate.MoveResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string moveResourceName, Azure.ResourceManager.Migrate.MoveResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string moveResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string moveResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveResource> Get(string moveResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MoveResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MoveResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveResource>> GetAsync(string moveResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MoveResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MoveResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MoveResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MoveResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MoveResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MoveResourceData() { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceProperties Properties { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.Migrate.Models
{
    public partial class DiskEncryptionSetResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public DiskEncryptionSetResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    public partial class KeyVaultResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public KeyVaultResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    public partial class LoadBalancerBackendAddressPoolReferenceInfo : Azure.ResourceManager.Migrate.Models.ProxyResourceReferenceInfo
    {
        public LoadBalancerBackendAddressPoolReferenceInfo(string sourceArmResourceId) : base (default(string)) { }
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
        public string PrivateIPAddress { get { throw null; } set { } }
        public string PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.SubnetReferenceInfo Subnet { get { throw null; } set { } }
        public string Zones { get { throw null; } set { } }
    }
    public partial class LoadBalancerNatRuleReferenceInfo : Azure.ResourceManager.Migrate.Models.ProxyResourceReferenceInfo
    {
        public LoadBalancerNatRuleReferenceInfo(string sourceArmResourceId) : base (default(string)) { }
    }
    public partial class LoadBalancerResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public LoadBalancerResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.LoadBalancerBackendAddressPoolResourceSettings> BackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.LoadBalancerFrontendIPConfigurationResourceSettings> FrontendIPConfigurations { get { throw null; } }
        public string Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Zones { get { throw null; } set { } }
    }
    public partial class MoveCollectionPatch
    {
        public MoveCollectionPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MoveCollectionProperties
    {
        public MoveCollectionProperties(string sourceRegion, string targetRegion) { }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoverProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceRegion { get { throw null; } set { } }
        public string TargetRegion { get { throw null; } set { } }
    }
    public partial class MoverAffectedMoveResourceInfo
    {
        internal MoverAffectedMoveResourceInfo() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MoverAffectedMoveResourceInfo> MoveResources { get { throw null; } }
        public string SourceId { get { throw null; } }
    }
    public partial class MoverAvailabilitySetResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public MoverAvailabilitySetResourceSettings(string targetResourceName) : base (default(string)) { }
        public int? FaultDomain { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? UpdateDomain { get { throw null; } set { } }
    }
    public partial class MoverAzureResourceReferenceInfo
    {
        public MoverAzureResourceReferenceInfo(string sourceArmResourceId) { }
        public string SourceArmResourceId { get { throw null; } set { } }
    }
    public partial class MoverBulkRemoveContent
    {
        public MoverBulkRemoveContent() { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    public partial class MoverCommitContent
    {
        public MoverCommitContent(System.Collections.Generic.IEnumerable<string> moveResources) { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverDependencyLevel : System.IEquatable<Azure.ResourceManager.Migrate.Models.MoverDependencyLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverDependencyLevel(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MoverDependencyLevel Descendant { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoverDependencyLevel Direct { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MoverDependencyLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MoverDependencyLevel left, Azure.ResourceManager.Migrate.Models.MoverDependencyLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MoverDependencyLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MoverDependencyLevel left, Azure.ResourceManager.Migrate.Models.MoverDependencyLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverDependencyType : System.IEquatable<Azure.ResourceManager.Migrate.Models.MoverDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MoverDependencyType RequiredForMove { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoverDependencyType RequiredForPrepare { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MoverDependencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MoverDependencyType left, Azure.ResourceManager.Migrate.Models.MoverDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MoverDependencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MoverDependencyType left, Azure.ResourceManager.Migrate.Models.MoverDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverDiscardContent
    {
        public MoverDiscardContent(System.Collections.Generic.IEnumerable<string> moveResources) { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
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
    public partial class MoveResourceDependency
    {
        internal MoveResourceDependency() { }
        public string AutomaticResolutionMoveResourceId { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoverDependencyType? DependencyType { get { throw null; } }
        public string Id { get { throw null; } }
        public string IsOptional { get { throw null; } }
        public string ManualResolutionTargetId { get { throw null; } }
        public string ResolutionStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType? ResolutionType { get { throw null; } }
    }
    public partial class MoveResourceDependencyOverride
    {
        public MoveResourceDependencyOverride() { }
        public string Id { get { throw null; } set { } }
        public string TargetId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoveResourceInputType : System.IEquatable<Azure.ResourceManager.Migrate.Models.MoveResourceInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoveResourceInputType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceInputType MoveResourceId { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceInputType MoveResourceSourceId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MoveResourceInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MoveResourceInputType left, Azure.ResourceManager.Migrate.Models.MoveResourceInputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MoveResourceInputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MoveResourceInputType left, Azure.ResourceManager.Migrate.Models.MoveResourceInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoveResourceJobName : System.IEquatable<Azure.ResourceManager.Migrate.Models.MoveResourceJobName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoveResourceJobName(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceJobName InitialSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MoveResourceJobName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MoveResourceJobName left, Azure.ResourceManager.Migrate.Models.MoveResourceJobName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MoveResourceJobName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MoveResourceJobName left, Azure.ResourceManager.Migrate.Models.MoveResourceJobName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoveResourceJobStatus
    {
        internal MoveResourceJobStatus() { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceJobName? JobName { get { throw null; } }
        public string JobProgress { get { throw null; } }
    }
    public partial class MoveResourceProperties
    {
        public MoveResourceProperties(string sourceId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MoveResourceDependency> DependsOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.MoveResourceDependencyOverride> DependsOnOverrides { get { throw null; } }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public string ExistingTargetId { get { throw null; } set { } }
        public bool? IsResolveRequired { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoveResourcePropertiesMoveStatus MoveStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoverProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoverResourceSettings ResourceSettings { get { throw null; } set { } }
        public string SourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MoverResourceSettings SourceResourceSettings { get { throw null; } }
        public string TargetId { get { throw null; } }
    }
    public partial class MoveResourcePropertiesMoveStatus : Azure.ResourceManager.Migrate.Models.MoveResourceStatus
    {
        internal MoveResourcePropertiesMoveStatus() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoveResourceResolutionType : System.IEquatable<Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoveResourceResolutionType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType left, Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType left, Azure.ResourceManager.Migrate.Models.MoveResourceResolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoveResourceState : System.IEquatable<Azure.ResourceManager.Migrate.Models.MoveResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoveResourceState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState AssignmentPending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState CommitFailed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState CommitInProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState CommitPending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState Committed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState DeleteSourcePending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState DiscardFailed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState DiscardInProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState MoveFailed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState MoveInProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState MovePending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState PrepareFailed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState PrepareInProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState PreparePending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveResourceState ResourceMoveCompleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MoveResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MoveResourceState left, Azure.ResourceManager.Migrate.Models.MoveResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MoveResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MoveResourceState left, Azure.ResourceManager.Migrate.Models.MoveResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoveResourceStatus
    {
        internal MoveResourceStatus() { }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoveResourceJobStatus JobStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoveResourceState? MoveState { get { throw null; } }
    }
    public partial class MoverOperationErrorAdditionalInfo
    {
        internal MoverOperationErrorAdditionalInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MoverAffectedMoveResourceInfo> InfoMoveResources { get { throw null; } }
        public string OperationErrorAdditionalInfoType { get { throw null; } }
    }
    public partial class MoverOperationsDiscovery
    {
        internal MoverOperationsDiscovery() { }
        public Azure.ResourceManager.Migrate.Models.MoverDisplayInfo Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
    }
    public partial class MoverOperationStatus
    {
        internal MoverOperationStatus() { }
        public string EndTime { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoverOperationStatusError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class MoverOperationStatusError
    {
        internal MoverOperationStatusError() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MoverOperationErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MoverOperationStatusError> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class MoverPrepareContent
    {
        public MoverPrepareContent(System.Collections.Generic.IEnumerable<string> moveResources) { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverProvisioningState : System.IEquatable<Azure.ResourceManager.Migrate.Models.MoverProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MoverProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoverProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoverProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoverProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MoverProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MoverProvisioningState left, Azure.ResourceManager.Migrate.Models.MoverProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MoverProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MoverProvisioningState left, Azure.ResourceManager.Migrate.Models.MoverProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverResourceMoveContent
    {
        public MoverResourceMoveContent(System.Collections.Generic.IEnumerable<string> moveResources) { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    public partial class MoverResourceSettings
    {
        public MoverResourceSettings(string targetResourceName) { }
        public string TargetResourceName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoverTargetAvailabilityZone : System.IEquatable<Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoverTargetAvailabilityZone(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone NA { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone One { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone Three { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone Two { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone left, Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone left, Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoverUnresolvedDependency
    {
        internal MoverUnresolvedDependency() { }
        public int? Count { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class NetworkInterfaceResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public NetworkInterfaceResourceSettings(string targetResourceName) : base (default(string)) { }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.NicIPConfigurationResourceSettings> IPConfigurations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkSecurityGroupResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public NetworkSecurityGroupResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.NetworkSecurityGroupSecurityRule> SecurityRules { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.LoadBalancerBackendAddressPoolReferenceInfo> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.LoadBalancerNatRuleReferenceInfo> LoadBalancerNatRules { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public string PrivateIPAllocationMethod { get { throw null; } set { } }
        public string PublicIPSourceArmResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.SubnetReferenceInfo Subnet { get { throw null; } set { } }
    }
    public partial class ProxyResourceReferenceInfo : Azure.ResourceManager.Migrate.Models.MoverAzureResourceReferenceInfo
    {
        public ProxyResourceReferenceInfo(string sourceArmResourceId) : base (default(string)) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class PublicIPAddressResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
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
    public partial class ResourceGroupResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public ResourceGroupResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceZoneRedundantSetting : System.IEquatable<Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceZoneRedundantSetting(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting Disable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting left, Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting left, Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlDatabaseResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public SqlDatabaseResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class SqlElasticPoolResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public SqlElasticPoolResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ResourceZoneRedundantSetting? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class SqlServerResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public SqlServerResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    public partial class SubnetReferenceInfo : Azure.ResourceManager.Migrate.Models.ProxyResourceReferenceInfo
    {
        public SubnetReferenceInfo(string sourceArmResourceId) : base (default(string)) { }
    }
    public partial class SubnetResourceSettings
    {
        public SubnetResourceSettings() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NetworkSecurityGroupSourceArmResourceId { get { throw null; } set { } }
    }
    public partial class VirtualMachineResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public VirtualMachineResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetAvailabilitySetId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MoverTargetAvailabilityZone? TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> UserManagedIdentities { get { throw null; } }
    }
    public partial class VirtualNetworkResourceSettings : Azure.ResourceManager.Migrate.Models.MoverResourceSettings
    {
        public VirtualNetworkResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IList<string> AddressSpace { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableDdosProtection { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.SubnetResourceSettings> Subnets { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
