namespace Azure.ResourceManager.Graphservicesprod
{
    public partial class AccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccountResource() { }
        public virtual Azure.ResourceManager.Graphservicesprod.AccountResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource> Update(Azure.ResourceManager.Graphservicesprod.Models.AccountResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource>> UpdateAsync(Azure.ResourceManager.Graphservicesprod.Models.AccountResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AccountResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Graphservicesprod.AccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Graphservicesprod.AccountResource>, System.Collections.IEnumerable
    {
        protected AccountResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Graphservicesprod.AccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Graphservicesprod.AccountResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Graphservicesprod.AccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Graphservicesprod.AccountResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Graphservicesprod.AccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Graphservicesprod.AccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Graphservicesprod.AccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Graphservicesprod.AccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Graphservicesprod.AccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Graphservicesprod.AccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccountResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AccountResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Graphservicesprod.Models.AccountResourceProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Graphservicesprod.Models.AccountResourceProperties Properties { get { throw null; } set { } }
    }
    public static partial class GraphservicesprodExtensions
    {
        public static Azure.ResourceManager.Graphservicesprod.AccountResource GetAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource> GetAccountResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Graphservicesprod.AccountResource>> GetAccountResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Graphservicesprod.AccountResourceCollection GetAccountResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Graphservicesprod.AccountResource> GetAccountResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Graphservicesprod.AccountResource> GetAccountResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Graphservicesprod.Models
{
    public partial class AccountResourcePatch : Azure.ResourceManager.Graphservicesprod.Models.TagUpdate
    {
        public AccountResourcePatch() { }
    }
    public partial class AccountResourceProperties
    {
        public AccountResourceProperties(string appId) { }
        public string AppId { get { throw null; } set { } }
        public string BillingPlanId { get { throw null; } }
        public Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public static partial class ArmGraphservicesprodModelFactory
    {
        public static Azure.ResourceManager.Graphservicesprod.AccountResourceData AccountResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Graphservicesprod.Models.AccountResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Graphservicesprod.Models.AccountResourceProperties AccountResourceProperties(Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState?), string appId = null, string billingPlanId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState left, Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState left, Azure.ResourceManager.Graphservicesprod.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagUpdate
    {
        public TagUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
