namespace Azure.ResourceManager.ConnectedVMware
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.ConnectedVMware.GuestAgent GetGuestAgent(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata GetHybridIdentityMetadata(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.InventoryItem GetInventoryItem(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.MachineExtension GetMachineExtension(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.ResourcePool GetResourcePool(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VCenter GetVCenter(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VirtualMachine GetVirtualMachine(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate GetVirtualMachineTemplate(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VirtualNetwork GetVirtualNetwork(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VmwareCluster GetVmwareCluster(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VmwareDatastore GetVmwareDatastore(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VmwareHost GetVmwareHost(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public partial class GuestAgent : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected GuestAgent() { }
        public virtual Azure.ResourceManager.ConnectedVMware.GuestAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName, string name) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.GuestAgentDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.GuestAgentDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.GuestAgent> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.GuestAgent>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestAgentCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.GuestAgent>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.GuestAgent>, System.Collections.IEnumerable
    {
        protected GuestAgentCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.GuestAgentCreateOperation CreateOrUpdate(string name, Azure.ResourceManager.ConnectedVMware.GuestAgentData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.GuestAgentCreateOperation> CreateOrUpdateAsync(string name, Azure.ResourceManager.ConnectedVMware.GuestAgentData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.GuestAgent> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.GuestAgent> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.GuestAgent> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.GuestAgent>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.GuestAgent> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.GuestAgent>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.GuestAgent> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.GuestAgent>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.GuestAgent> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.GuestAgent>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestAgentData : Azure.ResourceManager.Models.Resource
    {
        public GuestAgentData() { }
        public Azure.ResourceManager.ConnectedVMware.Models.GuestCredential Credentials { get { throw null; } set { } }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.HttpProxyConfiguration HttpProxyConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction? ProvisioningAction { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
    }
    public partial class HybridIdentityMetadata : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected HybridIdentityMetadata() { }
        public virtual Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName, string metadataName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.HybridIdentityMetadataDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.HybridIdentityMetadataDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridIdentityMetadataCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>, System.Collections.IEnumerable
    {
        protected HybridIdentityMetadataCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.HybridIdentityMetadataCreateOperation CreateOrUpdate(string metadataName, Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadataData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.HybridIdentityMetadataCreateOperation> CreateOrUpdateAsync(string metadataName, Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadataData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata> Get(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>> GetAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata> GetIfExists(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>> GetIfExistsAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridIdentityMetadataData : Azure.ResourceManager.Models.Resource
    {
        public HybridIdentityMetadataData() { }
        public Azure.ResourceManager.ConnectedVMware.Models.VmwareIdentity Identity { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string VmId { get { throw null; } set { } }
    }
    public partial class InventoryItem : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected InventoryItem() { }
        public virtual Azure.ResourceManager.ConnectedVMware.InventoryItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vcenterName, string inventoryItemName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.InventoryItemDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.InventoryItemDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.InventoryItem> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.InventoryItem>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InventoryItemCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.InventoryItem>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.InventoryItem>, System.Collections.IEnumerable
    {
        protected InventoryItemCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.InventoryItemCreateOperation CreateOrUpdate(string inventoryItemName, Azure.ResourceManager.ConnectedVMware.InventoryItemData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.InventoryItemCreateOperation> CreateOrUpdateAsync(string inventoryItemName, Azure.ResourceManager.ConnectedVMware.InventoryItemData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.InventoryItem> Get(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.InventoryItem> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.InventoryItem> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.InventoryItem>> GetAsync(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.InventoryItem> GetIfExists(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.InventoryItem>> GetIfExistsAsync(string inventoryItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.InventoryItem> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.InventoryItem>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.InventoryItem> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.InventoryItem>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InventoryItemData : Azure.ResourceManager.Models.Resource
    {
        public InventoryItemData(Azure.ResourceManager.ConnectedVMware.Models.InventoryType inventoryType) { }
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
        public virtual Azure.ResourceManager.ConnectedVMware.MachineExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionUpdateOperation Update(Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionUpdate extensionParameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionUpdateOperation> UpdateAsync(Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionUpdate extensionParameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineExtensionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.MachineExtension>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.MachineExtension>, System.Collections.IEnumerable
    {
        protected MachineExtensionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionCreateOrUpdateOperation CreateOrUpdate(string extensionName, Azure.ResourceManager.ConnectedVMware.MachineExtensionData extensionParameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionCreateOrUpdateOperation> CreateOrUpdateAsync(string extensionName, Azure.ResourceManager.ConnectedVMware.MachineExtensionData extensionParameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.MachineExtension> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.MachineExtension> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.MachineExtension> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.MachineExtension>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.MachineExtension> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.MachineExtension>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineExtensionData : Azure.ResourceManager.Models.TrackedResource
    {
        public MachineExtensionData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionPropertiesInstanceView InstanceView { get { throw null; } set { } }
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
        public static Azure.ResourceManager.ConnectedVMware.ResourcePoolCollection GetResourcePools(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VCenterCollection GetVCenters(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VirtualMachineCollection GetVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplateCollection GetVirtualMachineTemplates(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VirtualNetworkCollection GetVirtualNetworks(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VmwareClusterCollection GetVmwareClusters(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VmwareDatastoreCollection GetVmwareDatastores(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.VmwareHostCollection GetVmwareHosts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class ResourcePool : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ResourcePool() { }
        public virtual Azure.ResourceManager.ConnectedVMware.ResourcePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourcePoolName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.ResourcePoolDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.ResourcePoolDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool> Update(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> UpdateAsync(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcePoolCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.ResourcePool>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.ResourcePool>, System.Collections.IEnumerable
    {
        protected ResourcePoolCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.ResourcePoolCreateOperation CreateOrUpdate(string resourcePoolName, Azure.ResourceManager.ConnectedVMware.ResourcePoolData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.ResourcePoolCreateOperation> CreateOrUpdateAsync(string resourcePoolName, Azure.ResourceManager.ConnectedVMware.ResourcePoolData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool> Get(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.ResourcePool> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.ResourcePool> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> GetAsync(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool> GetIfExists(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> GetIfExistsAsync(string resourcePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.ResourcePool> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.ResourcePool>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.ResourcePool> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.ResourcePool>.GetEnumerator() { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VmwareCluster> GetClusters(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VmwareCluster> GetClustersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> GetDatastores(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> GetDatastoresAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VmwareHost> GetHosts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VmwareHost> GetHostsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVMware.ResourcePool> GetResourcePools(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetResourcePoolsAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetResourcePoolsAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.ResourcePool> GetResourcePoolsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VCenter> GetVCenters(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVCentersAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVCentersAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VCenter> GetVCentersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VirtualMachine> GetVirtualMachines(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualMachinesAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualMachinesAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VirtualMachine> GetVirtualMachinesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> GetVirtualMachineTemplates(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualMachineTemplatesAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualMachineTemplatesAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> GetVirtualMachineTemplatesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> GetVirtualNetworks(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualNetworksAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetVirtualNetworksAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> GetVirtualNetworksAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ConnectedVMware.VCenterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vcenterName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VCenterDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VCenterDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ConnectedVMware.InventoryItemCollection GetInventoryItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter> Update(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> UpdateAsync(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VCenterCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VCenter>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VCenter>, System.Collections.IEnumerable
    {
        protected VCenterCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VCenterCreateOperation CreateOrUpdate(string vcenterName, Azure.ResourceManager.ConnectedVMware.VCenterData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VCenterCreateOperation> CreateOrUpdateAsync(string vcenterName, Azure.ResourceManager.ConnectedVMware.VCenterData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter> Get(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VCenter> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VCenter> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> GetAsync(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter> GetIfExists(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> GetIfExistsAsync(string vcenterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.VCenter> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VCenter>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.VCenter> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VCenter>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VCenterData : Azure.ResourceManager.Models.TrackedResource
    {
        public VCenterData(Azure.ResourceManager.Resources.Models.Location location, string fqdn) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string ConnectionStatus { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.VICredential Credentials { get { throw null; } set { } }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        public string InstanceUuid { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class VirtualMachine : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VirtualMachine() { }
        public virtual Azure.ResourceManager.ConnectedVMware.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadataCollection GetAllHybridIdentityMetadata() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ConnectedVMware.GuestAgentCollection GetGuestAgents() { throw null; }
        public Azure.ResourceManager.ConnectedVMware.MachineExtensionCollection GetMachineExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineRestartOperation Restart(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineRestartOperation> RestartAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineStartOperation Start(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineStartOperation> StartAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineStopOperation Stop(Azure.ResourceManager.ConnectedVMware.Models.StopVirtualMachineOptions body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineStopOperation> StopAsync(Azure.ResourceManager.ConnectedVMware.Models.StopVirtualMachineOptions body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineUpdateOperation Update(Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineUpdate body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineUpdateOperation> UpdateAsync(Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineUpdate body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualMachine>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualMachine>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineCreateOperation CreateOrUpdate(string virtualMachineName, Azure.ResourceManager.ConnectedVMware.VirtualMachineData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineCreateOperation> CreateOrUpdateAsync(string virtualMachineName, Azure.ResourceManager.ConnectedVMware.VirtualMachineData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine> Get(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VirtualMachine> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VirtualMachine> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> GetAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine> GetIfExists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> GetIfExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.VirtualMachine> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualMachine>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.VirtualMachine> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualMachine>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string CustomResourceName { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.FirmwareType? FirmwareType { get { throw null; } set { } }
        public string FolderPath { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.GuestAgentProfile GuestAgentProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.VmwareIdentity Identity { get { throw null; } set { } }
        public string InstanceUuid { get { throw null; } }
        public string InventoryItemId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string MoName { get { throw null; } }
        public string MoRefId { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.OsProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.PlacementProfile PlacementProfile { get { throw null; } set { } }
        public string PowerState { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ResourcePoolId { get { throw null; } set { } }
        public string SmbiosUuid { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.StorageProfile StorageProfile { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineTemplateDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineTemplateDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> Update(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> UpdateAsync(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineTemplateCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>, System.Collections.IEnumerable
    {
        protected VirtualMachineTemplateCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineTemplateCreateOperation CreateOrUpdate(string virtualMachineTemplateName, Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplateData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualMachineTemplateCreateOperation> CreateOrUpdateAsync(string virtualMachineTemplateName, Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplateData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> Get(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> GetAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> GetIfExists(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> GetIfExistsAsync(string virtualMachineTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineTemplateData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineTemplateData(Azure.ResourceManager.Resources.Models.Location location) : base (default(Azure.ResourceManager.Resources.Models.Location)) { }
        public string CustomResourceName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.VirtualDisk> Disks { get { throw null; } }
        public Azure.ResourceManager.Models.CheckNameAvailabilityRequest ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.FirmwareType? FirmwareType { get { throw null; } }
        public string FolderPath { get { throw null; } }
        public string InventoryItemId { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public int? MemorySizeMB { get { throw null; } }
        public string MoName { get { throw null; } }
        public string MoRefId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public int? NumCoresPerSocket { get { throw null; } }
        public int? NumCPUs { get { throw null; } }
        public string OsName { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.OsType? OsType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ResourceStatus> Statuses { get { throw null; } }
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
        public virtual Azure.ResourceManager.ConnectedVMware.VirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualNetworkDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualNetworkDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> Update(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> UpdateAsync(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>, System.Collections.IEnumerable
    {
        protected VirtualNetworkCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.VirtualNetworkCreateOperation CreateOrUpdate(string virtualNetworkName, Azure.ResourceManager.ConnectedVMware.VirtualNetworkData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.VirtualNetworkCreateOperation> CreateOrUpdateAsync(string virtualNetworkName, Azure.ResourceManager.ConnectedVMware.VirtualNetworkData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> Get(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> GetAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> GetIfExists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> GetIfExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.VirtualNetwork> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>.GetEnumerator() { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
    public partial class VmwareCluster : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VmwareCluster() { }
        public virtual Azure.ResourceManager.ConnectedVMware.VmwareClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.ClusterDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.ClusterDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster> Update(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> UpdateAsync(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmwareClusterCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareCluster>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareCluster>, System.Collections.IEnumerable
    {
        protected VmwareClusterCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.ClusterCreateOperation CreateOrUpdate(string clusterName, Azure.ResourceManager.ConnectedVMware.VmwareClusterData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.ClusterCreateOperation> CreateOrUpdateAsync(string clusterName, Azure.ResourceManager.ConnectedVMware.VmwareClusterData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VmwareCluster> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VmwareCluster> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.VmwareCluster> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareCluster>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.VmwareCluster> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareCluster>.GetEnumerator() { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
    public partial class VmwareDatastore : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VmwareDatastore() { }
        public virtual Azure.ResourceManager.ConnectedVMware.VmwareDatastoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string datastoreName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.DatastoreDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.DatastoreDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> Update(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> UpdateAsync(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmwareDatastoreCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>, System.Collections.IEnumerable
    {
        protected VmwareDatastoreCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.DatastoreCreateOperation CreateOrUpdate(string datastoreName, Azure.ResourceManager.ConnectedVMware.VmwareDatastoreData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.DatastoreCreateOperation> CreateOrUpdateAsync(string datastoreName, Azure.ResourceManager.ConnectedVMware.VmwareDatastoreData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> Get(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> GetAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> GetIfExists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> GetIfExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.VmwareDatastore> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>.GetEnumerator() { throw null; }
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
        public Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
    public partial class VmwareHost : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected VmwareHost() { }
        public virtual Azure.ResourceManager.ConnectedVMware.VmwareHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostName) { throw null; }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.HostDeleteOperation Delete(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.HostDeleteOperation> DeleteAsync(bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost> Update(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> UpdateAsync(Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VmwareHostCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareHost>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareHost>, System.Collections.IEnumerable
    {
        protected VmwareHostCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ConnectedVMware.Models.HostCreateOperation CreateOrUpdate(string hostName, Azure.ResourceManager.ConnectedVMware.VmwareHostData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ConnectedVMware.Models.HostCreateOperation> CreateOrUpdateAsync(string hostName, Azure.ResourceManager.ConnectedVMware.VmwareHostData body = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost> Get(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConnectedVMware.VmwareHost> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConnectedVMware.VmwareHost> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> GetAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost> GetIfExists(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> GetIfExistsAsync(string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConnectedVMware.VmwareHost> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareHost>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConnectedVMware.VmwareHost> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConnectedVMware.VmwareHost>.GetEnumerator() { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ResourceStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string Uuid { get { throw null; } }
        public string VCenterId { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.ConnectedVMware.Models
{
    public partial class ClusterCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VmwareCluster>
    {
        protected ClusterCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VmwareCluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ClusterUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VmwareCluster>
    {
        protected ClusterUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VmwareCluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareCluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.CreatedByType left, Azure.ResourceManager.ConnectedVMware.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.CreatedByType left, Azure.ResourceManager.ConnectedVMware.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatastoreCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>
    {
        protected DatastoreCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VmwareDatastore Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DatastoreUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>
    {
        protected DatastoreUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VmwareDatastore Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareDatastore>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskMode : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.DiskMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskMode(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskMode IndependentNonpersistent { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskMode IndependentPersistent { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskMode Persistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.DiskMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.DiskMode left, Azure.ResourceManager.ConnectedVMware.Models.DiskMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.DiskMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.DiskMode left, Azure.ResourceManager.ConnectedVMware.Models.DiskMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskType : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.DiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskType Flat { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskType Pmem { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskType Rawphysical { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskType Rawvirtual { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskType Sesparse { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskType Sparse { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.DiskType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.DiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.DiskType left, Azure.ResourceManager.ConnectedVMware.Models.DiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.DiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.DiskType left, Azure.ResourceManager.ConnectedVMware.Models.DiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ErrorDetail
    {
        internal ErrorDetail() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirmwareType : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.FirmwareType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirmwareType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.FirmwareType Bios { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.FirmwareType Efi { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.FirmwareType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.FirmwareType left, Azure.ResourceManager.ConnectedVMware.Models.FirmwareType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.FirmwareType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.FirmwareType left, Azure.ResourceManager.ConnectedVMware.Models.FirmwareType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuestAgentCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.GuestAgent>
    {
        protected GuestAgentCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.GuestAgent Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.GuestAgent>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.GuestAgent>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.ErrorDetail> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusChange { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.StatusTypes? Status { get { throw null; } }
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
    public partial class HostCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VmwareHost>
    {
        protected HostCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VmwareHost Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class HostUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VmwareHost>
    {
        protected HostUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VmwareHost Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VmwareHost>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HttpProxyConfiguration
    {
        public HttpProxyConfiguration() { }
        public string HttpsProxy { get { throw null; } set { } }
    }
    public partial class HybridIdentityMetadataCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>
    {
        protected HybridIdentityMetadataCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.HybridIdentityMetadata>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.IdentityType None { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.IdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.IdentityType left, Azure.ResourceManager.ConnectedVMware.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.IdentityType left, Azure.ResourceManager.ConnectedVMware.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InventoryItemCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.InventoryItem>
    {
        protected InventoryItemCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.InventoryItem Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.InventoryItem>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.InventoryItem>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public readonly partial struct InventoryType : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.InventoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InventoryType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.InventoryType Cluster { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.InventoryType Datastore { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.InventoryType Host { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.InventoryType ResourcePool { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.InventoryType VirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.InventoryType VirtualMachineTemplate { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.InventoryType VirtualNetwork { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.InventoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.InventoryType left, Azure.ResourceManager.ConnectedVMware.Models.InventoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.InventoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.InventoryType left, Azure.ResourceManager.ConnectedVMware.Models.InventoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAddressAllocationMethod : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAddressAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod Linklayer { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod Other { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod Random { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod Static { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod Unset { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod left, Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod left, Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineExtensionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.MachineExtension>
    {
        protected MachineExtensionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.MachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionInstanceViewStatus Status { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
    }
    public partial class MachineExtensionInstanceViewStatus
    {
        public MachineExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class MachineExtensionPropertiesInstanceView : Azure.ResourceManager.ConnectedVMware.Models.MachineExtensionInstanceView
    {
        public MachineExtensionPropertiesInstanceView() { }
    }
    public partial class MachineExtensionUpdate : Azure.ResourceManager.ConnectedVMware.Models.ResourcePatch
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
    public partial class MachineExtensionUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.MachineExtension>
    {
        protected MachineExtensionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.MachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.MachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkInterface
    {
        public NetworkInterface() { }
        public int? DeviceKey { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> IpAddresses { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.NicIPSettings IpSettings { get { throw null; } set { } }
        public string Label { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string NetworkId { get { throw null; } set { } }
        public string NetworkMoName { get { throw null; } }
        public string NetworkMoRefId { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.NICType? NicType { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption? PowerOnBoot { get { throw null; } set { } }
    }
    public partial class NetworkInterfaceUpdate
    {
        public NetworkInterfaceUpdate() { }
        public int? DeviceKey { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.NICType? NicType { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption? PowerOnBoot { get { throw null; } set { } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConnectedVMware.Models.NetworkInterface> NetworkInterfaces { get { throw null; } }
    }
    public partial class NetworkProfileUpdate
    {
        public NetworkProfileUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConnectedVMware.Models.NetworkInterfaceUpdate> NetworkInterfaces { get { throw null; } }
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
        public Azure.ResourceManager.ConnectedVMware.Models.IPAddressAllocationMethod? AllocationMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public System.Collections.Generic.IList<string> Gateway { get { throw null; } }
        public string IpAddress { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.NicIPAddressSettings> IpAddressInfo { get { throw null; } }
        public string PrimaryWinsServer { get { throw null; } }
        public string SecondaryWinsServer { get { throw null; } }
        public string SubnetMask { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NICType : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.NICType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NICType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.NICType E1000 { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.NICType E1000E { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.NICType Pcnet32 { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.NICType Vmxnet { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.NICType Vmxnet2 { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.NICType Vmxnet3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.NICType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.NICType left, Azure.ResourceManager.ConnectedVMware.Models.NICType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.NICType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.NICType left, Azure.ResourceManager.ConnectedVMware.Models.NICType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OsProfile
    {
        public OsProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string OsName { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.OsType? OsType { get { throw null; } set { } }
        public string ToolsRunningStatus { get { throw null; } }
        public string ToolsVersion { get { throw null; } }
        public string ToolsVersionStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OsType : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.OsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OsType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.OsType Linux { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.OsType Other { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.OsType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.OsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.OsType left, Azure.ResourceManager.ConnectedVMware.Models.OsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.OsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.OsType left, Azure.ResourceManager.ConnectedVMware.Models.OsType right) { throw null; }
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
    public readonly partial struct PowerOnBootOption : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerOnBootOption(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption Disabled { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption left, Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption left, Azure.ResourceManager.ConnectedVMware.Models.PowerOnBootOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningAction : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningAction(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction Install { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction Repair { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction Uninstall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction left, Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction left, Azure.ResourceManager.ConnectedVMware.Models.ProvisioningAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState left, Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState left, Azure.ResourceManager.ConnectedVMware.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourcePatch
    {
        public ResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ResourcePoolCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.ResourcePool>
    {
        protected ResourcePoolCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.ResourcePool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ResourcePoolUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.ResourcePool>
    {
        protected ResourcePoolUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.ResourcePool Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.ResourcePool>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public readonly partial struct ScsiControllerType : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScsiControllerType(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType Buslogic { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType Lsilogic { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType Lsilogicsas { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType Pvscsi { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType left, Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType left, Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusLevelTypes : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusLevelTypes(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes Error { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes Info { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes left, Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes left, Azure.ResourceManager.ConnectedVMware.Models.StatusLevelTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusTypes : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.StatusTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusTypes(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.StatusTypes Connected { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.StatusTypes Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.StatusTypes Error { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.StatusTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.StatusTypes left, Azure.ResourceManager.ConnectedVMware.Models.StatusTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.StatusTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.StatusTypes left, Azure.ResourceManager.ConnectedVMware.Models.StatusTypes right) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.ConnectedVMware.Models.VirtualDisk> Disks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiController> ScsiControllers { get { throw null; } }
    }
    public partial class StorageProfileUpdate
    {
        public StorageProfileUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConnectedVMware.Models.VirtualDiskUpdate> Disks { get { throw null; } }
    }
    public partial class VCenterCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VCenter>
    {
        protected VCenterCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VCenter Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VCenterUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VCenter>
    {
        protected VCenterUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VCenter Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VCenter>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ConnectedVMware.Models.DiskMode? DiskMode { get { throw null; } set { } }
        public string DiskObjectId { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.DiskType? DiskType { get { throw null; } set { } }
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
        public Azure.ResourceManager.ConnectedVMware.Models.DiskMode? DiskMode { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.DiskType? DiskType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? UnitNumber { get { throw null; } set { } }
    }
    public partial class VirtualMachineCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VirtualMachine>
    {
        protected VirtualMachineCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VirtualMachine Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VirtualMachineTemplateCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>
    {
        protected VirtualMachineTemplateCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VirtualMachineTemplateUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>
    {
        protected VirtualMachineTemplateUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachineTemplate>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineUpdate
    {
        public VirtualMachineUpdate() { }
        public Azure.ResourceManager.ConnectedVMware.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.VmwareIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.NetworkProfileUpdate NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ConnectedVMware.Models.StorageProfileUpdate StorageProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VirtualMachineUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VirtualMachine>
    {
        protected VirtualMachineUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VirtualMachine Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualMachine>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkCreateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>
    {
        protected VirtualNetworkCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VirtualNetwork Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VirtualNetworkUpdateOperation : Azure.Operation<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>
    {
        protected VirtualNetworkUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ConnectedVMware.VirtualNetwork Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ConnectedVMware.VirtualNetwork>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualScsiController
    {
        internal VirtualScsiController() { }
        public int? BusNumber { get { throw null; } }
        public int? ControllerKey { get { throw null; } }
        public int? ScsiCtlrUnitNumber { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing? Sharing { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.ScsiControllerType? Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualScsiSharing : System.IEquatable<Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualScsiSharing(string value) { throw null; }
        public static Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing NoSharing { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing PhysicalSharing { get { throw null; } }
        public static Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing VirtualSharing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing left, Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing left, Azure.ResourceManager.ConnectedVMware.Models.VirtualScsiSharing right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmwareIdentity
    {
        public VmwareIdentity(Azure.ResourceManager.ConnectedVMware.Models.IdentityType type) { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.ConnectedVMware.Models.IdentityType Type { get { throw null; } set { } }
    }
}
