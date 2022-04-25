namespace Azure.ResourceManager.Arc.ScVmm
{
    public partial class AvailabilitySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>, System.Collections.IEnumerable
    {
        protected AvailabilitySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string availabilitySetName, Azure.ResourceManager.Arc.ScVmm.AvailabilitySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string availabilitySetName, Azure.ResourceManager.Arc.ScVmm.AvailabilitySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> Get(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>> GetAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvailabilitySetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AvailabilitySetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AvailabilitySetName { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string VmmServerId { get { throw null; } set { } }
    }
    public partial class AvailabilitySetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvailabilitySetResource() { }
        public virtual Azure.ResourceManager.Arc.ScVmm.AvailabilitySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string availabilitySetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.CloudResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.CloudResource>, System.Collections.IEnumerable
    {
        protected CloudCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.CloudResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudName, Azure.ResourceManager.Arc.ScVmm.CloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.CloudResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudName, Azure.ResourceManager.Arc.ScVmm.CloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource> Get(string cloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.CloudResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.CloudResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource>> GetAsync(string cloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Arc.ScVmm.CloudResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.CloudResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Arc.ScVmm.CloudResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.CloudResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CloudData(Azure.Core.AzureLocation location, Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation extendedLocation) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Arc.ScVmm.Models.CloudCapacity CloudCapacity { get { throw null; } }
        public string CloudName { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Arc.ScVmm.Models.StorageQoSPolicy> StorageQoSPolicies { get { throw null; } }
        public string Uuid { get { throw null; } set { } }
        public string VmmServerId { get { throw null; } set { } }
    }
    public partial class CloudResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudResource() { }
        public virtual Azure.ResourceManager.Arc.ScVmm.CloudData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.CloudResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.CloudResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InventoryItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource>, System.Collections.IEnumerable
    {
        protected InventoryItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string inventoryItemName, Azure.ResourceManager.Arc.ScVmm.InventoryItemData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string inventoryItemName, Azure.ResourceManager.Arc.ScVmm.InventoryItemData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource> Get(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource>> GetAsync(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InventoryItemData : Azure.ResourceManager.Models.ResourceData
    {
        public InventoryItemData(Azure.ResourceManager.Arc.ScVmm.Models.InventoryType inventoryType) { }
        public string InventoryItemName { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } }
    }
    public partial class InventoryItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InventoryItemResource() { }
        public virtual Azure.ResourceManager.Arc.ScVmm.InventoryItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmmServerName, string inventoryItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.InventoryItemData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.InventoryItemData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ScVmmExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> GetAvailabilitySet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource>> GetAvailabilitySetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource GetAvailabilitySetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.AvailabilitySetCollection GetAvailabilitySets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> GetAvailabilitySets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.AvailabilitySetResource> GetAvailabilitySetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource> GetCloud(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.CloudResource>> GetCloudAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.CloudResource GetCloudResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.CloudCollection GetClouds(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.CloudResource> GetClouds(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.CloudResource> GetCloudsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.InventoryItemResource GetInventoryItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> GetVirtualMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>> GetVirtualMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource GetVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.VirtualMachineCollection GetVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> GetVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> GetVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> GetVirtualMachineTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>> GetVirtualMachineTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource GetVirtualMachineTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateCollection GetVirtualMachineTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> GetVirtualMachineTemplates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> GetVirtualMachineTemplatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> GetVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>> GetVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource GetVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.VirtualNetworkCollection GetVirtualNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> GetVirtualNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> GetVirtualNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> GetVmMServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>> GetVmMServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.VmMServerResource GetVmMServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.VmMServerCollection GetVmMServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> GetVmMServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> GetVmMServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.Arc.ScVmm.VirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.Arc.ScVmm.VirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> Get(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>> GetAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineData(Azure.Core.AzureLocation location, Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation extendedLocation) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Arc.ScVmm.Models.AvailabilitySetListItem> AvailabilitySets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Arc.ScVmm.Models.Checkpoint> Checkpoints { get { throw null; } }
        public string CheckpointType { get { throw null; } set { } }
        public string CloudId { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public int? Generation { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Arc.ScVmm.Models.NetworkInterfaces> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.OSProfile OSProfile { get { throw null; } set { } }
        public string PowerState { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Arc.ScVmm.Models.VirtualDisk> StorageDisks { get { throw null; } }
        public string TemplateId { get { throw null; } set { } }
        public string Uuid { get { throw null; } set { } }
        public string VmmServerId { get { throw null; } set { } }
        public string VmName { get { throw null; } set { } }
    }
    public partial class VirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineResource() { }
        public virtual Azure.ResourceManager.Arc.ScVmm.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateCheckpoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.VirtualMachineCreateCheckpoint body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateCheckpointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.VirtualMachineCreateCheckpoint body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? retain = default(bool?), bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? retain = default(bool?), bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteCheckpoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.VirtualMachineDeleteCheckpoint body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteCheckpointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.VirtualMachineDeleteCheckpoint body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreCheckpoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.VirtualMachineRestoreCheckpoint body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreCheckpointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.VirtualMachineRestoreCheckpoint body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.StopVirtualMachineContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.StopVirtualMachineContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.VirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.VirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineTemplateName, Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineTemplateName, Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> Get(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>> GetAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineTemplateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineTemplateData(Azure.Core.AzureLocation location, Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation extendedLocation) : base (default(Azure.Core.AzureLocation)) { }
        public string ComputerName { get { throw null; } }
        public int? CpuCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Arc.ScVmm.Models.VirtualDisk> Disks { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled? DynamicMemoryEnabled { get { throw null; } }
        public int? DynamicMemoryMaxMB { get { throw null; } }
        public int? DynamicMemoryMinMB { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public int? Generation { get { throw null; } }
        public string InventoryItemId { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable? IsCustomizable { get { throw null; } }
        public string IsHighlyAvailable { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration? LimitCpuForMigration { get { throw null; } }
        public int? MemoryMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Arc.ScVmm.Models.NetworkInterfaces> NetworkInterfaces { get { throw null; } }
        public string OSName { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.OSType? OSType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } set { } }
        public string VmmServerId { get { throw null; } set { } }
    }
    public partial class VirtualMachineTemplateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineTemplateResource() { }
        public virtual Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualMachineTemplateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.Arc.ScVmm.VirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.Arc.ScVmm.VirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> Get(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>> GetAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation extendedLocation) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public string NetworkName { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } set { } }
        public string VmmServerId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkResource() { }
        public virtual Azure.ResourceManager.Arc.ScVmm.VirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VirtualNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmMServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>, System.Collections.IEnumerable
    {
        protected VmMServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmmServerName, Azure.ResourceManager.Arc.ScVmm.VmMServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmmServerName, Azure.ResourceManager.Arc.ScVmm.VmMServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> Get(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>> GetAsync(string vmmServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VmMServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VmMServerData(Azure.Core.AzureLocation location, Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation extendedLocation, string fqdn) : base (default(Azure.Core.AzureLocation)) { }
        public string ConnectionStatus { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.VmMServerPropertiesCredentials Credentials { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class VmMServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VmMServerResource() { }
        public virtual Azure.ResourceManager.Arc.ScVmm.VmMServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmmServerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource> GetInventoryItem(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.InventoryItemResource>> GetInventoryItemAsync(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Arc.ScVmm.InventoryItemCollection GetInventoryItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VmMServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Arc.ScVmm.VmMServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Arc.ScVmm.Models.ResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Arc.ScVmm.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllocationMethod : System.IEquatable<Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod left, Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod left, Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailabilitySetListItem
    {
        public AvailabilitySetListItem() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class Checkpoint
    {
        public Checkpoint() { }
        public string CheckpointId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ParentCheckpointId { get { throw null; } set { } }
    }
    public partial class CloudCapacity
    {
        internal CloudCapacity() { }
        public long? CpuCount { get { throw null; } }
        public long? MemoryMB { get { throw null; } }
        public long? VmCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateDiffDisk : System.IEquatable<Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateDiffDisk(string value) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk False { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk left, Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk right) { throw null; }
        public static implicit operator Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk left, Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicMemoryEnabled : System.IEquatable<Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicMemoryEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled False { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled left, Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled left, Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtendedLocation
    {
        public ExtendedLocation() { }
        public string ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class HardwareProfile
    {
        public HardwareProfile() { }
        public int? CpuCount { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled? DynamicMemoryEnabled { get { throw null; } set { } }
        public int? DynamicMemoryMaxMB { get { throw null; } set { } }
        public int? DynamicMemoryMinMB { get { throw null; } set { } }
        public string IsHighlyAvailable { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration? LimitCpuForMigration { get { throw null; } set { } }
        public int? MemoryMB { get { throw null; } set { } }
    }
    public partial class HardwareProfileUpdate
    {
        public HardwareProfileUpdate() { }
        public int? CpuCount { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.DynamicMemoryEnabled? DynamicMemoryEnabled { get { throw null; } set { } }
        public int? DynamicMemoryMaxMB { get { throw null; } set { } }
        public int? DynamicMemoryMinMB { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration? LimitCpuForMigration { get { throw null; } set { } }
        public int? MemoryMB { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InventoryType : System.IEquatable<Azure.ResourceManager.Arc.ScVmm.Models.InventoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InventoryType(string value) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.Models.InventoryType Cloud { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.InventoryType VirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.InventoryType VirtualMachineTemplate { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.InventoryType VirtualNetwork { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Arc.ScVmm.Models.InventoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Arc.ScVmm.Models.InventoryType left, Azure.ResourceManager.Arc.ScVmm.Models.InventoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Arc.ScVmm.Models.InventoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Arc.ScVmm.Models.InventoryType left, Azure.ResourceManager.Arc.ScVmm.Models.InventoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsCustomizable : System.IEquatable<Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsCustomizable(string value) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable False { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable left, Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable right) { throw null; }
        public static implicit operator Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable left, Azure.ResourceManager.Arc.ScVmm.Models.IsCustomizable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LimitCpuForMigration : System.IEquatable<Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LimitCpuForMigration(string value) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration False { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration left, Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration left, Azure.ResourceManager.Arc.ScVmm.Models.LimitCpuForMigration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterfaces
    {
        public NetworkInterfaces() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPv4Addresses { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod? IPv4AddressType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> IPv6Addresses { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod? IPv6AddressType { get { throw null; } set { } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod? MacAddressType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } set { } }
        public string VirtualNetworkId { get { throw null; } set { } }
    }
    public partial class NetworkInterfacesUpdate
    {
        public NetworkInterfacesUpdate() { }
        public Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod? IPv4AddressType { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod? IPv6AddressType { get { throw null; } set { } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.AllocationMethod? MacAddressType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NicId { get { throw null; } set { } }
        public string VirtualNetworkId { get { throw null; } set { } }
    }
    public partial class OSProfile
    {
        public OSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string OSName { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.OSType? OSType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSType : System.IEquatable<Azure.ResourceManager.Arc.ScVmm.Models.OSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSType(string value) { throw null; }
        public static Azure.ResourceManager.Arc.ScVmm.Models.OSType Linux { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.OSType Other { get { throw null; } }
        public static Azure.ResourceManager.Arc.ScVmm.Models.OSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Arc.ScVmm.Models.OSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Arc.ScVmm.Models.OSType left, Azure.ResourceManager.Arc.ScVmm.Models.OSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Arc.ScVmm.Models.OSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Arc.ScVmm.Models.OSType left, Azure.ResourceManager.Arc.ScVmm.Models.OSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourcePatch
    {
        public ResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class StopVirtualMachineContent
    {
        public StopVirtualMachineContent() { }
        public bool? SkipShutdown { get { throw null; } set { } }
    }
    public partial class StorageQoSPolicy
    {
        internal StorageQoSPolicy() { }
        public long? BandwidthLimit { get { throw null; } }
        public string Id { get { throw null; } }
        public long? IopsMaximum { get { throw null; } }
        public long? IopsMinimum { get { throw null; } }
        public string Name { get { throw null; } }
        public string PolicyId { get { throw null; } }
    }
    public partial class StorageQoSPolicyDetails
    {
        public StorageQoSPolicyDetails() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class VirtualDisk
    {
        public VirtualDisk() { }
        public int? Bus { get { throw null; } set { } }
        public string BusType { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.CreateDiffDisk? CreateDiffDisk { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public string DisplayName { get { throw null; } }
        public int? Lun { get { throw null; } set { } }
        public int? MaxDiskSizeGB { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.StorageQoSPolicyDetails StorageQoSPolicy { get { throw null; } set { } }
        public string TemplateDiskId { get { throw null; } set { } }
        public string VhdFormatType { get { throw null; } }
        public string VhdType { get { throw null; } set { } }
        public string VolumeType { get { throw null; } }
    }
    public partial class VirtualDiskUpdate
    {
        public VirtualDiskUpdate() { }
        public int? Bus { get { throw null; } set { } }
        public string BusType { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public int? Lun { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Arc.ScVmm.Models.StorageQoSPolicyDetails StorageQoSPolicy { get { throw null; } set { } }
        public string VhdType { get { throw null; } set { } }
    }
    public partial class VirtualMachineCreateCheckpoint
    {
        public VirtualMachineCreateCheckpoint() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class VirtualMachineDeleteCheckpoint
    {
        public VirtualMachineDeleteCheckpoint() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class VirtualMachinePatch
    {
        public VirtualMachinePatch() { }
        public Azure.ResourceManager.Arc.ScVmm.Models.VirtualMachineUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VirtualMachineRestoreCheckpoint
    {
        public VirtualMachineRestoreCheckpoint() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class VirtualMachineUpdateProperties
    {
        public VirtualMachineUpdateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Arc.ScVmm.Models.AvailabilitySetListItem> AvailabilitySets { get { throw null; } }
        public Azure.ResourceManager.Arc.ScVmm.Models.HardwareProfileUpdate HardwareProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Arc.ScVmm.Models.NetworkInterfacesUpdate> NetworkInterfaces { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Arc.ScVmm.Models.VirtualDiskUpdate> StorageDisks { get { throw null; } }
    }
    public partial class VmMServerPropertiesCredentials
    {
        public VmMServerPropertiesCredentials() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
}
