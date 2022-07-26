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
        public static Azure.Pageable<Azure.ResourceManager.Migrate.Models.OperationsDiscovery> GetOperationsDiscoveries(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Migrate.Models.OperationsDiscovery> GetOperationsDiscoveriesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MoveCollectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MoveCollectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MoveCollectionResource>, System.Collections.IEnumerable
    {
        protected MoveCollectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveCollectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string moveCollectionName, Azure.ResourceManager.Migrate.MoveCollectionData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveCollectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string moveCollectionName, Azure.ResourceManager.Migrate.MoveCollectionData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Migrate.Models.Identity Identity { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus> BulkRemove(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.BulkRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus>> BulkRemoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.BulkRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus> Commit(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.CommitContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus>> CommitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.CommitContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string moveCollectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus> Discard(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.DiscardContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus>> DiscardAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.DiscardContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveResource> GetMoveResource(string moveResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveResource>> GetMoveResourceAsync(string moveResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MoveResourceCollection GetMoveResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.Models.RequiredForResourcesCollection> GetRequiredFor(string sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.RequiredForResourcesCollection>> GetRequiredForAsync(string sourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.Models.UnresolvedDependency> GetUnresolvedDependencies(Azure.ResourceManager.Migrate.Models.DependencyLevel? dependencyLevel = default(Azure.ResourceManager.Migrate.Models.DependencyLevel?), string orderby = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.Models.UnresolvedDependency> GetUnresolvedDependenciesAsync(Azure.ResourceManager.Migrate.Models.DependencyLevel? dependencyLevel = default(Azure.ResourceManager.Migrate.Models.DependencyLevel?), string orderby = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus> InitiateMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.ResourceMoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus>> InitiateMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.ResourceMoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus> Prepare(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.PrepareContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus>> PrepareAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.PrepareContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveCollectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus> ResolveDependencies(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus>> ResolveDependenciesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.OperationStatus>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MoveResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MoveResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MoveResourceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MoveResourceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MoveResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MoveResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MoveResource>, System.Collections.IEnumerable
    {
        protected MoveResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string moveResourceName, Azure.ResourceManager.Migrate.MoveResourceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MoveResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string moveResourceName, Azure.ResourceManager.Migrate.MoveResourceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AffectedMoveResource
    {
        internal AffectedMoveResource() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AffectedMoveResource> MoveResources { get { throw null; } }
        public string SourceId { get { throw null; } }
    }
    public partial class AvailabilitySetResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public AvailabilitySetResourceSettings(string targetResourceName) : base (default(string)) { }
        public int? FaultDomain { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? UpdateDomain { get { throw null; } set { } }
    }
    public partial class AzureResourceReference
    {
        public AzureResourceReference(string sourceArmResourceId) { }
        public string SourceArmResourceId { get { throw null; } set { } }
    }
    public partial class BulkRemoveContent
    {
        public BulkRemoveContent() { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    public partial class CommitContent
    {
        public CommitContent(System.Collections.Generic.IEnumerable<string> moveResources) { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependencyLevel : System.IEquatable<Azure.ResourceManager.Migrate.Models.DependencyLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependencyLevel(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.DependencyLevel Descendant { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.DependencyLevel Direct { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.DependencyLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.DependencyLevel left, Azure.ResourceManager.Migrate.Models.DependencyLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.DependencyLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.DependencyLevel left, Azure.ResourceManager.Migrate.Models.DependencyLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DependencyType : System.IEquatable<Azure.ResourceManager.Migrate.Models.DependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DependencyType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.DependencyType RequiredForMove { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.DependencyType RequiredForPrepare { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.DependencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.DependencyType left, Azure.ResourceManager.Migrate.Models.DependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.DependencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.DependencyType left, Azure.ResourceManager.Migrate.Models.DependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscardContent
    {
        public DiscardContent(System.Collections.Generic.IEnumerable<string> moveResources) { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    public partial class DiskEncryptionSetResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public DiskEncryptionSetResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    public partial class Display
    {
        internal Display() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class Identity
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.ResourceIdentityType? ResourceIdentityType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobName : System.IEquatable<Azure.ResourceManager.Migrate.Models.JobName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobName(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.JobName InitialSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.JobName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.JobName left, Azure.ResourceManager.Migrate.Models.JobName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.JobName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.JobName left, Azure.ResourceManager.Migrate.Models.JobName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobStatus
    {
        internal JobStatus() { }
        public Azure.ResourceManager.Migrate.Models.JobName? JobName { get { throw null; } }
        public string JobProgress { get { throw null; } }
    }
    public partial class KeyVaultResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public KeyVaultResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    public partial class LBBackendAddressPoolResourceSettings
    {
        public LBBackendAddressPoolResourceSettings() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class LBFrontendIPConfigurationResourceSettings
    {
        public LBFrontendIPConfigurationResourceSettings() { }
        public string Name { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public string PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.SubnetReference Subnet { get { throw null; } set { } }
        public string Zones { get { throw null; } set { } }
    }
    public partial class LoadBalancerBackendAddressPoolReference : Azure.ResourceManager.Migrate.Models.ProxyResourceReference
    {
        public LoadBalancerBackendAddressPoolReference(string sourceArmResourceId) : base (default(string)) { }
    }
    public partial class LoadBalancerNatRuleReference : Azure.ResourceManager.Migrate.Models.ProxyResourceReference
    {
        public LoadBalancerNatRuleReference(string sourceArmResourceId) : base (default(string)) { }
    }
    public partial class LoadBalancerResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public LoadBalancerResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.LBBackendAddressPoolResourceSettings> BackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.LBFrontendIPConfigurationResourceSettings> FrontendIPConfigurations { get { throw null; } }
        public string Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Zones { get { throw null; } set { } }
    }
    public partial class MoveCollectionPatch
    {
        public MoveCollectionPatch() { }
        public Azure.ResourceManager.Migrate.Models.Identity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MoveCollectionProperties
    {
        public MoveCollectionProperties(string sourceRegion, string targetRegion) { }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceRegion { get { throw null; } set { } }
        public string TargetRegion { get { throw null; } set { } }
    }
    public partial class MoveResourceDependency
    {
        internal MoveResourceDependency() { }
        public string AutomaticResolutionMoveResourceId { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.DependencyType? DependencyType { get { throw null; } }
        public string Id { get { throw null; } }
        public string IsOptional { get { throw null; } }
        public string ManualResolutionTargetId { get { throw null; } }
        public string ResolutionStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ResolutionType? ResolutionType { get { throw null; } }
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
    public partial class MoveResourceProperties
    {
        public MoveResourceProperties(string sourceId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MoveResourceDependency> DependsOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.MoveResourceDependencyOverride> DependsOnOverrides { get { throw null; } }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public string ExistingTargetId { get { throw null; } set { } }
        public bool? IsResolveRequired { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoveResourcePropertiesMoveStatus MoveStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ResourceSettings ResourceSettings { get { throw null; } set { } }
        public string SourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.ResourceSettings SourceResourceSettings { get { throw null; } }
        public string TargetId { get { throw null; } }
    }
    public partial class MoveResourcePropertiesMoveStatus : Azure.ResourceManager.Migrate.Models.MoveResourceStatus
    {
        internal MoveResourcePropertiesMoveStatus() { }
    }
    public partial class MoveResourceStatus
    {
        internal MoveResourceStatus() { }
        public Azure.ResponseError ErrorsProperties { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.JobStatus JobStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MoveState? MoveState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MoveState : System.IEquatable<Azure.ResourceManager.Migrate.Models.MoveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MoveState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MoveState AssignmentPending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState CommitFailed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState CommitInProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState CommitPending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState Committed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState DeleteSourcePending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState DiscardFailed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState DiscardInProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState MoveFailed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState MoveInProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState MovePending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState PrepareFailed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState PrepareInProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState PreparePending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MoveState ResourceMoveCompleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MoveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MoveState left, Azure.ResourceManager.Migrate.Models.MoveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MoveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MoveState left, Azure.ResourceManager.Migrate.Models.MoveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterfaceResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public NetworkInterfaceResourceSettings(string targetResourceName) : base (default(string)) { }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.NicIPConfigurationResourceSettings> IPConfigurations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkSecurityGroupResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public NetworkSecurityGroupResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.NsgSecurityRule> SecurityRules { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NicIPConfigurationResourceSettings
    {
        public NicIPConfigurationResourceSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.LoadBalancerBackendAddressPoolReference> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.LoadBalancerNatRuleReference> LoadBalancerNatRules { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public string PrivateIPAllocationMethod { get { throw null; } set { } }
        public string PublicIPSourceArmResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.SubnetReference Subnet { get { throw null; } set { } }
    }
    public partial class NsgSecurityRule
    {
        public NsgSecurityRule() { }
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
    public partial class OperationErrorAdditionalInfo
    {
        internal OperationErrorAdditionalInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AffectedMoveResource> InfoMoveResources { get { throw null; } }
        public string OperationErrorAdditionalInfoType { get { throw null; } }
    }
    public partial class OperationsDiscovery
    {
        internal OperationsDiscovery() { }
        public Azure.ResourceManager.Migrate.Models.Display Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
    }
    public partial class OperationStatus
    {
        internal OperationStatus() { }
        public string EndTime { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.OperationStatusError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class OperationStatusError
    {
        internal OperationStatusError() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.OperationErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.OperationStatusError> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class PrepareContent
    {
        public PrepareContent(System.Collections.Generic.IEnumerable<string> moveResources) { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Migrate.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.ProvisioningState left, Azure.ResourceManager.Migrate.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.ProvisioningState left, Azure.ResourceManager.Migrate.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyResourceReference : Azure.ResourceManager.Migrate.Models.AzureResourceReference
    {
        public ProxyResourceReference(string sourceArmResourceId) : base (default(string)) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class PublicIPAddressResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public PublicIPAddressResourceSettings(string targetResourceName) : base (default(string)) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        public string PublicIPAllocationMethod { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Zones { get { throw null; } set { } }
    }
    public partial class RequiredForResourcesCollection
    {
        internal RequiredForResourcesCollection() { }
        public System.Collections.Generic.IReadOnlyList<string> SourceIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResolutionType : System.IEquatable<Azure.ResourceManager.Migrate.Models.ResolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResolutionType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ResolutionType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ResolutionType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.ResolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.ResolutionType left, Azure.ResourceManager.Migrate.Models.ResolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.ResolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.ResolutionType left, Azure.ResourceManager.Migrate.Models.ResolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGroupResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public ResourceGroupResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceIdentityType : System.IEquatable<Azure.ResourceManager.Migrate.Models.ResourceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ResourceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ResourceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ResourceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.ResourceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.ResourceIdentityType left, Azure.ResourceManager.Migrate.Models.ResourceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.ResourceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.ResourceIdentityType left, Azure.ResourceManager.Migrate.Models.ResourceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceMoveContent
    {
        public ResourceMoveContent(System.Collections.Generic.IEnumerable<string> moveResources) { }
        public Azure.ResourceManager.Migrate.Models.MoveResourceInputType? MoveResourceInputType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MoveResources { get { throw null; } }
        public bool? ValidateOnly { get { throw null; } set { } }
    }
    public partial class ResourceSettings
    {
        public ResourceSettings(string targetResourceName) { }
        public string TargetResourceName { get { throw null; } set { } }
    }
    public partial class SqlDatabaseResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public SqlDatabaseResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ZoneRedundant? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class SqlElasticPoolResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public SqlElasticPoolResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ZoneRedundant? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class SqlServerResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public SqlServerResourceSettings(string targetResourceName) : base (default(string)) { }
    }
    public partial class SubnetReference : Azure.ResourceManager.Migrate.Models.ProxyResourceReference
    {
        public SubnetReference(string sourceArmResourceId) : base (default(string)) { }
    }
    public partial class SubnetResourceSettings
    {
        public SubnetResourceSettings() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NetworkSecurityGroupSourceArmResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetAvailabilityZone : System.IEquatable<Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetAvailabilityZone(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone NA { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone One { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone Three { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone Two { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone left, Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone left, Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UnresolvedDependency
    {
        internal UnresolvedDependency() { }
        public int? Count { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class VirtualMachineResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public VirtualMachineResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetAvailabilitySetId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.TargetAvailabilityZone? TargetAvailabilityZone { get { throw null; } set { } }
        public string TargetVmSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> UserManagedIdentities { get { throw null; } }
    }
    public partial class VirtualNetworkResourceSettings : Azure.ResourceManager.Migrate.Models.ResourceSettings
    {
        public VirtualNetworkResourceSettings(string targetResourceName) : base (default(string)) { }
        public System.Collections.Generic.IList<string> AddressSpace { get { throw null; } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableDdosProtection { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.SubnetResourceSettings> Subnets { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneRedundant : System.IEquatable<Azure.ResourceManager.Migrate.Models.ZoneRedundant>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneRedundant(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ZoneRedundant Disable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ZoneRedundant Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.ZoneRedundant other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.ZoneRedundant left, Azure.ResourceManager.Migrate.Models.ZoneRedundant right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.ZoneRedundant (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.ZoneRedundant left, Azure.ResourceManager.Migrate.Models.ZoneRedundant right) { throw null; }
        public override string ToString() { throw null; }
    }
}
