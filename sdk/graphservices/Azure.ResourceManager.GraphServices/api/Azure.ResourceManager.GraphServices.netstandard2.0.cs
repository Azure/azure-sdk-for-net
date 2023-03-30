namespace Azure.ResourceManager.GraphServices
{
    public partial class GraphServicesAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GraphServicesAccountResource() { }
        public virtual Azure.ResourceManager.GraphServices.GraphServicesAccountResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> Update(Azure.ResourceManager.GraphServices.Models.GraphServicesAccountResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>> UpdateAsync(Azure.ResourceManager.GraphServices.Models.GraphServicesAccountResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GraphServicesAccountResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>, System.Collections.IEnumerable
    {
        protected GraphServicesAccountResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.GraphServices.GraphServicesAccountResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.GraphServices.GraphServicesAccountResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GraphServicesAccountResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GraphServicesAccountResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.GraphServices.Models.GraphServicesAccountResourceProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.GraphServices.Models.GraphServicesAccountResourceProperties Properties { get { throw null; } set { } }
    }
    public static partial class GraphServicesExtensions
    {
        public static Azure.ResourceManager.GraphServices.GraphServicesAccountResource GetGraphServicesAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> GetGraphServicesAccountResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GraphServices.GraphServicesAccountResource>> GetGraphServicesAccountResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.GraphServices.GraphServicesAccountResourceCollection GetGraphServicesAccountResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> GetGraphServicesAccountResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.GraphServices.GraphServicesAccountResource> GetGraphServicesAccountResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.GraphServices.Models
{
    public static partial class ArmGraphServicesModelFactory
    {
        public static Azure.ResourceManager.GraphServices.GraphServicesAccountResourceData GraphServicesAccountResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.GraphServices.Models.GraphServicesAccountResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.GraphServices.Models.GraphServicesAccountResourceProperties GraphServicesAccountResourceProperties(Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState? provisioningState = default(Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState?), string appId = null, string billingPlanId = null) { throw null; }
    }
    public partial class GraphServicesAccountResourcePatch : Azure.ResourceManager.GraphServices.Models.TagUpdate
    {
        public GraphServicesAccountResourcePatch() { }
    }
    public partial class GraphServicesAccountResourceProperties
    {
        public GraphServicesAccountResourceProperties(string appId) { }
        public string AppId { get { throw null; } set { } }
        public string BillingPlanId { get { throw null; } }
        public Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GraphServicesProvisioningState : System.IEquatable<Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GraphServicesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState left, Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState left, Azure.ResourceManager.GraphServices.Models.GraphServicesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagUpdate
    {
        public TagUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
