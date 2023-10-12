namespace Azure.ResourceManager.ao5gc
{
    public static partial class ao5gcExtensions
    {
        public static Azure.ResourceManager.ao5gc.NetworkFunctionResource GetNetworkFunctionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource> GetNetworkFunctionResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource>> GetNetworkFunctionResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ao5gc.NetworkFunctionResourceCollection GetNetworkFunctionResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ao5gc.NetworkFunctionResource> GetNetworkFunctionResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ao5gc.NetworkFunctionResource> GetNetworkFunctionResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFunctionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFunctionResource() { }
        public virtual Azure.ResourceManager.ao5gc.NetworkFunctionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFunctionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource> Update(Azure.ResourceManager.ao5gc.Models.NetworkFunctionResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource>> UpdateAsync(Azure.ResourceManager.ao5gc.Models.NetworkFunctionResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFunctionResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ao5gc.NetworkFunctionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ao5gc.NetworkFunctionResource>, System.Collections.IEnumerable
    {
        protected NetworkFunctionResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ao5gc.NetworkFunctionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkFunctionName, Azure.ResourceManager.ao5gc.NetworkFunctionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ao5gc.NetworkFunctionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkFunctionName, Azure.ResourceManager.ao5gc.NetworkFunctionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource> Get(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ao5gc.NetworkFunctionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ao5gc.NetworkFunctionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ao5gc.NetworkFunctionResource>> GetAsync(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ao5gc.NetworkFunctionResource> GetIfExists(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ao5gc.NetworkFunctionResource>> GetIfExistsAsync(string networkFunctionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ao5gc.NetworkFunctionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ao5gc.NetworkFunctionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ao5gc.NetworkFunctionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ao5gc.NetworkFunctionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFunctionResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkFunctionResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? Capacity { get { throw null; } set { } }
        public string DeploymentNotes { get { throw null; } set { } }
        public int? InfrastructureElementCount { get { throw null; } }
        public Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState? NetworkFunctionAdministrativeState { get { throw null; } set { } }
        public Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus? NetworkFunctionOperationalStatus { get { throw null; } }
        public Azure.ResourceManager.ao5gc.Models.NetworkFunctionType? NetworkFunctionType { get { throw null; } set { } }
        public Azure.ResourceManager.ao5gc.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ao5gc.Models.SkuDefinition? Sku { get { throw null; } set { } }
        public string UserDescription { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.ao5gc.Models
{
    public static partial class Armao5gcModelFactory
    {
        public static Azure.ResourceManager.ao5gc.NetworkFunctionResourceData NetworkFunctionResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ao5gc.Models.SkuDefinition? sku = default(Azure.ResourceManager.ao5gc.Models.SkuDefinition?), Azure.ResourceManager.ao5gc.Models.NetworkFunctionType? networkFunctionType = default(Azure.ResourceManager.ao5gc.Models.NetworkFunctionType?), Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState? networkFunctionAdministrativeState = default(Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState?), Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus? networkFunctionOperationalStatus = default(Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus?), int? infrastructureElementCount = default(int?), int? capacity = default(int?), string userDescription = null, string deploymentNotes = null, Azure.ResourceManager.ao5gc.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ao5gc.Models.ProvisioningState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFunctionAdministrativeState : System.IEquatable<Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFunctionAdministrativeState(string value) { throw null; }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState Commissioned { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState Decommissioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState left, Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState left, Azure.ResourceManager.ao5gc.Models.NetworkFunctionAdministrativeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFunctionOperationalStatus : System.IEquatable<Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFunctionOperationalStatus(string value) { throw null; }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus Active { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus InstantiatedNotProvisioned { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus InstantiatedProvisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus left, Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus left, Azure.ResourceManager.ao5gc.Models.NetworkFunctionOperationalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkFunctionResourcePatch
    {
        public NetworkFunctionResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFunctionType : System.IEquatable<Azure.ResourceManager.ao5gc.Models.NetworkFunctionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFunctionType(string value) { throw null; }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType AMF { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType EMS { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType EPDG { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType MME { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType N3IWF { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType NRF { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType Nssf { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType OperationsPolicyManager { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType RemotePaaS { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType Saegw { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType SaegwControlPlane { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType SaegwUserPlane { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType SMF { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.NetworkFunctionType UPF { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ao5gc.Models.NetworkFunctionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ao5gc.Models.NetworkFunctionType left, Azure.ResourceManager.ao5gc.Models.NetworkFunctionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ao5gc.Models.NetworkFunctionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ao5gc.Models.NetworkFunctionType left, Azure.ResourceManager.ao5gc.Models.NetworkFunctionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ao5gc.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ao5gc.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ao5gc.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ao5gc.Models.ProvisioningState left, Azure.ResourceManager.ao5gc.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ao5gc.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ao5gc.Models.ProvisioningState left, Azure.ResourceManager.ao5gc.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuDefinition : System.IEquatable<Azure.ResourceManager.ao5gc.Models.SkuDefinition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuDefinition(string value) { throw null; }
        public static Azure.ResourceManager.ao5gc.Models.SkuDefinition AzureLab { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.SkuDefinition AzureProduction { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.SkuDefinition NexusLab { get { throw null; } }
        public static Azure.ResourceManager.ao5gc.Models.SkuDefinition NexusProduction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ao5gc.Models.SkuDefinition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ao5gc.Models.SkuDefinition left, Azure.ResourceManager.ao5gc.Models.SkuDefinition right) { throw null; }
        public static implicit operator Azure.ResourceManager.ao5gc.Models.SkuDefinition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ao5gc.Models.SkuDefinition left, Azure.ResourceManager.ao5gc.Models.SkuDefinition right) { throw null; }
        public override string ToString() { throw null; }
    }
}
