namespace Azure.ResourceManager.Dashboard
{
    public static partial class DashboardExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetManagedGrafana(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> GetManagedGrafanaAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dashboard.ManagedGrafanaResource GetManagedGrafanaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dashboard.ManagedGrafanaCollection GetManagedGrafanas(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetManagedGrafanas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetManagedGrafanasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedGrafanaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>, System.Collections.IEnumerable
    {
        protected ManagedGrafanaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Dashboard.ManagedGrafanaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Dashboard.ManagedGrafanaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedGrafanaData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedGrafanaData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Dashboard.Models.ManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.ManagedGrafanaProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class ManagedGrafanaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedGrafanaResource() { }
        public virtual Azure.ResourceManager.Dashboard.ManagedGrafanaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource> Update(Azure.ResourceManager.Dashboard.Models.ManagedGrafanaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dashboard.ManagedGrafanaResource>> UpdateAsync(Azure.ResourceManager.Dashboard.Models.ManagedGrafanaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dashboard.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ManagedGrafanaPatch
    {
        public ManagedGrafanaPatch() { }
        public Azure.ResourceManager.Dashboard.Models.ManagedIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ManagedGrafanaProperties
    {
        public ManagedGrafanaProperties() { }
        public Azure.ResourceManager.Dashboard.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public string GrafanaVersion { get { throw null; } }
        public Azure.ResourceManager.Dashboard.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Dashboard.Models.ZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
    }
    public partial class ManagedIdentity
    {
        public ManagedIdentity() { }
        public Azure.ResourceManager.Dashboard.Models.IdentityType? IdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
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
