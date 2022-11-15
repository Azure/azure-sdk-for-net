namespace Azure.ResourceManager.LoadTestService
{
    public partial class LoadTestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoadTestResource() { }
        public virtual Azure.ResourceManager.LoadTestService.LoadTestResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string loadTestName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTestService.LoadTestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTestService.LoadTestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTestService.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTestService.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTestService.LoadTestResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.LoadTestService.Models.LoadTestResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTestService.LoadTestResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LoadTestService.Models.LoadTestResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTestService.LoadTestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTestService.LoadTestResource>, System.Collections.IEnumerable
    {
        protected LoadTestResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTestService.LoadTestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loadTestName, Azure.ResourceManager.LoadTestService.LoadTestResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LoadTestService.LoadTestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loadTestName, Azure.ResourceManager.LoadTestService.LoadTestResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTestService.LoadTestResource> Get(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTestService.LoadTestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTestService.LoadTestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTestService.LoadTestResource>> GetAsync(string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LoadTestService.LoadTestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTestService.LoadTestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LoadTestService.LoadTestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTestService.LoadTestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoadTestResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LoadTestResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DataPlaneUri { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTestService.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTestService.Models.ResourceState? ProvisioningState { get { throw null; } }
    }
    public static partial class LoadTestServiceExtensions
    {
        public static Azure.ResourceManager.LoadTestService.LoadTestResource GetLoadTestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LoadTestService.LoadTestResource> GetLoadTestResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTestService.LoadTestResource>> GetLoadTestResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string loadTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LoadTestService.LoadTestResourceCollection GetLoadTestResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LoadTestService.LoadTestResource> GetLoadTestResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LoadTestService.LoadTestResource> GetLoadTestResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LoadTestService.QuotaResource GetQuotaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LoadTestService.QuotaResource> GetQuotaResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTestService.QuotaResource>> GetQuotaResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LoadTestService.QuotaResourceCollection GetQuotaResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class QuotaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QuotaResource() { }
        public virtual Azure.ResourceManager.LoadTestService.QuotaResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LoadTestService.Models.CheckQuotaAvailabilityResponse> CheckAvailability(Azure.ResourceManager.LoadTestService.Models.QuotaBucketContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTestService.Models.CheckQuotaAvailabilityResponse>> CheckAvailabilityAsync(Azure.ResourceManager.LoadTestService.Models.QuotaBucketContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string quotaBucketName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTestService.QuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTestService.QuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuotaResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTestService.QuotaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTestService.QuotaResource>, System.Collections.IEnumerable
    {
        protected QuotaResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LoadTestService.QuotaResource> Get(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LoadTestService.QuotaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LoadTestService.QuotaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LoadTestService.QuotaResource>> GetAsync(string quotaBucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LoadTestService.QuotaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LoadTestService.QuotaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LoadTestService.QuotaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LoadTestService.QuotaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QuotaResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public QuotaResourceData() { }
        public int? Limit { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTestService.Models.ResourceState? ProvisioningState { get { throw null; } }
        public int? Usage { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.LoadTestService.Models
{
    public partial class CheckQuotaAvailabilityResponse : Azure.ResourceManager.Models.ResourceData
    {
        public CheckQuotaAvailabilityResponse() { }
        public string AvailabilityStatus { get { throw null; } set { } }
        public bool? IsAvailable { get { throw null; } set { } }
    }
    public partial class EncryptionProperties
    {
        public EncryptionProperties() { }
        public Azure.ResourceManager.LoadTestService.Models.EncryptionPropertiesIdentity Identity { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
    }
    public partial class EncryptionPropertiesIdentity
    {
        public EncryptionPropertiesIdentity() { }
        public Azure.ResourceManager.LoadTestService.Models.Type? IdentityType { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class EndpointDependency
    {
        internal EndpointDependency() { }
        public string Description { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LoadTestService.Models.EndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class EndpointDetail
    {
        internal EndpointDetail() { }
        public int? Port { get { throw null; } }
    }
    public partial class LoadTestResourcePatch
    {
        public LoadTestResourcePatch() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTestService.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.BinaryData Tags { get { throw null; } set { } }
    }
    public partial class OutboundEnvironmentEndpoint
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LoadTestService.Models.EndpointDependency> Endpoints { get { throw null; } }
    }
    public partial class QuotaBucketContent : Azure.ResourceManager.Models.ResourceData
    {
        public QuotaBucketContent() { }
        public int? CurrentQuota { get { throw null; } set { } }
        public int? CurrentUsage { get { throw null; } set { } }
        public Azure.ResourceManager.LoadTestService.Models.QuotaBucketRequestPropertiesDimensions Dimensions { get { throw null; } set { } }
        public int? NewQuota { get { throw null; } set { } }
    }
    public partial class QuotaBucketRequestPropertiesDimensions
    {
        public QuotaBucketRequestPropertiesDimensions() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceState : System.IEquatable<Azure.ResourceManager.LoadTestService.Models.ResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceState(string value) { throw null; }
        public static Azure.ResourceManager.LoadTestService.Models.ResourceState Canceled { get { throw null; } }
        public static Azure.ResourceManager.LoadTestService.Models.ResourceState Deleted { get { throw null; } }
        public static Azure.ResourceManager.LoadTestService.Models.ResourceState Failed { get { throw null; } }
        public static Azure.ResourceManager.LoadTestService.Models.ResourceState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LoadTestService.Models.ResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LoadTestService.Models.ResourceState left, Azure.ResourceManager.LoadTestService.Models.ResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTestService.Models.ResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LoadTestService.Models.ResourceState left, Azure.ResourceManager.LoadTestService.Models.ResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Type : System.IEquatable<Azure.ResourceManager.LoadTestService.Models.Type>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Type(string value) { throw null; }
        public static Azure.ResourceManager.LoadTestService.Models.Type SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.LoadTestService.Models.Type UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LoadTestService.Models.Type other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LoadTestService.Models.Type left, Azure.ResourceManager.LoadTestService.Models.Type right) { throw null; }
        public static implicit operator Azure.ResourceManager.LoadTestService.Models.Type (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LoadTestService.Models.Type left, Azure.ResourceManager.LoadTestService.Models.Type right) { throw null; }
        public override string ToString() { throw null; }
    }
}
