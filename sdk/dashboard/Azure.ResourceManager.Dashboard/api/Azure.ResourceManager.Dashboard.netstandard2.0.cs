namespace Azure.ResourceManager.Dashboard
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.Dashboard.GrafanaResource GetGrafanaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class GrafanaResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GrafanaResource() { }
        public virtual Azure.ResourceManager.Dashboard.GrafanaResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource> Update(Azure.ResourceManager.Dashboard.Models.PatchableGrafanaResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource>> UpdateAsync(Azure.ResourceManager.Dashboard.Models.PatchableGrafanaResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GrafanaResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.GrafanaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.GrafanaResource>, System.Collections.IEnumerable
    {
        protected GrafanaResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.GrafanaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Dashboard.GrafanaResourceData body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.GrafanaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Dashboard.GrafanaResourceData body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dashboard.GrafanaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dashboard.GrafanaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dashboard.GrafanaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.GrafanaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dashboard.GrafanaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.GrafanaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GrafanaResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GrafanaResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Dashboard.Models.ManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.GrafanaResourceProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource> GetGrafanaResource(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.GrafanaResource>> GetGrafanaResourceAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dashboard.GrafanaResourceCollection GetGrafanaResources(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Dashboard.GrafanaResource> GetGrafanaResources(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dashboard.GrafanaResource> GetGrafanaResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dashboard.Models
{
    public partial class GrafanaResourceProperties
    {
        public GrafanaResourceProperties() { }
        public string Endpoint { get { throw null; } }
        public string GrafanaVersion { get { throw null; } }
        public Azure.ResourceManager.Dashboard.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.ZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.Dashboard.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.IdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.IdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.IdentityType left, Azure.ResourceManager.Dashboard.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.IdentityType left, Azure.ResourceManager.Dashboard.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIdentity
    {
        public ManagedIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Dashboard.Models.IdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class PatchableGrafanaResourceData
    {
        public PatchableGrafanaResourceData() { }
        public Azure.ResourceManager.Dashboard.Models.ManagedIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Dashboard.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.ProvisioningState left, Azure.ResourceManager.Dashboard.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.ProvisioningState left, Azure.ResourceManager.Dashboard.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneRedundancy : System.IEquatable<Azure.ResourceManager.Dashboard.Models.ZoneRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.ZoneRedundancy Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dashboard.Models.ZoneRedundancy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.ZoneRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.ZoneRedundancy left, Azure.ResourceManager.Dashboard.Models.ZoneRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.ZoneRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.ZoneRedundancy left, Azure.ResourceManager.Dashboard.Models.ZoneRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
