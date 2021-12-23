namespace Azure.ResourceManager.ConnectedVmware
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.ConnectedVmware.GuestAgent GetGuestAgent(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata GetHybridIdentityMetadata(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.InventoryItem GetInventoryItem(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.MachineExtension GetMachineExtension(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.ResourcePool GetResourcePool(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VCenter GetVCenter(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VirtualMachine GetVirtualMachine(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate GetVirtualMachineTemplate(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VirtualNetwork GetVirtualNetwork(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VmwareCluster GetVmwareCluster(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VmwareDatastore GetVmwareDatastore(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VmwareHost GetVmwareHost(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public partial class GuestAgent : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected GuestAgent() { }
        public virtual Azure.ResourceManager.ConnectedVmware.GuestAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName, string name) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.GuestAgentDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.GuestAgentDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.GuestAgent> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.GuestAgent>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestAgentCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.GuestAgent>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.GuestAgent>, System.Collections.IEnumerable
    {
        protected GuestAgentCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.GuestAgentCreateOperation CreateOrUpdate(string name, Azure.ResourceManager.ConnectedVmware.GuestAgentData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.GuestAgentCreateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.ConnectedVmware.GuestAgentData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.GuestAgent> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.GuestAgent> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.GuestAgent> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.GuestAgent>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.GuestAgent> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.GuestAgent>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.GuestAgent> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.GuestAgent>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.GuestAgent> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.GuestAgent>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestAgentData : Azure.ResourceManager.Models.Resource
    {
        public GuestAgentData() { }
        public Azure.ResourceManager.ConnectedVmware.Models.GuestCredential Credentials { get { throw null; } set { } }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.HttpProxyConfiguration HttpProxyConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction? ProvisioningAction { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
    }
    public partial class HybridIdentityMetadata : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected HybridIdentityMetadata() { }
        public virtual Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName, string metadataName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.HybridIdentityMetadataDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.HybridIdentityMetadataDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridIdentityMetadataCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>, System.Collections.IEnumerable
    {
        protected HybridIdentityMetadataCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.HybridIdentityMetadataCreateOperation CreateOrUpdate(string metadataName, Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadataData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.HybridIdentityMetadataCreateOperation> CreateOrUpdateAsync(string metadataName, Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadataData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata> Get(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>> GetAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata> GetIfExists(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>> GetIfExistsAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridIdentityMetadataData : Azure.ResourceManager.Models.Resource
    {
        public HybridIdentityMetadataData() { }
        public Azure.ResourceManager.ConnectedVmware.Models.VmwareIdentity Identity { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string VmId { get { throw null; } set { } }
    }
    public partial class InventoryItem : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected InventoryItem() { }
        public virtual Azure.ResourceManager.ConnectedVmware.InventoryItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vcenterName, string inventoryItemName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.InventoryItemDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.InventoryItemDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.InventoryItem> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.InventoryItem>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InventoryItemCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.InventoryItem>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.InventoryItem>, System.Collections.IEnumerable
    {
        protected InventoryItemCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.InventoryItemCreateOperation CreateOrUpdate(string inventoryItemName, Azure.ResourceManager.ConnectedVmware.InventoryItemData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.InventoryItemCreateOperation> CreateOrUpdateAsync(string inventoryItemName, Azure.ResourceManager.ConnectedVmware.InventoryItemData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.InventoryItem> Get(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.InventoryItem> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.InventoryItem> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.InventoryItem>> GetAsync(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.InventoryItem> GetIfExists(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.InventoryItem>> GetIfExistsAsync(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.InventoryItem> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.InventoryItem>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.InventoryItem> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.InventoryItem>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InventoryItemData : Azure.ResourceManager.Models.Resource
    {
        public InventoryItemData(Azure.ResourceManager.ConnectedVmware.Models.InventoryType inventoryType) { }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceId { get { throw null; } set { } }
        public string MoName { get { throw null; } set { } }
        public string MoRefId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class MachineExtension : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected MachineExtension() { }
        public virtual Azure.ResourceManager.ConnectedVmware.MachineExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionUpdateOperation Update(Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionUpdate extensionParameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionUpdateOperation> UpdateAsync(Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionUpdate extensionParameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineExtensionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.MachineExtension>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.MachineExtension>, System.Collections.IEnumerable
    {
        protected MachineExtensionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionCreateOrUpdateOperation CreateOrUpdate(string extensionName, Azure.ResourceManager.ConnectedVmware.MachineExtensionData extensionParameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionCreateOrUpdateOperation> CreateOrUpdateAsync(string extensionName, Azure.ResourceManager.ConnectedVmware.MachineExtensionData extensionParameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.MachineExtension> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.MachineExtension> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.MachineExtension> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.MachineExtension>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.MachineExtension> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.MachineExtension>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineExtensionData : Azure.ResourceManager.Models.TrackedResource
    {
        public MachineExtensionData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionPropertiesInstanceView InstanceView { get { throw null; } set { } }
        public object ProtectedSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.ConnectedVmware.ResourcePoolCollection GetResourcePools(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VCenterCollection GetVCenters(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VirtualMachineCollection GetVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplateCollection GetVirtualMachineTemplates(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VirtualNetworkCollection GetVirtualNetworks(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VmwareClusterCollection GetVmwareClusters(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VmwareDatastoreCollection GetVmwareDatastores(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.VmwareHostCollection GetVmwareHosts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class ResourcePool : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ResourcePool() { }
        public virtual Azure.ResourceManager.ConnectedVmware.ResourcePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourcePoolName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.ResourcePoolDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.ResourcePoolDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool> Update(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> UpdateAsync(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcePoolCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.ResourcePool>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.ResourcePool>, System.Collections.IEnumerable
    {
        protected ResourcePoolCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.ResourcePoolCreateOperation CreateOrUpdate(string resourcePoolName, Azure.ResourceManager.ConnectedVmware.ResourcePoolData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.ResourcePoolCreateOperation> CreateOrUpdateAsync(string resourcePoolName, Azure.ResourceManager.ConnectedVmware.ResourcePoolData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool> Get(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.ResourcePool> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.ResourcePool> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> GetAsync(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool> GetIfExists(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> GetIfExistsAsync(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.ResourcePool> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.ResourcePool>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.ResourcePool> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.ResourcePool>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourcePoolData : Azure.ResourceManager.Models.TrackedResource
    {
        public ResourcePoolData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public long? CpuLimitMHz { get { throw null; } }
        public long? CpuReservationMHz { get { throw null; } }
        public string CpuSharesLevel { get { throw null; } }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public long? MemLimitMB { get { throw null; } }
        public long? MemReservationMB { get { throw null; } }
        public string MemSharesLevel { get { throw null; } }
        public string MoName { get { throw null; } }
        public string MoRefId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VmwareCluster> GetClusters(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VmwareCluster> GetClustersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> GetDatastores(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> GetDatastoresAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VmwareHost> GetHosts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VmwareHost> GetHostsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVmware.ResourcePool> GetResourcePools(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetResourcePoolsAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetResourcePoolsAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.ResourcePool> GetResourcePoolsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VCenter> GetVCenters(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVCentersAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVCentersAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VCenter> GetVCentersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VirtualMachine> GetVirtualMachines(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualMachinesAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualMachinesAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VirtualMachine> GetVirtualMachinesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> GetVirtualMachineTemplates(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualMachineTemplatesAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualMachineTemplatesAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> GetVirtualMachineTemplatesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> GetVirtualNetworks(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualNetworksAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualNetworksAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> GetVirtualNetworksAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVmwareClustersAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVmwareClustersAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVmwareDatastoresAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVmwareDatastoresAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVmwareHostsAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVmwareHostsAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VCenter : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VCenter() { }
        public virtual Azure.ResourceManager.ConnectedVmware.VCenterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vcenterName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VCenterDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VCenterDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ConnectedVmware.InventoryItemCollection GetInventoryItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter> Update(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> UpdateAsync(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VCenterCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VCenter>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VCenter>, System.Collections.IEnumerable
    {
        protected VCenterCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VCenterCreateOperation CreateOrUpdate(string vcenterName, Azure.ResourceManager.ConnectedVmware.VCenterData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VCenterCreateOperation> CreateOrUpdateAsync(string vcenterName, Azure.ResourceManager.ConnectedVmware.VCenterData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter> Get(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VCenter> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VCenter> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> GetAsync(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter> GetIfExists(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> GetIfExistsAsync(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.VCenter> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VCenter>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.VCenter> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VCenter>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VCenterData : Azure.ResourceManager.Models.TrackedResource
    {
        public VCenterData(Azure.ResourceManager.Resources.Models.Location location, string fqdn) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string ConnectionStatus { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.VICredential Credentials { get { throw null; } set { } }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        public string InstanceUuid { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class VirtualMachine : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VirtualMachine() { }
        public virtual Azure.ResourceManager.ConnectedVmware.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadataCollection GetAllHybridIdentityMetadata() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ConnectedVmware.GuestAgentCollection GetGuestAgents() { throw null; }
        public Azure.ResourceManager.ConnectedVmware.MachineExtensionCollection GetMachineExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineRestartOperation Restart(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineRestartOperation> RestartAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineStartOperation Start(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineStartOperation> StartAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineStopOperation Stop(Azure.ResourceManager.ConnectedVmware.Models.StopVirtualMachineOptions body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineStopOperation> StopAsync(Azure.ResourceManager.ConnectedVmware.Models.StopVirtualMachineOptions body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineUpdateOperation Update(Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineUpdate body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineUpdateOperation> UpdateAsync(Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineUpdate body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualMachine>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualMachine>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineCreateOperation CreateOrUpdate(string virtualMachineName, Azure.ResourceManager.ConnectedVmware.VirtualMachineData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineCreateOperation> CreateOrUpdateAsync(string virtualMachineName, Azure.ResourceManager.ConnectedVmware.VirtualMachineData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine> Get(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VirtualMachine> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VirtualMachine> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> GetAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine> GetIfExists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> GetIfExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.VirtualMachine> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualMachine>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.VirtualMachine> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualMachine>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.FirmwareType? FirmwareType { get { throw null; } set { } }
        public string FolderPath { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.GuestAgentProfile GuestAgentProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.VmwareIdentity Identity { get { throw null; } set { } }
        public string InstanceUuid { get { throw null; } }
        public string InventoryItemId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string MoName { get { throw null; } }
        public string MoRefId { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.OsProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.PlacementProfile PlacementProfile { get { throw null; } set { } }
        public string PowerState { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ResourcePoolId { get { throw null; } set { } }
        public string SmbiosUuid { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string TemplateId { get { throw null; } set { } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
        public string VmId { get { throw null; } }
    }
    public partial class VirtualMachineTemplate : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VirtualMachineTemplate() { }
        public virtual Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineTemplateDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineTemplateDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> Update(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> UpdateAsync(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineTemplateCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>, System.Collections.IEnumerable
    {
        protected VirtualMachineTemplateCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineTemplateCreateOperation CreateOrUpdate(string virtualMachineTemplateName, Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplateData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualMachineTemplateCreateOperation> CreateOrUpdateAsync(string virtualMachineTemplateName, Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplateData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> Get(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> GetAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> GetIfExists(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> GetIfExistsAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineTemplateData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineTemplateData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string CustomResourceName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.VirtualDisk> Disks { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.FirmwareType? FirmwareType { get { throw null; } }
        public string FolderPath { get { throw null; } }
        public string InventoryItemId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public int? MemorySizeMB { get { throw null; } }
        public string MoName { get { throw null; } }
        public string MoRefId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public int? NumCoresPerSocket { get { throw null; } }
        public int? NumCPUs { get { throw null; } }
        public string OsName { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.OsType? OsType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string ToolsVersion { get { throw null; } }
        public string ToolsVersionStatus { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
    public partial class VirtualNetwork : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VirtualNetwork() { }
        public virtual Azure.ResourceManager.ConnectedVmware.VirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualNetworkDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualNetworkDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> Update(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> UpdateAsync(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>, System.Collections.IEnumerable
    {
        protected VirtualNetworkCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.VirtualNetworkCreateOperation CreateOrUpdate(string virtualNetworkName, Azure.ResourceManager.ConnectedVmware.VirtualNetworkData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.VirtualNetworkCreateOperation> CreateOrUpdateAsync(string virtualNetworkName, Azure.ResourceManager.ConnectedVmware.VirtualNetworkData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> Get(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> GetAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> GetIfExists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> GetIfExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.VirtualNetwork> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualNetworkData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string MoName { get { throw null; } }
        public string MoRefId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
    public partial class VmwareCluster : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VmwareCluster() { }
        public virtual Azure.ResourceManager.ConnectedVmware.VmwareClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.ClusterDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.ClusterDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster> Update(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> UpdateAsync(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmwareClusterCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareCluster>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareCluster>, System.Collections.IEnumerable
    {
        protected VmwareClusterCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.ClusterCreateOperation CreateOrUpdate(string clusterName, Azure.ResourceManager.ConnectedVmware.VmwareClusterData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.ClusterCreateOperation> CreateOrUpdateAsync(string clusterName, Azure.ResourceManager.ConnectedVmware.VmwareClusterData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VmwareCluster> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VmwareCluster> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.VmwareCluster> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareCluster>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.VmwareCluster> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareCluster>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VmwareClusterData : Azure.ResourceManager.Models.TrackedResource
    {
        public VmwareClusterData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string CustomResourceName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DatastoreIds { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string MoName { get { throw null; } }
        public string MoRefId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> NetworkIds { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
    public partial class VmwareDatastore : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VmwareDatastore() { }
        public virtual Azure.ResourceManager.ConnectedVmware.VmwareDatastoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string datastoreName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.DatastoreDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.DatastoreDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> Update(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> UpdateAsync(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmwareDatastoreCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>, System.Collections.IEnumerable
    {
        protected VmwareDatastoreCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.DatastoreCreateOperation CreateOrUpdate(string datastoreName, Azure.ResourceManager.ConnectedVmware.VmwareDatastoreData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.DatastoreCreateOperation> CreateOrUpdateAsync(string datastoreName, Azure.ResourceManager.ConnectedVmware.VmwareDatastoreData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> Get(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> GetAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> GetIfExists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> GetIfExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.VmwareDatastore> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VmwareDatastoreData : Azure.ResourceManager.Models.TrackedResource
    {
        public VmwareDatastoreData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string MoName { get { throw null; } }
        public string MoRefId { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
    public partial class VmwareHost : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VmwareHost() { }
        public virtual Azure.ResourceManager.ConnectedVmware.VmwareHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.HostDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.HostDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost> Update(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> UpdateAsync(Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmwareHostCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareHost>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareHost>, System.Collections.IEnumerable
    {
        protected VmwareHostCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVmware.Models.HostCreateOperation CreateOrUpdate(string hostName, Azure.ResourceManager.ConnectedVmware.VmwareHostData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVmware.Models.HostCreateOperation> CreateOrUpdateAsync(string hostName, Azure.ResourceManager.ConnectedVmware.VmwareHostData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost> Get(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVmware.VmwareHost> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVmware.VmwareHost> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> GetAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost> GetIfExists(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> GetIfExistsAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVmware.VmwareHost> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareHost>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVmware.VmwareHost> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVmware.VmwareHost>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VmwareHostData : Azure.ResourceManager.Models.TrackedResource
    {
        public VmwareHostData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public string InventoryItemId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string MoName { get { throw null; } }
        public string MoRefId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.ConnectedVmware.Models
{
    public partial class ClusterCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VmwareCluster>
    {
        protected ClusterCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VmwareCluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterDeleteOperation : Azure.Operation
    {
        protected ClusterDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VmwareCluster>
    {
        protected ClusterUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VmwareCluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareCluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.CreatedByType left, Azure.ResourceManager.ConnectedVmware.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.CreatedByType left, Azure.ResourceManager.ConnectedVmware.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatastoreCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>
    {
        protected DatastoreCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VmwareDatastore Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreDeleteOperation : Azure.Operation
    {
        protected DatastoreDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>
    {
        protected DatastoreUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VmwareDatastore Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareDatastore>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskMode : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.DiskMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskMode(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskMode IndependentNonpersistent { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskMode IndependentPersistent { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskMode Persistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.DiskMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.DiskMode left, Azure.ResourceManager.ConnectedVmware.Models.DiskMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.DiskMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.DiskMode left, Azure.ResourceManager.ConnectedVmware.Models.DiskMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskType : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.DiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskType Flat { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskType Pmem { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskType Rawphysical { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskType Rawvirtual { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskType Sesparse { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskType Sparse { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.DiskType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.DiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.DiskType left, Azure.ResourceManager.ConnectedVmware.Models.DiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.DiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.DiskType left, Azure.ResourceManager.ConnectedVmware.Models.DiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ErrorDetail
    {
        internal ErrorDetail() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirmwareType : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.FirmwareType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirmwareType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.FirmwareType Bios { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.FirmwareType Efi { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.FirmwareType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.FirmwareType left, Azure.ResourceManager.ConnectedVmware.Models.FirmwareType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.FirmwareType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.FirmwareType left, Azure.ResourceManager.ConnectedVmware.Models.FirmwareType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuestAgentCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.GuestAgent>
    {
        protected GuestAgentCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.GuestAgent Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.GuestAgent>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.GuestAgent>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestAgentDeleteOperation : Azure.Operation
    {
        protected GuestAgentDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestAgentProfile
    {
        public GuestAgentProfile() { }
        public string AgentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.ErrorDetail> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusChange { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.StatusTypes? Status { get { throw null; } }
        public string VmUuid { get { throw null; } }
    }
    public partial class GuestCredential
    {
        public GuestCredential() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class HardwareProfile
    {
        public HardwareProfile() { }
        public bool? CpuHotAddEnabled { get { throw null; } }
        public bool? CpuHotRemoveEnabled { get { throw null; } }
        public bool? MemoryHotAddEnabled { get { throw null; } }
        public int? MemorySizeMB { get { throw null; } set { } }
        public int? NumCoresPerSocket { get { throw null; } set { } }
        public int? NumCPUs { get { throw null; } set { } }
    }
    public partial class HostCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VmwareHost>
    {
        protected HostCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VmwareHost Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostDeleteOperation : Azure.Operation
    {
        protected HostDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VmwareHost>
    {
        protected HostUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VmwareHost Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VmwareHost>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HttpProxyConfiguration
    {
        public HttpProxyConfiguration() { }
        public string HttpsProxy { get { throw null; } set { } }
    }
    public partial class HybridIdentityMetadataCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>
    {
        protected HybridIdentityMetadataCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.HybridIdentityMetadata>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridIdentityMetadataDeleteOperation : Azure.Operation
    {
        protected HybridIdentityMetadataDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.IdentityType None { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.IdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.IdentityType left, Azure.ResourceManager.ConnectedVmware.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.IdentityType left, Azure.ResourceManager.ConnectedVmware.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InventoryItemCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.InventoryItem>
    {
        protected InventoryItemCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.InventoryItem Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.InventoryItem>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.InventoryItem>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InventoryItemDeleteOperation : Azure.Operation
    {
        protected InventoryItemDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InventoryType : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.InventoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InventoryType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.InventoryType Cluster { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.InventoryType Datastore { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.InventoryType Host { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.InventoryType ResourcePool { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.InventoryType VirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.InventoryType VirtualMachineTemplate { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.InventoryType VirtualNetwork { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.InventoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.InventoryType left, Azure.ResourceManager.ConnectedVmware.Models.InventoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.InventoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.InventoryType left, Azure.ResourceManager.ConnectedVmware.Models.InventoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAddressAllocationMethod : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAddressAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod Linklayer { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod Other { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod Random { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod Static { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod Unset { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod left, Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod left, Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineExtensionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.MachineExtension>
    {
        protected MachineExtensionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.MachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineExtensionDeleteOperation : Azure.Operation
    {
        protected MachineExtensionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineExtensionInstanceView
    {
        public MachineExtensionInstanceView() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionInstanceViewStatus Status { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
    }
    public partial class MachineExtensionInstanceViewStatus
    {
        public MachineExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class MachineExtensionPropertiesInstanceView : Azure.ResourceManager.ConnectedVmware.Models.MachineExtensionInstanceView
    {
        public MachineExtensionPropertiesInstanceView() { }
    }
    public partial class MachineExtensionUpdate : Azure.ResourceManager.ConnectedVmware.Models.ResourcePatch
    {
        public MachineExtensionUpdate() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public object ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class MachineExtensionUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.MachineExtension>
    {
        protected MachineExtensionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.MachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.MachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkInterface
    {
        public NetworkInterface() { }
        public int? DeviceKey { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> IpAddresses { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.NicIPSettings IpSettings { get { throw null; } set { } }
        public string Label { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string NetworkId { get { throw null; } set { } }
        public string NetworkMoName { get { throw null; } }
        public string NetworkMoRefId { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.NICType? NicType { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption? PowerOnBoot { get { throw null; } set { } }
    }
    public partial class NetworkInterfaceUpdate
    {
        public NetworkInterfaceUpdate() { }
        public int? DeviceKey { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.NICType? NicType { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption? PowerOnBoot { get { throw null; } set { } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConnectedVmware.Models.NetworkInterface> NetworkInterfaces { get { throw null; } }
    }
    public partial class NetworkProfileUpdate
    {
        public NetworkProfileUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConnectedVmware.Models.NetworkInterfaceUpdate> NetworkInterfaces { get { throw null; } }
    }
    public partial class NicIPAddressSettings
    {
        internal NicIPAddressSettings() { }
        public string AllocationMethod { get { throw null; } }
        public string IpAddress { get { throw null; } }
        public string SubnetMask { get { throw null; } }
    }
    public partial class NicIPSettings
    {
        public NicIPSettings() { }
        public Azure.ResourceManager.ConnectedVmware.Models.IPAddressAllocationMethod? AllocationMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public System.Collections.Generic.IList<string> Gateway { get { throw null; } }
        public string IpAddress { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.NicIPAddressSettings> IpAddressInfo { get { throw null; } }
        public string PrimaryWinsServer { get { throw null; } }
        public string SecondaryWinsServer { get { throw null; } }
        public string SubnetMask { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NICType : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.NICType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NICType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.NICType E1000 { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.NICType E1000E { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.NICType Pcnet32 { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.NICType Vmxnet { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.NICType Vmxnet2 { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.NICType Vmxnet3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.NICType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.NICType left, Azure.ResourceManager.ConnectedVmware.Models.NICType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.NICType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.NICType left, Azure.ResourceManager.ConnectedVmware.Models.NICType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OsProfile
    {
        public OsProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string OsName { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.OsType? OsType { get { throw null; } set { } }
        public string ToolsRunningStatus { get { throw null; } }
        public string ToolsVersion { get { throw null; } }
        public string ToolsVersionStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OsType : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.OsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OsType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.OsType Linux { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.OsType Other { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.OsType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.OsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.OsType left, Azure.ResourceManager.ConnectedVmware.Models.OsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.OsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.OsType left, Azure.ResourceManager.ConnectedVmware.Models.OsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlacementProfile
    {
        public PlacementProfile() { }
        public string ClusterId { get { throw null; } set { } }
        public string DatastoreId { get { throw null; } set { } }
        public string HostId { get { throw null; } set { } }
        public string ResourcePoolId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PowerOnBootOption : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerOnBootOption(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption Disabled { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption left, Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption left, Azure.ResourceManager.ConnectedVmware.Models.PowerOnBootOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningAction : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningAction(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction Install { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction Repair { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction Uninstall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction left, Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction left, Azure.ResourceManager.ConnectedVmware.Models.ProvisioningAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState left, Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState left, Azure.ResourceManager.ConnectedVmware.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourcePatch
    {
        public ResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ResourcePoolCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.ResourcePool>
    {
        protected ResourcePoolCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.ResourcePool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcePoolDeleteOperation : Azure.Operation
    {
        protected ResourcePoolDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcePoolUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.ResourcePool>
    {
        protected ResourcePoolUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.ResourcePool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.ResourcePool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceStatus
    {
        internal ResourceStatus() { }
        public System.DateTimeOffset? LastUpdatedAt { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        public string Severity { get { throw null; } }
        public string Status { get { throw null; } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScsiControllerType : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScsiControllerType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType Buslogic { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType Lsilogic { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType Lsilogicsas { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType Pvscsi { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType left, Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType left, Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusLevelTypes : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusLevelTypes(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes Error { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes Info { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes left, Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes left, Azure.ResourceManager.ConnectedVmware.Models.StatusLevelTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusTypes : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.StatusTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusTypes(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.StatusTypes Connected { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.StatusTypes Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.StatusTypes Error { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.StatusTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.StatusTypes left, Azure.ResourceManager.ConnectedVmware.Models.StatusTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.StatusTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.StatusTypes left, Azure.ResourceManager.ConnectedVmware.Models.StatusTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StopVirtualMachineOptions
    {
        public StopVirtualMachineOptions() { }
        public bool? SkipShutdown { get { throw null; } set { } }
    }
    public partial class StorageProfile
    {
        public StorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConnectedVmware.Models.VirtualDisk> Disks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiController> ScsiControllers { get { throw null; } }
    }
    public partial class StorageProfileUpdate
    {
        public StorageProfileUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConnectedVmware.Models.VirtualDiskUpdate> Disks { get { throw null; } }
    }
    public partial class VCenterCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VCenter>
    {
        protected VCenterCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VCenter Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VCenterDeleteOperation : Azure.Operation
    {
        protected VCenterDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VCenterUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VCenter>
    {
        protected VCenterUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VCenter Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VCenter>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VICredential
    {
        public VICredential() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class VirtualDisk
    {
        public VirtualDisk() { }
        public int? ControllerKey { get { throw null; } set { } }
        public int? DeviceKey { get { throw null; } set { } }
        public string DeviceName { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.DiskMode? DiskMode { get { throw null; } set { } }
        public string DiskObjectId { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.DiskType? DiskType { get { throw null; } set { } }
        public string Label { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int? UnitNumber { get { throw null; } set { } }
    }
    public partial class VirtualDiskUpdate
    {
        public VirtualDiskUpdate() { }
        public int? ControllerKey { get { throw null; } set { } }
        public int? DeviceKey { get { throw null; } set { } }
        public string DeviceName { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.DiskMode? DiskMode { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.DiskType? DiskType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? UnitNumber { get { throw null; } set { } }
    }
    public partial class VirtualMachineCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VirtualMachine>
    {
        protected VirtualMachineCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VirtualMachine Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineDeleteOperation : Azure.Operation
    {
        protected VirtualMachineDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRestartOperation : Azure.Operation
    {
        protected VirtualMachineRestartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineStartOperation : Azure.Operation
    {
        protected VirtualMachineStartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineStopOperation : Azure.Operation
    {
        protected VirtualMachineStopOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineTemplateCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>
    {
        protected VirtualMachineTemplateCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineTemplateDeleteOperation : Azure.Operation
    {
        protected VirtualMachineTemplateDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineTemplateUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>
    {
        protected VirtualMachineTemplateUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachineTemplate>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineUpdate
    {
        public VirtualMachineUpdate() { }
        public Azure.ResourceManager.ConnectedVmware.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.VmwareIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.NetworkProfileUpdate NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVmware.Models.StorageProfileUpdate StorageProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VirtualMachineUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VirtualMachine>
    {
        protected VirtualMachineUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VirtualMachine Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualMachine>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>
    {
        protected VirtualNetworkCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VirtualNetwork Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkDeleteOperation : Azure.Operation
    {
        protected VirtualNetworkDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>
    {
        protected VirtualNetworkUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVmware.VirtualNetwork Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVmware.VirtualNetwork>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualScsiController
    {
        internal VirtualScsiController() { }
        public int? BusNumber { get { throw null; } }
        public int? ControllerKey { get { throw null; } }
        public int? ScsiCtlrUnitNumber { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing? Sharing { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.ScsiControllerType? Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualScsiSharing : System.IEquatable<Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualScsiSharing(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing NoSharing { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing PhysicalSharing { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing VirtualSharing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing left, Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing left, Azure.ResourceManager.ConnectedVmware.Models.VirtualScsiSharing right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmwareIdentity
    {
        public VmwareIdentity(Azure.ResourceManager.ConnectedVmware.Models.IdentityType type) { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.ConnectedVmware.Models.IdentityType Type { get { throw null; } set { } }
    }
}
