namespace Azure.ResourceManager.ServiceNetworking.TrafficController
{
    public partial class AssociationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>, System.Collections.IEnumerable
    {
        protected AssociationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> Get(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>> GetAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssociationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AssociationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType? AssociationType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class AssociationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssociationResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string associationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> Update(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontendCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>, System.Collections.IEnumerable
    {
        protected FrontendCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string frontendName, Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string frontendName, Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> Get(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>> GetAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontendData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FrontendData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendIPAddressVersion? IPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier PublicIPAddressId { get { throw null; } set { } }
    }
    public partial class FrontendResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontendResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string frontendName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> Update(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficControllerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>, System.Collections.IEnumerable
    {
        protected TrafficControllerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trafficControllerName, Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trafficControllerName, Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> Get(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>> GetAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrafficControllerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public TrafficControllerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Associations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ConfigurationEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Frontends { get { throw null; } }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public static partial class TrafficControllerExtensions
    {
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource GetAssociationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource GetFrontendResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> GetTrafficController(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>> GetTrafficControllerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource GetTrafficControllerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerCollection GetTrafficControllers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> GetTrafficControllers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> GetTrafficControllersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficControllerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficControllerResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource> GetAssociation(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationResource>> GetAssociationAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficController.AssociationCollection GetAssociations() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource> GetFrontend(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendResource>> GetFrontendAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficController.FrontendCollection GetFrontends() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource> Update(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.TrafficControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficController.TrafficControllerResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.TrafficControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceNetworking.TrafficController.Models
{
    public partial class AssociationPatch
    {
        public AssociationPatch() { }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssociationType : System.IEquatable<Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssociationType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType Subnets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType left, Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType left, Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssociationUpdateProperties
    {
        public AssociationUpdateProperties() { }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.AssociationType? AssociationType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public enum FrontendIPAddressVersion
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontendMode : System.IEquatable<Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontendMode(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode left, Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode left, Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontendPatch
    {
        public FrontendPatch() { }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class FrontendUpdateProperties
    {
        public FrontendUpdateProperties() { }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendIPAddressVersion? IPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceNetworking.TrafficController.Models.FrontendMode? Mode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPAddressId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState left, Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState left, Azure.ResourceManager.ServiceNetworking.TrafficController.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficControllerPatch
    {
        public TrafficControllerPatch() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
