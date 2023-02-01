namespace Azure.ResourceManager.LoadTesting
{
    public static partial class LoadTestingExtensions
    {
        public static Azure.ResourceManager.LoadTesting.LoadTestingQuotaCollection GetAllLoadTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> GetLoadTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>> GetLoadTestingQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource GetLoadTestingQuotaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestingResource GetLoadTestingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetLoadTestingResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> GetLoadTestingResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LoadTesting.LoadTestingResourceCollection GetLoadTestingResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetLoadTestingResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetLoadTestingResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestingQuotaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>, System.Collections.IEnumerable
    {
        protected LoadTestingQuotaCollection() { }
        public virtual Azure.Response<bool> Exists(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> Get(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>> GetAsync(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoadTestingQuotaData : Azure.ResourceManager.Models.ResourceData
    {
        public LoadTestingQuotaData() { }
        public int? Limit { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState? ProvisioningState { get { throw null; } }
        public int? Usage { get { throw null; } set { } }
    }
    public partial class LoadTestingQuotaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoadTestingQuotaResource() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingQuotaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult> CheckLoadTestingQuotaAvailability(Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaAvailabilityResult>> CheckLoadTestingQuotaAvailabilityAsync(Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string quotaBucketName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingQuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoadTestingResource() { }
        public virtual Azure.ResourceManager.LoadTesting.LoadTestingResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string loadTestName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.Models.LoadTestingOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LoadTesting.Models.LoadTestingResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestingResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingResource>, System.Collections.IEnumerable
    {
        protected LoadTestingResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loadTestName, Azure.ResourceManager.LoadTesting.LoadTestingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTesting.LoadTestingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loadTestName, Azure.ResourceManager.LoadTesting.LoadTestingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource> Get(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTesting.LoadTestingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTesting.LoadTestingResource>> GetAsync(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LoadTesting.LoadTestingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LoadTesting.LoadTestingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTesting.LoadTestingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoadTestingResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LoadTestingResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DataPlaneUri { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState? ProvisioningState { get { throw null; } }
    }
}
namespace Azure.ResourceManager.LoadTesting.Models
{
    public partial class LoadTestingCmkEncryptionProperties
    {
        public LoadTestingCmkEncryptionProperties() { }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentity Identity { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
    }
    public partial class LoadTestingCmkIdentity
    {
        public LoadTestingCmkIdentity() { }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadTestingCmkIdentityType : System.IEquatable<Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadTestingCmkIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType left, Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType left, Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadTestingEndpointDependency
    {
        internal LoadTestingEndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class LoadTestingEndpointDetail
    {
        internal LoadTestingEndpointDetail() { }
        public int? Port { get { throw null; } }
    }
    public partial class LoadTestingOutboundEnvironmentEndpoint
    {
        internal LoadTestingOutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LoadTesting.Models.LoadTestingEndpointDependency> Endpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoadTestingProvisioningState : System.IEquatable<Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoadTestingProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState left, Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState left, Azure.ResourceManager.LoadTesting.Models.LoadTestingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadTestingQuotaAvailabilityResult : Azure.ResourceManager.Models.ResourceData
    {
        public LoadTestingQuotaAvailabilityResult() { }
        public string AvailabilityStatus { get { throw null; } set { } }
        public bool? IsAvailable { get { throw null; } set { } }
    }
    public partial class LoadTestingQuotaBucketContent : Azure.ResourceManager.Models.ResourceData
    {
        public LoadTestingQuotaBucketContent() { }
        public int? CurrentQuota { get { throw null; } set { } }
        public int? CurrentUsage { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingQuotaBucketDimensions Dimensions { get { throw null; } set { } }
        public int? NewQuota { get { throw null; } set { } }
    }
    public partial class LoadTestingQuotaBucketDimensions
    {
        public LoadTestingQuotaBucketDimensions() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class LoadTestingResourcePatch
    {
        public LoadTestingResourcePatch() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTesting.Models.LoadTestingCmkEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
}
