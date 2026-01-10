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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusResource GetHciVmAttestationStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusResource GetHciVmAttestationStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> GetHciVmGalleryImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource GetHciVmGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGalleryImageCollection GetHciVmGalleryImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource GetHciVmGuestAgent(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource GetHciVmGuestAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataResource GetHciVmHybridIdentityMetadata(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataResource GetHciVmHybridIdentityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmInstanceResource GetHciVmInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmInstanceResource GetHciVmInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> GetHciVmLoadBalancer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> GetHciVmLoadBalancerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource GetHciVmLoadBalancerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerCollection GetHciVmLoadBalancers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> GetHciVmLoadBalancers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> GetHciVmLoadBalancersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> GetHciVmNatGateway(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> GetHciVmNatGatewayAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource GetHciVmNatGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNatGatewayCollection GetHciVmNatGateways(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> GetHciVmNatGateways(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> GetHciVmNatGatewaysAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> GetHciVmPublicIPAddress(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> GetHciVmPublicIPAddressAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressCollection GetHciVmPublicIPAddresses(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> GetHciVmPublicIPAddresses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> GetHciVmPublicIPAddressesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource GetHciVmPublicIPAddressResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> GetHciVmVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> GetHciVmVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource GetHciVmVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkCollection GetHciVmVirtualNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> GetHciVmVirtualNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> GetHciVmVirtualNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource GetHciVmVirtualNetworkSubnetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HciVmLoadBalancerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>, System.Collections.IEnumerable
    {
        protected HciVmLoadBalancerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loadBalancerName, Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loadBalancerName, Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> Get(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> GetAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> GetIfExists(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> GetIfExistsAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmLoadBalancerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>
    {
        public HciVmLoadBalancerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLoadBalancerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmLoadBalancerResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string loadBalancerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HciVmNatGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>, System.Collections.IEnumerable
    {
        protected HciVmNatGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string natGatewayName, Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string natGatewayName, Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> Get(string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> GetAsync(string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> GetIfExists(string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> GetIfExistsAsync(string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmNatGatewayData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>
    {
        public HciVmNatGatewayData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNatGatewayResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmNatGatewayResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string natGatewayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HciVmPublicIPAddressCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>, System.Collections.IEnumerable
    {
        protected HciVmPublicIPAddressCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string publicIPAddressName, Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string publicIPAddressName, Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> Get(string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> GetAsync(string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> GetIfExists(string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> GetIfExistsAsync(string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmPublicIPAddressData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>
    {
        public HciVmPublicIPAddressData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmPublicIPAddressResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmPublicIPAddressResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publicIPAddressName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HciVmVirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected HciVmVirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> Get(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> GetAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> GetIfExists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> GetIfExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmVirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>
    {
        public HciVmVirtualNetworkData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> GetHciVmVirtualNetworkSubnet(string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>> GetHciVmVirtualNetworkSubnetAsync(string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetCollection GetHciVmVirtualNetworkSubnets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVmVirtualNetworkSubnetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>, System.Collections.IEnumerable
    {
        protected HciVmVirtualNetworkSubnetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string subnetName, Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string subnetName, Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> Get(string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>> GetAsync(string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> GetIfExists(string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>> GetIfExistsAsync(string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVmVirtualNetworkSubnetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>
    {
        public HciVmVirtualNetworkSubnetData() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkSubnetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVmVirtualNetworkSubnetResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName, string subnetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Vm.Mocking
{
    public partial class MockableHciVmArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHciVmArmClient() { }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusResource GetHciVmAttestationStatus(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusResource GetHciVmAttestationStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource GetHciVmGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource GetHciVmGuestAgent(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGuestAgentResource GetHciVmGuestAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataResource GetHciVmHybridIdentityMetadata(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataResource GetHciVmHybridIdentityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmInstanceResource GetHciVmInstance(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmInstanceResource GetHciVmInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource GetHciVmLoadBalancerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource GetHciVmLogicalNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource GetHciVmMarketplaceGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource GetHciVmNatGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource GetHciVmNetworkInterfaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource GetHciVmNetworkSecurityGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource GetHciVmPublicIPAddressResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleResource GetHciVmSecurityRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource GetHciVmStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource GetHciVmVirtualHardDiskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource GetHciVmVirtualNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetResource GetHciVmVirtualNetworkSubnetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHciVmResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciVmResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImage(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource>> GetHciVmGalleryImageAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmGalleryImageCollection GetHciVmGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> GetHciVmLoadBalancer(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource>> GetHciVmLoadBalancerAsync(string loadBalancerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerCollection GetHciVmLoadBalancers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetHciVmLogicalNetwork(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource>> GetHciVmLogicalNetworkAsync(string logicalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkCollection GetHciVmLogicalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetHciVmMarketplaceGalleryImage(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource>> GetHciVmMarketplaceGalleryImageAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageCollection GetHciVmMarketplaceGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> GetHciVmNatGateway(string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource>> GetHciVmNatGatewayAsync(string natGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNatGatewayCollection GetHciVmNatGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetHciVmNetworkInterface(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource>> GetHciVmNetworkInterfaceAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceCollection GetHciVmNetworkInterfaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetHciVmNetworkSecurityGroup(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource>> GetHciVmNetworkSecurityGroupAsync(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupCollection GetHciVmNetworkSecurityGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> GetHciVmPublicIPAddress(string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource>> GetHciVmPublicIPAddressAsync(string publicIPAddressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressCollection GetHciVmPublicIPAddresses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetHciVmStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource>> GetHciVmStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmStorageContainerCollection GetHciVmStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetHciVmVirtualHardDisk(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource>> GetHciVmVirtualHardDiskAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskCollection GetHciVmVirtualHardDisks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> GetHciVmVirtualNetwork(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource>> GetHciVmVirtualNetworkAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkCollection GetHciVmVirtualNetworks() { throw null; }
    }
    public partial class MockableHciVmSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHciVmSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmGalleryImageResource> GetHciVmGalleryImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> GetHciVmLoadBalancers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerResource> GetHciVmLoadBalancersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetHciVmLogicalNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkResource> GetHciVmLogicalNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetHciVmMarketplaceGalleryImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageResource> GetHciVmMarketplaceGalleryImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> GetHciVmNatGateways(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNatGatewayResource> GetHciVmNatGatewaysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetHciVmNetworkInterfaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceResource> GetHciVmNetworkInterfacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetHciVmNetworkSecurityGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupResource> GetHciVmNetworkSecurityGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> GetHciVmPublicIPAddresses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressResource> GetHciVmPublicIPAddressesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetHciVmStorageContainers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmStorageContainerResource> GetHciVmStorageContainersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetHciVmVirtualHardDisks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskResource> GetHciVmVirtualHardDisksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> GetHciVmVirtualNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkResource> GetHciVmVirtualNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Vm.Models
{
    public static partial class ArmHciVmModelFactory
    {
        public static Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus GuestAgentInstallStatus(string vmUuid = null, Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType? status = default(Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType?), System.DateTimeOffset? lastStatusChangedOn = default(System.DateTimeOffset?), string agentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmAttestationStatusData HciVmAttestationStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties HciVmAttestationStatusProperties(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus? attestSecureBootEnabled = default(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus?), Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus? attestationCertValidated = default(Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus?), Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus? bootIntegrityValidated = default(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus?), string linuxKernelVersion = null, Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus? healthStatus = default(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus?), string timestamp = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType? attestHardwarePlatform = default(Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType?), Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType? attestDiskSecurityEncryptionType = default(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties HciVmBackendAddressPoolProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress> loadBalancerBackendAddresses = null, Azure.Core.ResourceIdentifier virtualNetworkResourceId = null, Azure.Core.ResourceIdentifier logicalNetworkId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView HciVmConfigAgentInstanceView(string vmConfigAgentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus HciVmFabricIntegrationStatus(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType? state = default(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType?), Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType? health = default(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType?), System.DateTimeOffset? lastCheckedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType? resourceType = default(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue> issues = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue HciVmFabricIssue(string code = null, string severity = null, string message = null, string target = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGalleryImageData HciVmGalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch HciVmGalleryImagePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties HciVmGalleryImageProperties(Azure.Core.ResourceIdentifier containerId = null, string imagePath = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOSType osType = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType), Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion version = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus status = null, Azure.Core.ResourceIdentifier sourceVirtualMachineId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus HciVmGalleryImageProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus HciVmGalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmGuestAgentData HciVmGuestAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties HciVmGuestAgentProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential credentials = null, Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction? provisioningAction = default(Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction?), string status = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration HciVmHttpProxyConfiguration(string httpProxy = null, string httpsProxy = null, System.Collections.Generic.IEnumerable<string> noProxy = null, string trustedCa = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmHybridIdentityMetadataData HciVmHybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties HciVmHybridIdentityMetadataProperties(string resourceUid = null, string publicKey = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmInstanceData HciVmInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile HciVmInstanceHardwareProfile(Azure.ResourceManager.Hci.Vm.Models.HciVmSize? vmSize = default(Azure.ResourceManager.Hci.Vm.Models.HciVmSize?), int? processors = default(int?), long? memoryInMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration dynamicMemoryConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration> virtualMachineGPUs = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate HciVmInstanceHardwareProfileUpdate(Azure.ResourceManager.Hci.Vm.Models.HciVmSize? vmSize = default(Azure.ResourceManager.Hci.Vm.Models.HciVmSize?), int? processors = default(int?), long? memoryInMB = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration> virtualMachineGPUs = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties HciVmInstanceProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile hardwareProfile = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile placementProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference> networkInterfaces = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile osProfile = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile securityProfile = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile storageProfile = null, Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration httpProxyConfig = null, bool? isCreatingFromLocal = default(bool?), string localVmName = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView instanceViewVmAgent = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus status = null, Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus guestAgentInstallStatus = null, string vmId = null, string resourceUid = null, string hyperVVmId = null, string hostNodeName = null, string hostNodeIPAddress = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus HciVmInstanceProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus HciVmInstanceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState? powerState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState?), Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile HciVmInstanceStorageProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference> dataDisks = null, Azure.Core.ResourceIdentifier imageReferenceId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk osDisk = null, Azure.Core.ResourceIdentifier vmConfigStoragePathId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus HciVmInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType? level = default(Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties HciVmIPConfigurationProperties(string gateway = null, string prefixLength = null, string privateIPAddress = null, Azure.Core.ResourceIdentifier subnetId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo HciVmIPPoolInfo(string used = null, string available = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties HciVmLoadBalancerBackendAddressProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState? adminState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState?), string ipAddress = null, Azure.Core.ResourceIdentifier subnetResourceId = null, Azure.Core.ResourceIdentifier virtualNetworkResourceId = null, Azure.Core.ResourceIdentifier logicalNetworkId = null, Azure.Core.ResourceIdentifier networkInterfaceIPResourceId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmLoadBalancerData HciVmLoadBalancerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch HciVmLoadBalancerPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties HciVmLoadBalancerProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration> frontendIPConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool> backendAddressPools = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule> loadBalancingRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe> probes = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus HciVmLoadBalancerStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus HciVmLoadBalancerStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmLogicalNetworkData HciVmLogicalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch HciVmLogicalNetworkPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties HciVmLogicalNetworkProperties(System.Collections.Generic.IEnumerable<string> dhcpOptionsDnsServers = null, Azure.Core.ResourceIdentifier fabricNetworkResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet> subnets = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), string vmSwitchName = null, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus status = null, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType? networkType = default(Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus HciVmLogicalNetworkProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus HciVmLogicalNetworkStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus provisioningStatus = null, Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus fabricIntegration = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmMarketplaceGalleryImageData HciVmMarketplaceGalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch HciVmMarketplaceGalleryImagePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties HciVmMarketplaceGalleryImageProperties(Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOSType osType = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType), Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion version = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus HciVmMarketplaceGalleryImageProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus HciVmMarketplaceGalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNatGatewayData HciVmNatGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch HciVmNatGatewayPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties HciVmNatGatewayProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference> publicIPAddresses = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference> subnets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule> inboundNatRules = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus HciVmNatGatewayStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus HciVmNatGatewayStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable HciVmNetworkingRouteTable(string etag = null, string name = null, string type = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute> routes = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNetworkInterfaceData HciVmNetworkInterfaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch HciVmNetworkInterfacePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties HciVmNetworkInterfaceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration> ipConfigurations = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, bool? createFromLocal = default(bool?), Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus status = null, Azure.Core.ResourceIdentifier networkSecurityGroupId = null, bool? isSdnPoliciesBypassed = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus HciVmNetworkInterfaceProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus HciVmNetworkInterfaceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmNetworkSecurityGroupData HciVmNetworkSecurityGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch HciVmNetworkSecurityGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties HciVmNetworkSecurityGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference> networkInterfaces = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference> subnets = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus HciVmNetworkSecurityGroupProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus HciVmNetworkSecurityGroupStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmPublicIPAddressData HciVmPublicIPAddressData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch HciVmPublicIPAddressPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties HciVmPublicIPAddressProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType? publicIPAddressVersion = default(Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType?), Azure.Core.ResourceIdentifier ipAllocationScope = null, string ipAddress = null, Azure.Core.ResourceIdentifier ipResourceId = null, Azure.Core.ResourceIdentifier natGatewayResourceId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmSecurityRuleData HciVmSecurityRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties HciVmSecurityRuleProperties(string description = null, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol protocol = default(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol), System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes = null, System.Collections.Generic.IEnumerable<string> destinationAddressPrefixes = null, System.Collections.Generic.IEnumerable<string> sourcePortRanges = null, System.Collections.Generic.IEnumerable<string> destinationPortRanges = null, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess access = default(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess), int priority = 0, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection direction = default(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection), Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmStorageContainerData HciVmStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch HciVmStorageContainerPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties HciVmStorageContainerProperties(string path = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus HciVmStorageContainerProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus HciVmStorageContainerStatus(string errorCode = null, string errorMessage = null, long? availableSizeInMB = default(long?), long? containerSizeInMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmVirtualHardDiskData HciVmVirtualHardDiskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus HciVmVirtualHardDiskDownloadStatus(long? downloadedSizeInMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch HciVmVirtualHardDiskPatch(System.Collections.Generic.IDictionary<string, string> tags = null, long? diskSizeGB = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties HciVmVirtualHardDiskProperties(int? blockSizeInBytes = default(int?), long? diskSizeInGB = default(long?), bool? dynamic = default(bool?), int? logicalSectorInBytes = default(int?), int? physicalSectorInBytes = default(int?), System.Uri downloadUri = null, Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat? diskFileFormat = default(Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat?), bool? isCreatingFromLocal = default(bool?), string localVhdPath = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus status = null, long? maxShares = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus HciVmVirtualHardDiskProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus HciVmVirtualHardDiskStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus provisioningStatus = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus downloadStatus = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus uploadStatus = null, System.Collections.Generic.IEnumerable<string> managedBy = null, string uniqueId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent HciVmVirtualHardDiskUploadContent(System.Uri managedDiskUploadUri = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult HciVmVirtualHardDiskUploadResult(Azure.Core.ResourceIdentifier virtualHardDiskId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus uploadStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus HciVmVirtualHardDiskUploadStatus(long? uploadedSizeInMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?), long? progressPercentage = default(long?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkData HciVmVirtualNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch HciVmVirtualNetworkPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties HciVmVirtualNetworkProperties(System.Collections.Generic.IEnumerable<string> addressPrefixes = null, System.Collections.Generic.IEnumerable<string> dhcpOptionsDnsServers = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HciVmVirtualNetworkSubnetData HciVmVirtualNetworkSubnetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference HciVmVirtualNetworkSubnetIPConfigurationReference(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties HciVmVirtualNetworkSubnetProperties(string addressPrefix = null, Azure.Core.ResourceIdentifier networkSecurityGroupId = null, Azure.Core.ResourceIdentifier natGatewayResourceId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable routeTable = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference> ipConfigurations = null, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState?), Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus HciVmVirtualNetworkSubnetStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus HciVmVirtualNetworkSubnetStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus?)) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityStatus? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestCertValidationStatus? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType left, Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType left, Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestHardwarePlatformType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatus? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus left, Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootStatus? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource left, Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType left, Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction left, Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.GuestAgentProvisioningAction? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmAttestationStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmBackendAddressPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool>
    {
        public HciVmBackendAddressPool(string name, Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmBackendAddressPoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties>
    {
        public HciVmBackendAddressPoolProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress> LoadBalancerBackendAddresses { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogicalNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmConfigAgentInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView>
    {
        internal HciVmConfigAgentInstanceView() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus> Statuses { get { throw null; } }
        public string VmConfigAgentVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmConfigAgentInstanceView PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat left, Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat left, Azure.ResourceManager.Hci.Vm.Models.HciVmDiskFileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation>
    {
        public HciVmExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType left, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType left, Azure.ResourceManager.Hci.Vm.Models.HciVmExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmFabricConnectionHealthStateType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmFabricConnectionHealthStateType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType Healthy { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType left, Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType left, Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmFabricIntegrationStateType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmFabricIntegrationStateType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType Connecting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType Misconfigured { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType left, Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType left, Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmFabricIntegrationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus>
    {
        internal HciVmFabricIntegrationStatus() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmFabricConnectionHealthStateType? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue> Issues { get { throw null; } }
        public System.DateTimeOffset? LastCheckedOn { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStateType? State { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmFabricIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue>
    {
        internal HciVmFabricIssue() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Severity { get { throw null; } }
        public string Target { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmFabricResourceType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmFabricResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType L2IsolationDomain { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType L3InternalNetwork { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType left, Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType left, Azure.ResourceManager.Hci.Vm.Models.HciVmFabricResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmFrontendIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration>
    {
        public HciVmFrontendIPConfiguration(string name, Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmFrontendIPConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties>
    {
        public HciVmFrontendIPConfigurationProperties() { }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod? PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPAddressResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmGalleryImageIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier>
    {
        public HciVmGalleryImageIdentifier(string publisher, string offer, string sku) { }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageIdentifier PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImagePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public long? StorageOSDiskImageSizeInMB { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGalleryImageVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGuestAgentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmGuestCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmHttpProxyConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmHybridIdentityMetadataProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration NA { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration left, Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration left, Azure.ResourceManager.Hci.Vm.Models.HciVmHyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmInboundNatRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule>
    {
        public HciVmInboundNatRule(string name, Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInboundNatRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties>
    {
        public HciVmInboundNatRuleProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol protocol, int frontendPort, int backendPort) { }
        public Azure.Core.ResourceIdentifier BackendIPResourceId { get { throw null; } set { } }
        public int BackendPort { get { throw null; } set { } }
        public int FrontendPort { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol Protocol { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPAddressResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmInboundNatRuleProtocol : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmInboundNatRuleProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol left, Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol left, Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRuleProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmInstanceHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>
    {
        public HciVmInstanceHardwareProfile() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration DynamicMemoryConfig { get { throw null; } set { } }
        public long? MemoryInMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration> VirtualMachineGPUs { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSize? VmSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceHardwareProfileDynamicMemoryConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration>
    {
        public HciVmInstanceHardwareProfileDynamicMemoryConfiguration() { }
        public long? MaximumMemoryInMB { get { throw null; } set { } }
        public long? MinimumMemoryInMB { get { throw null; } set { } }
        public int? TargetMemoryBuffer { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileDynamicMemoryConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceHardwareProfileGpuConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration>
    {
        public HciVmInstanceHardwareProfileGpuConfiguration(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType assignmentType) { }
        public Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentType AssignmentType { get { throw null; } set { } }
        public string GpuName { get { throw null; } set { } }
        public long? PartitionSizeInMB { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileGpuConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceHardwareProfileUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileLinuxConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfileWindowsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile OSProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference> StorageDataDisks { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string LocalVmName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstancePlacementProfile PlacementProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceUid { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile StorageProfile { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceSecurityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmInstanceStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile>
    {
        public HciVmInstanceStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference> DataDisks { get { throw null; } }
        public Azure.Core.ResourceIdentifier ImageReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk OSDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmConfigStoragePathId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType? ManagedDiskSecurityEncryptionType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSType? OSType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceStorageProfileOSDisk PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmInstanceViewStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod left, Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod left, Azure.ResourceManager.Hci.Vm.Models.HciVmIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration>
    {
        public HciVmIPConfiguration() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmIPConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType left, Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType left, Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmLoadBalancerBackendAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress>
    {
        public HciVmLoadBalancerBackendAddress(string name, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmLoadBalancerBackendAddressAdminState : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmLoadBalancerBackendAddressAdminState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState Down { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState Up { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState left, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState left, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmLoadBalancerBackendAddressProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties>
    {
        public HciVmLoadBalancerBackendAddressProperties() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressAdminState? AdminState { get { throw null; } set { } }
        public string IPAddress { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogicalNetworkId { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkInterfaceIPResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerBackendAddressProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLoadBalancerHealthProbe : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe>
    {
        public HciVmLoadBalancerHealthProbe(string name, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLoadBalancerHealthProbeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties>
    {
        public HciVmLoadBalancerHealthProbeProperties(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol protocol, int port) { }
        public int? IntervalInSeconds { get { throw null; } set { } }
        public int? NumberOfProbes { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol Protocol { get { throw null; } set { } }
        public string RequestPath { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLoadBalancerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch>
    {
        public HciVmLoadBalancerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmLoadBalancerProbeProtocol : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmLoadBalancerProbeProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol Tcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol left, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol left, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProbeProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmLoadBalancerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties>
    {
        public HciVmLoadBalancerProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration> frontendIPConfigurations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmBackendAddressPool> BackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmFrontendIPConfiguration> FrontendIPConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule> LoadBalancingRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerHealthProbe> Probes { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLoadBalancerRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule>
    {
        public HciVmLoadBalancerRule(string name, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLoadBalancerRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties>
    {
        public HciVmLoadBalancerRuleProperties(string frontendIPName, string backendAddressPoolName, int frontendPort, int backendPort, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol protocol) { }
        public string BackendAddressPoolName { get { throw null; } set { } }
        public int BackendPort { get { throw null; } set { } }
        public string FrontendIPName { get { throw null; } set { } }
        public int FrontendPort { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType? LoadDistribution { get { throw null; } set { } }
        public string ProbeName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol Protocol { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmLoadBalancerRuleSessionPersistenceType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmLoadBalancerRuleSessionPersistenceType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType Default { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType SourceIP { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType SourceIPProtocol { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType left, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType left, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleSessionPersistenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmLoadBalancerRuleTransportProtocol : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmLoadBalancerRuleTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol All { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol left, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol left, Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerRuleTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmLoadBalancerStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus>
    {
        internal HciVmLoadBalancerStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLoadBalancerStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus>
    {
        internal HciVmLoadBalancerStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLoadBalancerStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLogicalNetworkArmReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference>
    {
        public HciVmLogicalNetworkArmReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmLogicalNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch>
    {
        public HciVmLogicalNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.Core.ResourceIdentifier FabricNetworkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType? NetworkType { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet> Subnets { get { throw null; } }
        public string VmSwitchName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Vm.Models.HciVmFabricIntegrationStatus FabricIntegration { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType left, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType left, Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmMarketplaceGalleryImagePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch>
    {
        public HciVmMarketplaceGalleryImagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImagePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmMarketplaceGalleryImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNatGatewayPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch>
    {
        public HciVmNatGatewayPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNatGatewayProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties>
    {
        public HciVmNatGatewayProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmInboundNatRule> InboundNatRules { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference> PublicIPAddresses { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference> Subnets { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNatGatewayStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus>
    {
        internal HciVmNatGatewayStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNatGatewayStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus>
    {
        internal HciVmNatGatewayStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNatGatewayStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkingIPPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool>
    {
        public HciVmNetworkingIPPool() { }
        public string End { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolInfo Info { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmIPPoolType? IPPoolType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRoute PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference> IPConfigurationReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingIPPool> IPPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable RouteTable { get { throw null; } set { } }
        public int? Vlan { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingSubnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkInterfaceArmReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference>
    {
        public HciVmNetworkInterfaceArmReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkInterfacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch>
    {
        public HciVmNetworkInterfacePatch() { }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? IsSdnPoliciesBypassed { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfacePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? IsSdnPoliciesBypassed { get { throw null; } set { } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmNetworkSecurityGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties>
    {
        public HciVmNetworkSecurityGroupProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkInterfaceArmReference> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Vm.Models.HciVmLogicalNetworkArmReference> Subnets { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkSecurityGroupStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus left, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus left, Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile>
    {
        public HciVmOSProfile() { }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileLinuxConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileSshPublicKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmOSProfileWindowsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmOSType left, Azure.ResourceManager.Hci.Vm.Models.HciVmOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmOSType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmOSType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState left, Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmPowerState? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState left, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState left, Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmPublicIPAddressArmReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference>
    {
        public HciVmPublicIPAddressArmReference() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressArmReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmPublicIPAddressPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch>
    {
        public HciVmPublicIPAddressPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmPublicIPAddressProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties>
    {
        public HciVmPublicIPAddressProperties() { }
        public string IPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IPAllocationScope { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IPResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier NatGatewayResourceId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType? PublicIPAddressVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVmPublicIPAddressType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVmPublicIPAddressType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType left, Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType left, Azure.ResourceManager.Hci.Vm.Models.HciVmPublicIPAddressType right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityEncryptionType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleAccess? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleDirection? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityRuleProtocol? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType left, Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSecurityType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmSize left, Azure.ResourceManager.Hci.Vm.Models.HciVmSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSize (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmSize? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType left, Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType left, Azure.ResourceManager.Hci.Vm.Models.HciVmStatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVmStorageContainerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch>
    {
        public HciVmStorageContainerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmStorageContainerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmSubnetIPConfigurationReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference>
    {
        public HciVmSubnetIPConfigurationReference() { }
        public Azure.Core.ResourceIdentifier ID { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmSubnetIPConfigurationReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskArmReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference>
    {
        public HciVmVirtualHardDiskArmReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskArmReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualHardDiskDownloadStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus>
    {
        internal HciVmVirtualHardDiskDownloadStatus() { }
        public long? DownloadedSizeInMB { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskDownloadStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string LocalVhdPath { get { throw null; } set { } }
        public int? LogicalSectorInBytes { get { throw null; } set { } }
        public long? MaxShares { get { throw null; } set { } }
        public int? PhysicalSectorInBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<string> ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskProvisioningStatus ProvisioningStatus { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus UploadStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualHardDiskUploadStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch>
    {
        public HciVmVirtualNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties>
    {
        public HciVmVirtualNetworkProperties(System.Collections.Generic.IEnumerable<string> addressPrefixes) { }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public System.Collections.Generic.IList<string> DhcpOptionsDnsServers { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus>
    {
        public HciVmVirtualNetworkStatus() { }
        public string ErrorCode { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus ProvisioningStatus { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus>
    {
        public HciVmVirtualNetworkStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkSubnetArmReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference>
    {
        public HciVmVirtualNetworkSubnetArmReference() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetArmReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkSubnetIPConfigurationReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference>
    {
        internal HciVmVirtualNetworkSubnetIPConfigurationReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkSubnetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch>
    {
        public HciVmVirtualNetworkSubnetPatch() { }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkSubnetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties>
    {
        public HciVmVirtualNetworkSubnetProperties(string addressPrefix) { }
        public string AddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetIPConfigurationReference> IPConfigurations { get { throw null; } }
        public Azure.Core.ResourceIdentifier NatGatewayResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmNetworkingRouteTable RouteTable { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkSubnetStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus>
    {
        internal HciVmVirtualNetworkSubnetStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HciVmVirtualNetworkSubnetStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus>
    {
        internal HciVmVirtualNetworkSubnetStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HciVmOperationStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HciVmVirtualNetworkSubnetStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType left, Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType left, Azure.ResourceManager.Hci.Vm.Models.HybridMachineAgentInstallationStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualNetworkSubnetUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties>
    {
        public VirtualNetworkSubnetUpdateProperties() { }
        public Azure.Core.ResourceIdentifier NatGatewayResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualNetworkSubnetUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
