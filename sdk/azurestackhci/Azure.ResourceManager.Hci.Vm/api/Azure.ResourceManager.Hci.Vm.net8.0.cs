namespace Azure.ResourceManager.Hci.Vm
{
    public partial class AzureResourceManagerHciVmContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHciVmContext() { }
        public static Azure.ResourceManager.Hci.Vm.AzureResourceManagerHciVmContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class HciVmAttestationStatusData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>
    {
        internal HciVmAttestationStatusData() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmAttestationStatusResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmAttestationStatusResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class HciVmExtensions
    {
        public static Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusResource GetHciVmAttestationStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> GetHciVmGalleryImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource GetHciVmGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGalleryImageCollection GetHciVmGalleryImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource GetHciVmGuestAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataResource GetHciVmHybridIdentityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmInstanceResource GetHciVmInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmInstanceResource GetHciVmInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetHciVmLogicalNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> GetHciVmLogicalNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource GetHciVmLogicalNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkCollection GetHciVmLogicalNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetHciVmLogicalNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetHciVmLogicalNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetHciVmMarketplaceGalleryImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> GetHciVmMarketplaceGalleryImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource GetHciVmMarketplaceGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageCollection GetHciVmMarketplaceGalleryImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetHciVmMarketplaceGalleryImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetHciVmMarketplaceGalleryImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetHciVmNetworkInterface(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> GetHciVmNetworkInterfaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource GetHciVmNetworkInterfaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceCollection GetHciVmNetworkInterfaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetHciVmNetworkInterfaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetHciVmNetworkInterfacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetHciVmNetworkSecurityGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> GetHciVmNetworkSecurityGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource GetHciVmNetworkSecurityGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupCollection GetHciVmNetworkSecurityGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetHciVmNetworkSecurityGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetHciVmNetworkSecurityGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource GetHciVmSecurityRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetHciVmStorageContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> GetHciVmStorageContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource GetHciVmStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmStorageContainerCollection GetHciVmStorageContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetHciVmStorageContainers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetHciVmStorageContainersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetHciVmVirtualHardDisk(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> GetHciVmVirtualHardDiskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource GetHciVmVirtualHardDiskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskCollection GetHciVmVirtualHardDisks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetHciVmVirtualHardDisks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetHciVmVirtualHardDisksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmGalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>, System.Collections.IEnumerable
    {
        protected HciVmGalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetIfExists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> GetIfExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmGalleryImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>
    {
        public HciVmGalleryImageData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGalleryImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmGalleryImageResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmGuestAgentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>
    {
        public HciVmGuestAgentData() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGuestAgentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmGuestAgentResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmHybridIdentityMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>
    {
        internal HciVmHybridIdentityMetadataData() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmHybridIdentityMetadataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmHybridIdentityMetadataResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>
    {
        public HciVmInstanceData() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmInstanceResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.HciVmInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.HciVmInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusResource GetHciVmAttestationStatus() { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource GetHciVmGuestAgent() { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataResource GetHciVmHybridIdentityMetadata() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Pause(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PauseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Save(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SaveAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmLogicalNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>, System.Collections.IEnumerable
    {
        protected HciVmLogicalNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string logicalNetworkName, Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string logicalNetworkName, Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> Get(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> GetAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetIfExists(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> GetIfExistsAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmLogicalNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>
    {
        public HciVmLogicalNetworkData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLogicalNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmLogicalNetworkResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string logicalNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmMarketplaceGalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>, System.Collections.IEnumerable
    {
        protected HciVmMarketplaceGalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string marketplaceGalleryImageName, Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string marketplaceGalleryImageName, Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> Get(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> GetAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetIfExists(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> GetIfExistsAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmMarketplaceGalleryImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>
    {
        public HciVmMarketplaceGalleryImageData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmMarketplaceGalleryImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmMarketplaceGalleryImageResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string marketplaceGalleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmNetworkInterfaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>, System.Collections.IEnumerable
    {
        protected HciVmNetworkInterfaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> Get(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> GetAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetIfExists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> GetIfExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmNetworkInterfaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>
    {
        public HciVmNetworkInterfaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkInterfaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmNetworkInterfaceResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkInterfaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmNetworkSecurityGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>, System.Collections.IEnumerable
    {
        protected HciVmNetworkSecurityGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkSecurityGroupName, Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkSecurityGroupName, Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> Get(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> GetAsync(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetIfExists(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> GetIfExistsAsync(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmNetworkSecurityGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>
    {
        public HciVmNetworkSecurityGroupData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkSecurityGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmNetworkSecurityGroupResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkSecurityGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> GetHciVmSecurityRule(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>> GetHciVmSecurityRuleAsync(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleCollection GetHciVmSecurityRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmSecurityRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>, System.Collections.IEnumerable
    {
        protected HciVmSecurityRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securityRuleName, Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securityRuleName, Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> Get(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>> GetAsync(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> GetIfExists(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>> GetIfExistsAsync(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmSecurityRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>
    {
        public HciVmSecurityRuleData() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmSecurityRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmSecurityRuleResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkSecurityGroupName, string securityRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmStorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>, System.Collections.IEnumerable
    {
        protected HciVmStorageContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> Get(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> GetAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetIfExists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> GetIfExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmStorageContainerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>
    {
        public HciVmStorageContainerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmStorageContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmStorageContainerResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmVirtualHardDiskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>, System.Collections.IEnumerable
    {
        protected HciVmVirtualHardDiskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualHardDiskName, Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualHardDiskName, Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> Get(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> GetAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetIfExists(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> GetIfExistsAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmVirtualHardDiskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>
    {
        public HciVmVirtualHardDiskData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmVirtualHardDiskResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualHardDiskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult> Upload(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult>> UploadAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Vm.Mocking
{
    public partial class MockableHciVmArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHciVmArmClient() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusResource GetHciVmAttestationStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource GetHciVmGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource GetHciVmGuestAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataResource GetHciVmHybridIdentityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmInstanceResource GetHciVmInstance(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmInstanceResource GetHciVmInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource GetHciVmLogicalNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource GetHciVmMarketplaceGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource GetHciVmNetworkInterfaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource GetHciVmNetworkSecurityGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource GetHciVmSecurityRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource GetHciVmStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource GetHciVmVirtualHardDiskResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHciVmResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciVmResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImage(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> GetHciVmGalleryImageAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGalleryImageCollection GetHciVmGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetHciVmLogicalNetwork(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> GetHciVmLogicalNetworkAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkCollection GetHciVmLogicalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetHciVmMarketplaceGalleryImage(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> GetHciVmMarketplaceGalleryImageAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageCollection GetHciVmMarketplaceGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetHciVmNetworkInterface(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> GetHciVmNetworkInterfaceAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceCollection GetHciVmNetworkInterfaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetHciVmNetworkSecurityGroup(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> GetHciVmNetworkSecurityGroupAsync(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupCollection GetHciVmNetworkSecurityGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetHciVmStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> GetHciVmStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmStorageContainerCollection GetHciVmStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetHciVmVirtualHardDisk(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> GetHciVmVirtualHardDiskAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskCollection GetHciVmVirtualHardDisks() { throw null; }
    }
    public partial class MockableHciVmSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciVmSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetHciVmLogicalNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetHciVmLogicalNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetHciVmMarketplaceGalleryImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetHciVmMarketplaceGalleryImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetHciVmNetworkInterfaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetHciVmNetworkInterfacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetHciVmNetworkSecurityGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetHciVmNetworkSecurityGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetHciVmStorageContainers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetHciVmStorageContainersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetHciVmVirtualHardDisks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetHciVmVirtualHardDisksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Vm.Models
{
    public static partial class ArmHciVmModelFactory
    {
        public static Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus GuestAgentInstallStatus(string vmUuid = null, Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType? status = default(Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType?), System.DateTimeOffset? lastStatusChangedOn = default(System.DateTimeOffset?), string agentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData HciVmAttestationStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties HciVmAttestationStatusProperties(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus? attestSecureBootEnabled = default(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus?), Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus? attestationCertValidated = default(Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus?), Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus? bootIntegrityValidated = default(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus?), string linuxKernelVersion = null, Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus? healthStatus = default(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus?), string timestamp = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType? attestHardwarePlatform = default(Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType?), Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType? attestDiskSecurityEncryptionType = default(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView HciVmConfigAgentInstanceView(string vmConfigAgentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData HciVmGalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties HciVmGalleryImageProperties(Azure.Core.ResourceIdentifier containerId = null, string imagePath = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOSType osType = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType), Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials vmImageRepositoryCredentials = null, Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion version = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus status = null, Azure.Core.ResourceIdentifier sourceVirtualMachineId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus HciVmGalleryImageProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus HciVmGalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData HciVmGuestAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties HciVmGuestAgentProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential credentials = null, Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction? provisioningAction = default(Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction?), string status = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData HciVmHybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties HciVmHybridIdentityMetadataProperties(string resourceUid = null, string publicKey = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmInstanceData HciVmInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties HciVmInstanceProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile hardwareProfile = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile placementProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> networkInterfaces = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile osProfile = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile securityProfile = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile storageProfile = null, Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration httpProxyConfig = null, bool? isCreatingFromLocal = default(bool?), Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView instanceViewVmAgent = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus status = null, Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus guestAgentInstallStatus = null, string vmId = null, string resourceUid = null, string hyperVVmId = null, string hostNodeName = null, string hostNodeIPAddress = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus HciVmInstanceProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus HciVmInstanceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState? powerState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState?), Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus HciVmInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType? level = default(Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties HciVmIPConfigurationProperties(string gateway = null, string prefixLength = null, string privateIPAddress = null, Azure.Core.ResourceIdentifier subnetId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo HciVmIPPoolInfo(string used = null, string available = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData HciVmLogicalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties HciVmLogicalNetworkProperties(System.Collections.Generic.IEnumerable<string> dhcpOptionsDnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet> subnets = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), string vmSwitchName = null, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus status = null, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType? networkType = default(Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus HciVmLogicalNetworkProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus HciVmLogicalNetworkStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData HciVmMarketplaceGalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties HciVmMarketplaceGalleryImageProperties(Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOSType osType = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType), Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion version = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus HciVmMarketplaceGalleryImageProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus HciVmMarketplaceGalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable HciVmNetworkingRouteTable(string etag = null, string name = null, string type = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute> routes = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData HciVmNetworkInterfaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties HciVmNetworkInterfaceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration> ipConfigurations = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, bool? createFromLocal = default(bool?), Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus status = null, Azure.Core.ResourceIdentifier networkSecurityGroupId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus HciVmNetworkInterfaceProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus HciVmNetworkInterfaceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData HciVmNetworkSecurityGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties HciVmNetworkSecurityGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> networkInterfaces = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> subnets = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus HciVmNetworkSecurityGroupProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus HciVmNetworkSecurityGroupStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData HciVmSecurityRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties HciVmSecurityRuleProperties(string description = null, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol protocol = default(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol), System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes = null, System.Collections.Generic.IEnumerable<string> destinationAddressPrefixes = null, System.Collections.Generic.IEnumerable<string> sourcePortRanges = null, System.Collections.Generic.IEnumerable<string> destinationPortRanges = null, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess access = default(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess), int priority = 0, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection direction = default(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection), Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData HciVmStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties HciVmStorageContainerProperties(string path = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus HciVmStorageContainerProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus HciVmStorageContainerStatus(string errorCode = null, string errorMessage = null, long? availableSizeInMB = default(long?), long? containerSizeInMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData HciVmVirtualHardDiskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus HciVmVirtualHardDiskDownloadStatus(long? downloadedSizeInMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties HciVmVirtualHardDiskProperties(int? blockSizeInBytes = default(int?), long? diskSizeInGB = default(long?), bool? dynamic = default(bool?), int? logicalSectorInBytes = default(int?), int? physicalSectorInBytes = default(int?), System.Uri downloadUri = null, Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat? diskFileFormat = default(Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat?), bool? isCreatingFromLocal = default(bool?), Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus status = null, long? maxShares = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus HciVmVirtualHardDiskProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus HciVmVirtualHardDiskStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus provisioningStatus = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus downloadStatus = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus uploadStatus = null, System.Collections.Generic.IEnumerable<string> managedBy = null, string uniqueId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult HciVmVirtualHardDiskUploadResult(Azure.Core.ResourceIdentifier virtualHardDiskId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus uploadStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus HciVmVirtualHardDiskUploadStatus(long? uploadedSizeInMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?), long? progressPercentage = default(long?), string errorCode = null, string errorMessage = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestBootIntegrityStatus : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestBootIntegrityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestCertValidationStatus : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestCertValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestDiskSecurityEncryptionType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestDiskSecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType NonPersistedTpm { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType left, Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType left, Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestHardwarePlatformType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestHardwarePlatformType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType Sevsnp { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType left, Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType left, Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestHealthStatus : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestSecureBootStatus : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestSecureBootStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct GpuAssignmentType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GpuAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType GpuDda { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType GpuP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType left, Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType left, Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuestAgentInstallStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>
    {
        public GuestAgentInstallStatus() { }
        public string AgentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusChangedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType? Status { get { throw null; } }
        public string VmUuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestAgentProvisioningAction : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestAgentProvisioningAction(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction Install { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction Repair { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction Uninstall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction left, Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction left, Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmAttestationStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>
    {
        internal HciVmAttestationStatusProperties() { }
        public Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus? AttestationCertValidated { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType? AttestDiskSecurityEncryptionType { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType? AttestHardwarePlatform { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus? AttestSecureBootEnabled { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus? BootIntegrityValidated { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus? HealthStatus { get { throw null; } }
        public string LinuxKernelVersion { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public string Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmConfigAgentInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView>
    {
        internal HciVmConfigAgentInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus> Statuses { get { throw null; } }
        public string VmConfigAgentVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmDiskFileFormat : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmDiskFileFormat(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat Vhd { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat Vhdx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat left, Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat left, Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation>
    {
        public HciVmExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmExtendedLocationType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType CustomLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType left, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType left, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmGalleryImageIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier>
    {
        public HciVmGalleryImageIdentifier(string publisher, string offer, string sku) { }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGalleryImagePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch>
    {
        public HciVmGalleryImagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGalleryImageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties>
    {
        public HciVmGalleryImageProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType osType) { }
        public Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier Identifier { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSType OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVirtualMachineId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion Version { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials VmImageRepositoryCredentials { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGalleryImageProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus>
    {
        internal HciVmGalleryImageProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGalleryImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus>
    {
        internal HciVmGalleryImageStatus() { }
        public long? DownloadSizeInMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGalleryImageVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion>
    {
        public HciVmGalleryImageVersion() { }
        public string Name { get { throw null; } set { } }
        public long? OSDiskImageSizeInMB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGuestAgentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties>
    {
        public HciVmGuestAgentProperties() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction? ProvisioningAction { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGuestCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential>
    {
        public HciVmGuestCredential() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmHttpProxyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration>
    {
        public HciVmHttpProxyConfiguration() { }
        public string HttpProxy { get { throw null; } set { } }
        public string HttpsProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NoProxy { get { throw null; } }
        public string TrustedCa { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmHybridIdentityMetadataProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties>
    {
        internal HciVmHybridIdentityMetadataProperties() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } }
        public string ResourceUid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmHyperVGeneration : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmHyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration left, Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration left, Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmImageRepositoryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials>
    {
        public HciVmImageRepositoryCredentials(string username, string password) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmImageRepositoryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>
    {
        public HciVmInstanceHardwareProfile() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration DynamicMemoryConfig { get { throw null; } set { } }
        public long? MemoryInMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration> VirtualMachineGPUs { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSize? VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceHardwareProfileDynamicMemoryConfigiuration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration>
    {
        public HciVmInstanceHardwareProfileDynamicMemoryConfigiuration() { }
        public long? MaximumMemoryInMB { get { throw null; } set { } }
        public long? MinimumMemoryInMB { get { throw null; } set { } }
        public int? TargetMemoryBuffer { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfigiuration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceHardwareProfileGpuConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration>
    {
        public HciVmInstanceHardwareProfileGpuConfiguration(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType assignmentType) { }
        public Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType AssignmentType { get { throw null; } set { } }
        public string GpuName { get { throw null; } set { } }
        public long? PartitionSizeInMB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceHardwareProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate>
    {
        public HciVmInstanceHardwareProfileUpdate() { }
        public long? MemoryInMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration> VirtualMachineGPUs { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSize? VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile>
    {
        public HciVmInstanceOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceOSProfileLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration>
    {
        public HciVmInstanceOSProfileLinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey> SshPublicKeys { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceOSProfileWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration>
    {
        public HciVmInstanceOSProfileWindowsConfiguration() { }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey> SshPublicKeys { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch>
    {
        public HciVmInstancePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstancePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties>
    {
        public HciVmInstancePatchProperties() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate HardwareProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile OSProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> StorageDataDisks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstancePlacementProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile>
    {
        public HciVmInstancePlacementProfile() { }
        public bool? StrictPlacementPolicy { get { throw null; } set { } }
        public string Zone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties>
    {
        public HciVmInstanceProperties() { }
        public Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus GuestAgentInstallStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile HardwareProfile { get { throw null; } set { } }
        public string HostNodeIPAddress { get { throw null; } }
        public string HostNodeName { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration HttpProxyConfig { get { throw null; } set { } }
        public string HyperVVmId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView InstanceViewVmAgent { get { throw null; } }
        public bool? IsCreatingFromLocal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile PlacementProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceUid { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile StorageProfile { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus>
    {
        internal HciVmInstanceProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile>
    {
        public HciVmInstanceSecurityProfile() { }
        public bool? IsTpmEnabled { get { throw null; } set { } }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType? SecurityType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>
    {
        internal HciVmInstanceStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile>
    {
        public HciVmInstanceStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> DataDisks { get { throw null; } }
        public Azure.Core.ResourceIdentifier ImageReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk OSDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmConfigStoragePathId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceStorageProfileOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk>
    {
        public HciVmInstanceStorageProfileOSDisk() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus>
    {
        internal HciVmInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmIPAllocationMethod : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod left, Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod left, Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration>
    {
        public HciVmIPConfiguration() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmIPConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties>
    {
        public HciVmIPConfigurationProperties() { }
        public string Gateway { get { throw null; } }
        public string PrefixLength { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmIPPoolInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo>
    {
        public HciVmIPPoolInfo() { }
        public string Available { get { throw null; } }
        public string Used { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmIPPoolType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmIPPoolType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType VipPool { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType Vm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType left, Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType left, Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmLogicalNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch>
    {
        public HciVmLogicalNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLogicalNetworkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties>
    {
        public HciVmLogicalNetworkProperties() { }
        public System.Collections.Generic.IList<string> DhcpOptionsDnsServers { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType? NetworkType { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet> Subnets { get { throw null; } }
        public string VmSwitchName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLogicalNetworkProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus>
    {
        internal HciVmLogicalNetworkProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLogicalNetworkStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus>
    {
        internal HciVmLogicalNetworkStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmLogicalNetworkType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmLogicalNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType Infrastructure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType Workload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType left, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType left, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmMarketplaceGalleryImagePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch>
    {
        public HciVmMarketplaceGalleryImagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmMarketplaceGalleryImageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties>
    {
        public HciVmMarketplaceGalleryImageProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType osType) { }
        public Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSType OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmMarketplaceGalleryImageProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus>
    {
        internal HciVmMarketplaceGalleryImageProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmMarketplaceGalleryImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>
    {
        internal HciVmMarketplaceGalleryImageStatus() { }
        public long? DownloadSizeInMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkingIPPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool>
    {
        public HciVmNetworkingIPPool() { }
        public string End { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo Info { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType? IPPoolType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkingRoute : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute>
    {
        public HciVmNetworkingRoute() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NextHopIPAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkingRouteTable : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable>
    {
        public HciVmNetworkingRouteTable() { }
        public string ETag { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute> Routes { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkingSubnet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>
    {
        public HciVmNetworkingSubnet() { }
        public string AddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod? IPAllocationMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> IPConfigurationReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool> IPPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable RouteTable { get { throw null; } set { } }
        public int? Vlan { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkInterfacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch>
    {
        public HciVmNetworkInterfacePatch() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkInterfacePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties>
    {
        public HciVmNetworkInterfacePatchProperties() { }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkInterfaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties>
    {
        public HciVmNetworkInterfaceProperties() { }
        public bool? CreateFromLocal { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration> IPConfigurations { get { throw null; } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkInterfaceProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus>
    {
        internal HciVmNetworkInterfaceProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkInterfaceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus>
    {
        internal HciVmNetworkInterfaceStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkSecurityGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>
    {
        public HciVmNetworkSecurityGroupPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkSecurityGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties>
    {
        public HciVmNetworkSecurityGroupProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> Subnets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkSecurityGroupProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus>
    {
        internal HciVmNetworkSecurityGroupProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkSecurityGroupStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus>
    {
        internal HciVmNetworkSecurityGroupStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmOperationStatus : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus left, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus left, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile>
    {
        public HciVmOSProfile() { }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmOSProfileLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration>
    {
        public HciVmOSProfileLinuxConfiguration() { }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmOSProfileSshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey>
    {
        public HciVmOSProfileSshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmOSProfileWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration>
    {
        public HciVmOSProfileWindowsConfiguration() { }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmOSType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmOSType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType left, Azure.ResourceManager.Hci.Vm.Models.HciVmOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType left, Azure.ResourceManager.Hci.Vm.Models.HciVmOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmPowerState : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmPowerState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState Deallocated { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState Deallocating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState Paused { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState Running { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState Saved { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState Starting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState left, Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState left, Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmProvisioningState : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState left, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState left, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmSecurityEncryptionType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmSecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType NonPersistedTpm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmSecurityRuleAccess : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmSecurityRuleAccess(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess Allow { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmSecurityRuleDirection : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmSecurityRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmSecurityRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties>
    {
        public HciVmSecurityRuleProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol protocol, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess access, int priority, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection direction) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess Access { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DestinationAddressPrefixes { get { throw null; } }
        public System.Collections.Generic.IList<string> DestinationPortRanges { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection Direction { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> SourceAddressPrefixes { get { throw null; } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmSecurityRuleProtocol : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmSecurityRuleProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol Asterisk { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmSecurityType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmSecurityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType ConfidentialVm { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmSize : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmSize(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize Custom { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize Default { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardD16sV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardD2sV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardD32sV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardD4sV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardD8sV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardK8S2V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardK8S3V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardK8S4V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardK8S5V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardK8SV1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardNK12 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardNK6 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardNV12 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSize StandardNV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSize left, Azure.ResourceManager.Hci.Vm.Models.HciVmSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmSize left, Azure.ResourceManager.Hci.Vm.Models.HciVmSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmStatusLevelType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmStatusLevelType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType Info { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType left, Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType left, Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmStorageContainerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch>
    {
        public HciVmStorageContainerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmStorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties>
    {
        public HciVmStorageContainerProperties(string path) { }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmStorageContainerProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus>
    {
        internal HciVmStorageContainerProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmStorageContainerStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>
    {
        internal HciVmStorageContainerStatus() { }
        public long? AvailableSizeInMB { get { throw null; } }
        public long? ContainerSizeInMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskDownloadStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus>
    {
        internal HciVmVirtualHardDiskDownloadStatus() { }
        public long? DownloadedSizeInMB { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch>
    {
        public HciVmVirtualHardDiskPatch() { }
        public long? DiskSizeGB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties>
    {
        public HciVmVirtualHardDiskProperties() { }
        public int? BlockSizeInBytes { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat? DiskFileFormat { get { throw null; } set { } }
        public long? DiskSizeInGB { get { throw null; } set { } }
        public System.Uri DownloadUri { get { throw null; } set { } }
        public bool? Dynamic { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public bool? IsCreatingFromLocal { get { throw null; } set { } }
        public int? LogicalSectorInBytes { get { throw null; } set { } }
        public long? MaxShares { get { throw null; } set { } }
        public int? PhysicalSectorInBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus>
    {
        internal HciVmVirtualHardDiskProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus>
    {
        internal HciVmVirtualHardDiskStatus() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus DownloadStatus { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus ProvisioningStatus { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus UploadStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskUploadContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent>
    {
        public HciVmVirtualHardDiskUploadContent(System.Uri managedDiskUploadUri) { }
        public System.Uri ManagedDiskUploadUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskUploadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult>
    {
        internal HciVmVirtualHardDiskUploadResult() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus UploadStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualHardDiskId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskUploadStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>
    {
        internal HciVmVirtualHardDiskUploadStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        public long? UploadedSizeInMB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridMachineAgentInstallationStatusType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridMachineAgentInstallationStatusType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType left, Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType left, Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
