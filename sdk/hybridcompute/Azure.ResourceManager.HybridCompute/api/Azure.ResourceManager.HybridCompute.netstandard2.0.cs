namespace Azure.ResourceManager.HybridCompute
{
    public static partial class HybridComputeExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetHybridComputeMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string machineName, Azure.ResourceManager.HybridCompute.Models.InstanceViewType? expand = default(Azure.ResourceManager.HybridCompute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> GetHybridComputeMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string machineName, Azure.ResourceManager.HybridCompute.Models.InstanceViewType? expand = default(Azure.ResourceManager.HybridCompute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource GetHybridComputeMachineExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineResource GetHybridComputeMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineCollection GetHybridComputeMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetHybridComputeMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetHybridComputeMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource GetHybridComputePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource GetHybridComputePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetHybridComputePrivateLinkScope(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> GetHybridComputePrivateLinkScopeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource GetHybridComputePrivateLinkScopeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeCollection GetHybridComputePrivateLinkScopes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetHybridComputePrivateLinkScopes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetHybridComputePrivateLinkScopesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails> GetValidationDetailsPrivateLinkScope(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string privateLinkScopeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>> GetValidationDetailsPrivateLinkScopeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string privateLinkScopeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputeMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>, System.Collections.IEnumerable
    {
        protected HybridComputeMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string machineName, Azure.ResourceManager.HybridCompute.HybridComputeMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string machineName, Azure.ResourceManager.HybridCompute.HybridComputeMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string machineName, Azure.ResourceManager.HybridCompute.Models.InstanceViewType? expand = default(Azure.ResourceManager.HybridCompute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string machineName, Azure.ResourceManager.HybridCompute.Models.InstanceViewType? expand = default(Azure.ResourceManager.HybridCompute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> Get(string machineName, Azure.ResourceManager.HybridCompute.Models.InstanceViewType? expand = default(Azure.ResourceManager.HybridCompute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> GetAsync(string machineName, Azure.ResourceManager.HybridCompute.Models.InstanceViewType? expand = default(Azure.ResourceManager.HybridCompute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputeMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridComputeMachineData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.MachineProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData> Resources { get { throw null; } }
    }
    public partial class HybridComputeMachineExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>, System.Collections.IEnumerable
    {
        protected HybridComputeMachineExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputeMachineExtensionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridComputeMachineExtensionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridComputeMachineExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputeMachineExtensionResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputeMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputeMachineResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> Get(Azure.ResourceManager.HybridCompute.Models.InstanceViewType? expand = default(Azure.ResourceManager.HybridCompute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> GetAsync(Azure.ResourceManager.HybridCompute.Models.InstanceViewType? expand = default(Azure.ResourceManager.HybridCompute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> GetHybridComputeMachineExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> GetHybridComputeMachineExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionCollection GetHybridComputeMachineExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails> GetValidationDetailsForMachinePrivateLinkScope(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>> GetValidationDetailsForMachinePrivateLinkScopeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> Update(Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> UpdateAsync(Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade extensionUpgradeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade extensionUpgradeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HybridComputePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridComputePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridComputePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputePrivateLinkResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HybridComputePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridComputePrivateLinkResourceData() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridComputePrivateLinkScopeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>, System.Collections.IEnumerable
    {
        protected HybridComputePrivateLinkScopeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scopeName, Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scopeName, Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> Get(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> GetAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputePrivateLinkScopeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridComputePrivateLinkScopeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridComputePrivateLinkScopeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputePrivateLinkScopeResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> GetHybridComputePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> GetHybridComputePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionCollection GetHybridComputePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> GetHybridComputePrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>> GetHybridComputePrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceCollection GetHybridComputePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> Update(Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> UpdateAsync(Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridCompute.Models
{
    public partial class AgentConfiguration
    {
        internal AgentConfiguration() { }
        public Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode? ConfigMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension> ExtensionsAllowList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension> ExtensionsBlockList { get { throw null; } }
        public string ExtensionsEnabled { get { throw null; } }
        public string GuestConfigurationEnabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IncomingConnectionsPorts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProxyBypass { get { throw null; } }
        public System.Uri ProxyUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentConfigurationMode : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentConfigurationMode(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode Full { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode Monitor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode left, Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode left, Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentModeType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.AssessmentModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentModeType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.AssessmentModeType AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.AssessmentModeType ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.AssessmentModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.AssessmentModeType left, Azure.ResourceManager.HybridCompute.Models.AssessmentModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.AssessmentModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.AssessmentModeType left, Azure.ResourceManager.HybridCompute.Models.AssessmentModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationExtension
    {
        internal ConfigurationExtension() { }
        public string ConfigurationExtensionType { get { throw null; } }
        public string Publisher { get { throw null; } }
    }
    public partial class ConnectionDetail
    {
        internal ConnectionDetail() { }
        public string GroupId { get { throw null; } }
        public string Id { get { throw null; } }
        public string LinkIdentifier { get { throw null; } }
        public string MemberName { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } }
    }
    public partial class ExtensionTargetProperties
    {
        public ExtensionTargetProperties() { }
        public string TargetVersion { get { throw null; } set { } }
    }
    public partial class HybridComputeMachineExtensionPatch : Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate
    {
        public HybridComputeMachineExtensionPatch() { }
        public Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpdateProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridComputeMachinePatch : Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate
    {
        public HybridComputeMachinePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.MachineUpdateProperties Properties { get { throw null; } set { } }
    }
    public static partial class HybridComputeModelFactory
    {
        public static Azure.ResourceManager.HybridCompute.Models.AgentConfiguration AgentConfiguration(System.Uri proxyUri = null, System.Collections.Generic.IEnumerable<string> incomingConnectionsPorts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension> extensionsAllowList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension> extensionsBlockList = null, System.Collections.Generic.IEnumerable<string> proxyBypass = null, string extensionsEnabled = null, string guestConfigurationEnabled = null, Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode? configMode = default(Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension ConfigurationExtension(string publisher = null, string configurationExtensionType = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ConnectionDetail ConnectionDetail(string id = null, string privateIPAddress = null, string linkIdentifier = null, string groupId = null, string memberName = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineData HybridComputeMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.MachineProperties properties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData> resources = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData HybridComputeMachineExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData HybridComputePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData HybridComputePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties HybridComputePrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData HybridComputePrivateLinkScopeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties HybridComputePrivateLinkScopeProperties(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType? publicNetworkAccess = default(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType?), string provisioningState = null, string privateLinkScopeId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty HybridComputePrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties MachineExtensionProperties(string forceUpdateTag = null, string publisher = null, string machineExtensionPropertiesType = null, string typeHandlerVersion = null, bool? enableAutomaticUpgrade = default(bool?), bool? autoUpgradeMinorVersion = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> protectedSettings = null, string provisioningState = null, Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineProperties MachineProperties(Azure.ResourceManager.HybridCompute.Models.LocationData locationData = null, Azure.ResourceManager.HybridCompute.Models.AgentConfiguration agentConfiguration = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses serviceStatuses = null, string cloudMetadataProvider = null, Azure.ResourceManager.HybridCompute.Models.OSProfile osProfile = null, string provisioningState = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType? status = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType?), System.DateTimeOffset? lastStatusChange = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null, string agentVersion = null, string vmId = null, string displayName = null, string machineFqdn = null, string clientPublicKey = null, string osName = null, string osVersion = null, string osType = null, string vmUuid = null, string osSku = null, string domainName = null, string adFqdn = null, string dnsFqdn = null, string privateLinkScopeResourceId = null, string parentClusterResourceId = null, string mssqlDiscovered = null, System.Collections.Generic.IReadOnlyDictionary<string, string> detectedProperties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.OSProfile OSProfile(string computerName = null, Azure.ResourceManager.HybridCompute.Models.OSProfileWindowsConfiguration windowsConfiguration = null, Azure.ResourceManager.HybridCompute.Models.OSProfileLinuxConfiguration linuxConfiguration = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel PrivateEndpointConnectionDataModel(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty connectionState = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> groupIds = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails PrivateLinkScopeValidationDetails(string id = null, Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType? publicNetworkAccess = default(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.ConnectionDetail> connectionDetails = null) { throw null; }
    }
    public partial class HybridComputePrivateLinkResourceProperties
    {
        public HybridComputePrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class HybridComputePrivateLinkScopePatch
    {
        public HybridComputePrivateLinkScopePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HybridComputePrivateLinkScopeProperties
    {
        public HybridComputePrivateLinkScopeProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel> PrivateEndpointConnections { get { throw null; } }
        public string PrivateLinkScopeId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class HybridComputePrivateLinkServiceConnectionStateProperty
    {
        public HybridComputePrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class HybridComputeResourceUpdate
    {
        public HybridComputeResourceUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HybridComputeServiceStatus
    {
        public HybridComputeServiceStatus() { }
        public string StartupType { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class HybridComputeServiceStatuses
    {
        public HybridComputeServiceStatuses() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus ExtensionService { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus GuestConfigurationService { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeStatusLevelType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeStatusLevelType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType Error { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType Info { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeStatusType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeStatusType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType Connected { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType Disconnected { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType Error { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstanceViewType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.InstanceViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceViewType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.InstanceViewType InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.InstanceViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.InstanceViewType left, Azure.ResourceManager.HybridCompute.Models.InstanceViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.InstanceViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.InstanceViewType left, Azure.ResourceManager.HybridCompute.Models.InstanceViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocationData
    {
        public LocationData(string name) { }
        public string City { get { throw null; } set { } }
        public string CountryOrRegion { get { throw null; } set { } }
        public string District { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MachineExtensionInstanceView
    {
        public MachineExtensionInstanceView() { }
        public string MachineExtensionInstanceViewType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus Status { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class MachineExtensionInstanceViewStatus
    {
        public MachineExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
    }
    public partial class MachineExtensionProperties
    {
        public MachineExtensionProperties() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public string MachineExtensionPropertiesType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ProtectedSettings { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class MachineExtensionUpdateProperties
    {
        public MachineExtensionUpdateProperties() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string MachineExtensionUpdatePropertiesType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ProtectedSettings { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class MachineExtensionUpgrade
    {
        public MachineExtensionUpgrade() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties> ExtensionTargets { get { throw null; } }
    }
    public partial class MachineProperties
    {
        public MachineProperties() { }
        public string AdFqdn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.AgentConfiguration AgentConfiguration { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string ClientPublicKey { get { throw null; } set { } }
        public string CloudMetadataProvider { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> DetectedProperties { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string DnsFqdn { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusChange { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LocationData LocationData { get { throw null; } set { } }
        public string MachineFqdn { get { throw null; } }
        public string MssqlDiscovered { get { throw null; } set { } }
        public string OSName { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public string OSSku { get { throw null; } }
        public string OSType { get { throw null; } set { } }
        public string OSVersion { get { throw null; } }
        public string ParentClusterResourceId { get { throw null; } set { } }
        public string PrivateLinkScopeResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses ServiceStatuses { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType? Status { get { throw null; } }
        public string VmId { get { throw null; } set { } }
        public string VmUuid { get { throw null; } }
    }
    public partial class MachineUpdateProperties
    {
        public MachineUpdateProperties() { }
        public string CloudMetadataProvider { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LocationData LocationData { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public string ParentClusterResourceId { get { throw null; } set { } }
        public string PrivateLinkScopeResourceId { get { throw null; } set { } }
    }
    public partial class OSProfile
    {
        public OSProfile() { }
        public string ComputerName { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.OSProfileLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.OSProfileWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class OSProfileLinuxConfiguration
    {
        public OSProfileLinuxConfiguration() { }
        public Azure.ResourceManager.HybridCompute.Models.AssessmentModeType? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.PatchModeType? PatchMode { get { throw null; } set { } }
    }
    public partial class OSProfileWindowsConfiguration
    {
        public OSProfileWindowsConfiguration() { }
        public Azure.ResourceManager.HybridCompute.Models.AssessmentModeType? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.PatchModeType? PatchMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchModeType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.PatchModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchModeType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PatchModeType AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchModeType AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchModeType ImageDefault { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchModeType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.PatchModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.PatchModeType left, Azure.ResourceManager.HybridCompute.Models.PatchModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.PatchModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.PatchModeType left, Azure.ResourceManager.HybridCompute.Models.PatchModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionDataModel : Azure.ResourceManager.Models.ResourceData
    {
        internal PrivateEndpointConnectionDataModel() { }
        public Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        public PrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkScopeValidationDetails
    {
        internal PrivateLinkScopeValidationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.ConnectionDetail> ConnectionDetails { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType left, Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType left, Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
