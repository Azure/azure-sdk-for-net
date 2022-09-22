namespace Azure.ResourceManager.DevSpaces
{
    public partial class ControllerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevSpaces.ControllerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevSpaces.ControllerResource>, System.Collections.IEnumerable
    {
        protected ControllerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevSpaces.ControllerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevSpaces.ControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevSpaces.ControllerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevSpaces.ControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevSpaces.ControllerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevSpaces.ControllerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevSpaces.ControllerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevSpaces.ControllerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevSpaces.ControllerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevSpaces.ControllerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ControllerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ControllerData(Azure.Core.AzureLocation location, Azure.ResourceManager.DevSpaces.Models.DevSpacesSku sku, string targetContainerHostResourceId, string targetContainerHostCredentialsBase64) : base (default(Azure.Core.AzureLocation)) { }
        public string DataPlaneFqdn { get { throw null; } }
        public string HostSuffix { get { throw null; } }
        public Azure.ResourceManager.DevSpaces.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevSpaces.Models.DevSpacesSku Sku { get { throw null; } set { } }
        public string TargetContainerHostApiServerFqdn { get { throw null; } }
        public string TargetContainerHostCredentialsBase64 { get { throw null; } set { } }
        public string TargetContainerHostResourceId { get { throw null; } set { } }
    }
    public partial class ControllerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ControllerResource() { }
        public virtual Azure.ResourceManager.DevSpaces.ControllerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevSpaces.Models.ControllerConnectionDetailsList> GetConnectionDetails(Azure.ResourceManager.DevSpaces.Models.ListConnectionDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevSpaces.Models.ControllerConnectionDetailsList>> GetConnectionDetailsAsync(Azure.ResourceManager.DevSpaces.Models.ListConnectionDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource> Update(Azure.ResourceManager.DevSpaces.Models.ControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource>> UpdateAsync(Azure.ResourceManager.DevSpaces.Models.ControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DevSpacesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DevSpaces.Models.ContainerHostMapping> GetContainerHostMappingContainerHostMapping(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DevSpaces.Models.ContainerHostMapping containerHostMapping, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevSpaces.Models.ContainerHostMapping>> GetContainerHostMappingContainerHostMappingAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DevSpaces.Models.ContainerHostMapping containerHostMapping, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource> GetController(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevSpaces.ControllerResource>> GetControllerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevSpaces.ControllerResource GetControllerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevSpaces.ControllerCollection GetControllers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevSpaces.ControllerResource> GetControllers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevSpaces.ControllerResource> GetControllersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevSpaces.Models
{
    public partial class ContainerHostMapping
    {
        public ContainerHostMapping() { }
        public string ContainerHostResourceId { get { throw null; } set { } }
        public string MappedControllerResourceId { get { throw null; } }
    }
    public partial class ControllerConnectionDetails
    {
        internal ControllerConnectionDetails() { }
        public Azure.ResourceManager.DevSpaces.Models.OrchestratorSpecificConnectionDetails OrchestratorSpecificConnectionDetails { get { throw null; } }
    }
    public partial class ControllerConnectionDetailsList
    {
        internal ControllerConnectionDetailsList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevSpaces.Models.ControllerConnectionDetails> ConnectionDetailsList { get { throw null; } }
    }
    public partial class ControllerPatch
    {
        public ControllerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetContainerHostCredentialsBase64 { get { throw null; } set { } }
    }
    public partial class DevSpacesSku
    {
        public DevSpacesSku(Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName name) { }
        public Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevSpacesSkuName : System.IEquatable<Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevSpacesSkuName(string value) { throw null; }
        public static Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName S1 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName left, Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName left, Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevSpacesSkuTier : System.IEquatable<Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevSpacesSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuTier left, Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuTier left, Azure.ResourceManager.DevSpaces.Models.DevSpacesSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesConnectionDetails : Azure.ResourceManager.DevSpaces.Models.OrchestratorSpecificConnectionDetails
    {
        internal KubernetesConnectionDetails() { }
        public string KubeConfig { get { throw null; } }
    }
    public partial class ListConnectionDetailsContent
    {
        public ListConnectionDetailsContent(string targetContainerHostResourceId) { }
        public string TargetContainerHostResourceId { get { throw null; } }
    }
    public abstract partial class OrchestratorSpecificConnectionDetails
    {
        protected OrchestratorSpecificConnectionDetails() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DevSpaces.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DevSpaces.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DevSpaces.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DevSpaces.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DevSpaces.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DevSpaces.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DevSpaces.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevSpaces.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevSpaces.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevSpaces.Models.ProvisioningState left, Azure.ResourceManager.DevSpaces.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevSpaces.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevSpaces.Models.ProvisioningState left, Azure.ResourceManager.DevSpaces.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
