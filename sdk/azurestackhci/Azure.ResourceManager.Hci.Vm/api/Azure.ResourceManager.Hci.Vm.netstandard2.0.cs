namespace Azure.ResourceManager.Hci.Vm
{
    public partial class AzureResourceManagerHciVmContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHciVmContext() { }
        public static Azure.ResourceManager.Hci.Vm.AzureResourceManagerHciVmContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class GalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.GalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.GalleryImageResource>, System.Collections.IEnumerable
    {
        protected GalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.GalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Hci.Vm.GalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Hci.Vm.GalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.GalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.GalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.GalleryImageResource> GetIfExists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> GetIfExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.GalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.GalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.GalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.GalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>
    {
        public GalleryImageData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType? OsType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.GalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.GalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryImageResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.GalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.GalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.GalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.GalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestAgentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>
    {
        public GuestAgentData() { }
        public Azure.ResourceManager.Hci.Vm.Models.GuestCredential Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction? ProvisioningAction { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.GuestAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.GuestAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestAgentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestAgentResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.GuestAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.GuestAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.GuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.GuestAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.GuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.GuestAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.GuestAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.GuestAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.GuestAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.GuestAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class HciVmExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource> GetGalleryImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> GetGalleryImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.GalleryImageResource GetGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.GalleryImageCollection GetGalleryImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.GalleryImageResource> GetGalleryImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.GalleryImageResource> GetGalleryImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.GuestAgentResource GetGuestAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> GetLogicalNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> GetLogicalNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.LogicalNetworkResource GetLogicalNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.LogicalNetworkCollection GetLogicalNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> GetLogicalNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> GetLogicalNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> GetMarketplaceGalleryImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> GetMarketplaceGalleryImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource GetMarketplaceGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageCollection GetMarketplaceGalleryImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> GetMarketplaceGalleryImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> GetMarketplaceGalleryImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> GetNetworkInterface(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> GetNetworkInterfaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource GetNetworkInterfaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.NetworkInterfaceCollection GetNetworkInterfaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> GetNetworkInterfaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> GetNetworkInterfacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource> GetStorageContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> GetStorageContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.StorageContainerResource GetStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.StorageContainerCollection GetStorageContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.StorageContainerResource> GetStorageContainers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.StorageContainerResource> GetStorageContainersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> GetVirtualHardDisk(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> GetVirtualHardDiskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource GetVirtualHardDiskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.VirtualHardDiskCollection GetVirtualHardDisks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> GetVirtualHardDisks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> GetVirtualHardDisksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource GetVirtualMachineInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource GetVirtualMachineInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HybridIdentityMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>
    {
        public HybridIdentityMetadataData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public string ResourceUid { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridIdentityMetadataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridIdentityMetadataResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicalNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>, System.Collections.IEnumerable
    {
        protected LogicalNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string logicalNetworkName, Azure.ResourceManager.Hci.Vm.LogicalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string logicalNetworkName, Azure.ResourceManager.Hci.Vm.LogicalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> Get(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> GetAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> GetIfExists(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> GetIfExistsAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicalNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>
    {
        public LogicalNetworkData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> DhcpOptionsDnsServers { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.Subnet> Subnets { get { throw null; } }
        public string VmSwitchName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.LogicalNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.LogicalNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicalNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicalNetworkResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.LogicalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string logicalNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.LogicalNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.LogicalNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.LogicalNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MarketplaceGalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>, System.Collections.IEnumerable
    {
        protected MarketplaceGalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string marketplaceGalleryImageName, Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string marketplaceGalleryImageName, Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> Get(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> GetAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> GetIfExists(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> GetIfExistsAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MarketplaceGalleryImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>
    {
        public MarketplaceGalleryImageData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType? OsType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceGalleryImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MarketplaceGalleryImageResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string marketplaceGalleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkInterfaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>, System.Collections.IEnumerable
    {
        protected NetworkInterfaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.Hci.Vm.NetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.Hci.Vm.NetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> Get(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> GetAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> GetIfExists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> GetIfExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkInterfaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>
    {
        public NetworkInterfaceData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration> IpConfigurations { get { throw null; } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.NetworkInterfaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.NetworkInterfaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkInterfaceResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.NetworkInterfaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkInterfaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.NetworkInterfaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.NetworkInterfaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkInterfaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.StorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.StorageContainerResource>, System.Collections.IEnumerable
    {
        protected StorageContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.StorageContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Hci.Vm.StorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Hci.Vm.StorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource> Get(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.StorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.StorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> GetAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.StorageContainerResource> GetIfExists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> GetIfExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.StorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.StorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.StorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.StorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageContainerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>
    {
        public StorageContainerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.StorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.StorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageContainerResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.StorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.StorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.StorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.StorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.StorageContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualHardDiskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>, System.Collections.IEnumerable
    {
        protected VirtualHardDiskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualHardDiskName, Azure.ResourceManager.Hci.Vm.VirtualHardDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualHardDiskName, Azure.ResourceManager.Hci.Vm.VirtualHardDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> Get(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> GetAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> GetIfExists(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> GetIfExistsAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualHardDiskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>
    {
        public VirtualHardDiskData(Azure.Core.AzureLocation location) { }
        public int? BlockSizeBytes { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat? DiskFileFormat { get { throw null; } set { } }
        public long? DiskSizeGB { get { throw null; } set { } }
        public bool? Dynamic { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public int? LogicalSectorBytes { get { throw null; } set { } }
        public int? PhysicalSectorBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.VirtualHardDiskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.VirtualHardDiskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualHardDiskResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.VirtualHardDiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualHardDiskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.VirtualHardDiskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.VirtualHardDiskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualHardDiskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>
    {
        public VirtualMachineInstanceData() { }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus GuestAgentInstallStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration HttpProxyConfig { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView InstanceViewVmAgent { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public string ResourceUid { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile StorageProfile { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineInstanceResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.GuestAgentResource GetGuestAgent() { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataResource GetHybridIdentityMetadata() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource> Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource>> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource> Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource>> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Vm.Mocking
{
    public partial class MockableHciVmArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHciVmArmClient() { }
        public virtual Azure.ResourceManager.Hci.Vm.GalleryImageResource GetGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.GuestAgentResource GetGuestAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.LogicalNetworkResource GetLogicalNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource GetMarketplaceGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource GetNetworkInterfaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.StorageContainerResource GetStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource GetVirtualHardDiskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource GetVirtualMachineInstance(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceResource GetVirtualMachineInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHciVmResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciVmResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource> GetGalleryImage(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.GalleryImageResource>> GetGalleryImageAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.GalleryImageCollection GetGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> GetLogicalNetwork(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource>> GetLogicalNetworkAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.LogicalNetworkCollection GetLogicalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> GetMarketplaceGalleryImage(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource>> GetMarketplaceGalleryImageAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageCollection GetMarketplaceGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> GetNetworkInterface(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource>> GetNetworkInterfaceAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.NetworkInterfaceCollection GetNetworkInterfaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource> GetStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.StorageContainerResource>> GetStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.StorageContainerCollection GetStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> GetVirtualHardDisk(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource>> GetVirtualHardDiskAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.VirtualHardDiskCollection GetVirtualHardDisks() { throw null; }
    }
    public partial class MockableHciVmSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciVmSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.GalleryImageResource> GetGalleryImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.GalleryImageResource> GetGalleryImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> GetLogicalNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.LogicalNetworkResource> GetLogicalNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> GetMarketplaceGalleryImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource> GetMarketplaceGalleryImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> GetNetworkInterfaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource> GetNetworkInterfacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.StorageContainerResource> GetStorageContainers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.StorageContainerResource> GetStorageContainersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> GetVirtualHardDisks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.VirtualHardDiskResource> GetVirtualHardDisksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Vm.Models
{
    public static partial class ArmHciVmModelFactory
    {
        public static Azure.ResourceManager.Hci.Vm.GalleryImageData GalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null, Azure.Core.ResourceIdentifier containerId = null, string imagePath = null, Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType? osType = default(Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType?), Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion version = null, Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus GalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus GalleryImageStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.Status? status = default(Azure.ResourceManager.Hci.Vm.Models.Status?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.GuestAgentData GuestAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.GuestCredential credentials = null, Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction? provisioningAction = default(Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction?), string status = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus GuestAgentInstallStatus(string vmUuid = null, Azure.ResourceManager.Hci.Vm.Models.StatusType? status = default(Azure.ResourceManager.Hci.Vm.Models.StatusType?), System.DateTimeOffset? lastStatusChange = default(System.DateTimeOffset?), string agentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData HybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string resourceUid = null, string publicKey = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus InstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Vm.Models.StatusLevelType? level = default(Azure.ResourceManager.Hci.Vm.Models.StatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties IPConfigurationProperties(string gateway = null, string prefixLength = null, string privateIPAddress = null, Azure.Core.ResourceIdentifier subnetId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo IPPoolInfo(string used = null, string available = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.LogicalNetworkData LogicalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> dhcpOptionsDnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.Subnet> subnets = null, Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum?), string vmSwitchName = null, Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus LogicalNetworkStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus LogicalNetworkStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.Status? status = default(Azure.ResourceManager.Hci.Vm.Models.Status?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData MarketplaceGalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null, Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType? osType = default(Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType?), Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion version = null, Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus MarketplaceGalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus MarketplaceGalleryImageStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.Status? status = default(Azure.ResourceManager.Hci.Vm.Models.Status?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.NetworkInterfaceData NetworkInterfaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration> ipConfigurations = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus NetworkInterfaceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus NetworkInterfaceStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.Status? status = default(Azure.ResourceManager.Hci.Vm.Models.Status?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.RouteTable RouteTable(string etag = null, string name = null, string routeTableType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.Route> routes = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.StorageContainerData StorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null, string path = null, Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus StorageContainerStatus(string errorCode = null, string errorMessage = null, long? availableSizeMB = default(long?), long? containerSizeMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus StorageContainerStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.Status? status = default(Azure.ResourceManager.Hci.Vm.Models.Status?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.VirtualHardDiskData VirtualHardDiskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null, int? blockSizeBytes = default(int?), long? diskSizeGB = default(long?), bool? dynamic = default(bool?), int? logicalSectorBytes = default(int?), int? physicalSectorBytes = default(int?), Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat? diskFileFormat = default(Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat?), Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum?), Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus VirtualHardDiskStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus VirtualHardDiskStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.Status? status = default(Azure.ResourceManager.Hci.Vm.Models.Status?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView VirtualMachineConfigAgentInstanceView(string vmConfigAgentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData VirtualMachineInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile hardwareProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> networkInterfaces = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile osProfile = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile securityProfile = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile storageProfile = null, Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration httpProxyConfig = null, Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView instanceViewVmAgent = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus status = null, Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus guestAgentInstallStatus = null, string vmId = null, string resourceUid = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus VirtualMachineInstanceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum? powerState = default(Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum?), Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus VirtualMachineInstanceStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.Status? status = default(Azure.ResourceManager.Hci.Vm.Models.Status?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudInitDataSource : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudInitDataSource(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource Azure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource NoCloud { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource left, Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource left, Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskFileFormat : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskFileFormat(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat Vhd { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat Vhdx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat left, Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat left, Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation>
    {
        public ExtendedLocation() { }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType CustomLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType left, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType left, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryImageIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier>
    {
        public GalleryImageIdentifier(string publisher, string offer, string sku) { }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImagePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch>
    {
        public GalleryImagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus>
    {
        internal GalleryImageStatus() { }
        public long? DownloadSizeInMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus>
    {
        internal GalleryImageStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.Status? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GalleryImageVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>
    {
        public GalleryImageVersion() { }
        public string Name { get { throw null; } set { } }
        public long? OsDiskImageSizeInMB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestAgentInstallStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>
    {
        public GuestAgentInstallStatus() { }
        public string AgentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusChange { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.StatusType? Status { get { throw null; } }
        public string VmUuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestCredential>
    {
        public GuestCredential() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HardwareProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate>
    {
        public HardwareProfileUpdate() { }
        public long? MemoryMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum? VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HttpProxyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration>
    {
        public HttpProxyConfiguration() { }
        public string HttpProxy { get { throw null; } set { } }
        public string HttpsProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NoProxy { get { throw null; } }
        public string TrustedCa { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGeneration : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration left, Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration left, Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus>
    {
        internal InstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.StatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IpAllocationMethodEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IpAllocationMethodEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum left, Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum left, Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration>
    {
        public IPConfiguration() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.IPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.IPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties>
    {
        public IPConfigurationProperties() { }
        public string Gateway { get { throw null; } }
        public string PrefixLength { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPPool>
    {
        public IPPool() { }
        public string End { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo Info { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum? IpPoolType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.IPPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.IPPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPPoolInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo>
    {
        public IPPoolInfo() { }
        public string Available { get { throw null; } }
        public string Used { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum IPPoolTypeEnum
    {
        Vm = 0,
        Vippool = 1,
    }
    public partial class LogicalNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch>
    {
        public LogicalNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicalNetworkStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus>
    {
        internal LogicalNetworkStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogicalNetworkStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>
    {
        internal LogicalNetworkStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.Status? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceGalleryImagePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch>
    {
        public MarketplaceGalleryImagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceGalleryImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus>
    {
        internal MarketplaceGalleryImageStatus() { }
        public long? DownloadSizeInMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceGalleryImageStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus>
    {
        internal MarketplaceGalleryImageStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.Status? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>
    {
        public NetworkInterfacePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus>
    {
        internal NetworkInterfaceStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>
    {
        internal NetworkInterfaceStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.Status? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum OperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class OsProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate>
    {
        public OsProfileUpdate() { }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OsProfileUpdateLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration>
    {
        public OsProfileUpdateLinuxConfiguration() { }
        public bool? ProvisionVMAgent { get { throw null; } set { } }
        public bool? ProvisionVMConfigAgent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OsProfileUpdateWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration>
    {
        public OsProfileUpdateWindowsConfiguration() { }
        public bool? ProvisionVMAgent { get { throw null; } set { } }
        public bool? ProvisionVMConfigAgent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdateWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PowerStateEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerStateEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum Deallocated { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum Deallocating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum Running { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum Starting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum Stopped { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum Stopping { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum left, Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum left, Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningAction : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningAction(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction Install { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction Repair { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction Uninstall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction left, Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction left, Azure.ResourceManager.Hci.Vm.Models.ProvisioningAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStateEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStateEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum left, Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum left, Azure.ResourceManager.Hci.Vm.Models.ProvisioningStateEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Route : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.Route>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.Route>
    {
        public Route() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NextHopIpAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.Route System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.Route>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.Route>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.Route System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.Route>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.Route>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.Route>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouteTable : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>
    {
        public RouteTable() { }
        public string Etag { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.Route> Routes { get { throw null; } }
        public string RouteTableType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.RouteTable System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.RouteTable System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.SecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityType ConfidentialVM { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.SecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.SecurityType left, Azure.ResourceManager.Hci.Vm.Models.SecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.SecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.SecurityType left, Azure.ResourceManager.Hci.Vm.Models.SecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.SshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SshPublicKey>
    {
        public SshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.SshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.SshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.SshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.SshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.Status Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.Status InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.Status Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.Status left, Azure.ResourceManager.Hci.Vm.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.Status left, Azure.ResourceManager.Hci.Vm.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusLevelType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.StatusLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusLevelType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.StatusLevelType Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.StatusLevelType Info { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.StatusLevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.StatusLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.StatusLevelType left, Azure.ResourceManager.Hci.Vm.Models.StatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.StatusLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.StatusLevelType left, Azure.ResourceManager.Hci.Vm.Models.StatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.StatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.StatusType Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.StatusType InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.StatusType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.StatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.StatusType left, Azure.ResourceManager.Hci.Vm.Models.StatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.StatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.StatusType left, Azure.ResourceManager.Hci.Vm.Models.StatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageContainerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch>
    {
        public StorageContainerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus>
    {
        internal StorageContainerStatus() { }
        public long? AvailableSizeMB { get { throw null; } }
        public long? ContainerSizeMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>
    {
        internal StorageContainerStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.Status? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Subnet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.Subnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.Subnet>
    {
        public Subnet() { }
        public string AddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.IpAllocationMethodEnum? IpAllocationMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem> IpConfigurationReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.IPPool> IpPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.RouteTable RouteTable { get { throw null; } set { } }
        public int? Vlan { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.Subnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.Subnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.Subnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.Subnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.Subnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.Subnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.Subnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubnetPropertiesFormatIpConfigurationReferencesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem>
    {
        public SubnetPropertiesFormatIpConfigurationReferencesItem() { }
        public string ID { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SubnetPropertiesFormatIpConfigurationReferencesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>
    {
        public VirtualHardDiskPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus>
    {
        internal VirtualHardDiskStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>
    {
        internal VirtualHardDiskStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.Status? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineConfigAgentInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView>
    {
        internal VirtualMachineConfigAgentInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public string VmConfigAgentVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch>
    {
        public VirtualMachineInstancePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile>
    {
        public VirtualMachineInstancePropertiesHardwareProfile() { }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig DynamicMemoryConfig { get { throw null; } set { } }
        public long? MemoryMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum? VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>
    {
        public VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig() { }
        public long? MaximumMemoryMB { get { throw null; } set { } }
        public long? MinimumMemoryMB { get { throw null; } set { } }
        public int? TargetMemoryBuffer { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesOsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile>
    {
        public VirtualMachineInstancePropertiesOsProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesOsProfileLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration>
    {
        public VirtualMachineInstancePropertiesOsProfileLinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? ProvisionVMAgent { get { throw null; } set { } }
        public bool? ProvisionVMConfigAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesOsProfileWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration>
    {
        public VirtualMachineInstancePropertiesOsProfileWindowsConfiguration() { }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? ProvisionVMAgent { get { throw null; } set { } }
        public bool? ProvisionVMConfigAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOsProfileWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile>
    {
        public VirtualMachineInstancePropertiesSecurityProfile() { }
        public bool? EnableTPM { get { throw null; } set { } }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.SecurityType? SecurityType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>
    {
        public VirtualMachineInstancePropertiesStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> DataDisks { get { throw null; } }
        public Azure.Core.ResourceIdentifier ImageReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk OsDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmConfigStoragePathId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesStorageProfileOsDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk>
    {
        public VirtualMachineInstancePropertiesStorageProfileOsDisk() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType? OsType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOsDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus>
    {
        internal VirtualMachineInstanceStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.PowerStateEnum? PowerState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus>
    {
        internal VirtualMachineInstanceStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.Status? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>
    {
        public VirtualMachineInstanceUpdateProperties() { }
        public Azure.ResourceManager.Hci.Vm.Models.HardwareProfileUpdate HardwareProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.OsProfileUpdate OsProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> StorageDataDisks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmSizeEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmSizeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum Custom { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum Default { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardK8S2V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardK8S3V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardK8S4V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardK8S5V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardK8SV1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardNK12 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardNK6 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardNV12 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardNV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum left, Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum left, Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
}
