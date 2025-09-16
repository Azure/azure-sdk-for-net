namespace Azure.ResourceManager.Hci.Vm
{
    public partial class AttestationStatusData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>
    {
        internal AttestationStatusData() { }
        public Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.AttestationStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.AttestationStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationStatusResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttestationStatusResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.AttestationStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.AttestationStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.AttestationStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.AttestationStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.AttestationStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.AttestationStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties Properties { get { throw null; } set { } }
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
        public Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties Properties { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Hci.Vm.AttestationStatusResource GetAttestationStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> GetNetworkSecurityGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> GetNetworkSecurityGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource GetNetworkSecurityGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupCollection GetNetworkSecurityGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> GetNetworkSecurityGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> GetNetworkSecurityGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.SecurityRuleResource GetSecurityRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        internal HybridIdentityMetadataData() { }
        public Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties Properties { get { throw null; } }
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
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties Properties { get { throw null; } set { } }
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
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties Properties { get { throw null; } set { } }
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
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties Properties { get { throw null; } set { } }
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
    public partial class NetworkSecurityGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>, System.Collections.IEnumerable
    {
        protected NetworkSecurityGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkSecurityGroupName, Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkSecurityGroupName, Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> Get(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> GetAsync(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> GetIfExists(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> GetIfExistsAsync(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkSecurityGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>
    {
        public NetworkSecurityGroupData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkSecurityGroupResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkSecurityGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> GetSecurityRule(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>> GetSecurityRuleAsync(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.SecurityRuleCollection GetSecurityRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>, System.Collections.IEnumerable
    {
        protected SecurityRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securityRuleName, Azure.ResourceManager.Hci.Vm.SecurityRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securityRuleName, Azure.ResourceManager.Hci.Vm.SecurityRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> Get(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>> GetAsync(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> GetIfExists(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>> GetIfExistsAsync(string securityRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>
    {
        public SecurityRuleData() { }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.SecurityRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.SecurityRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityRuleResource() { }
        public virtual Azure.ResourceManager.Hci.Vm.SecurityRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkSecurityGroupName, string securityRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Hci.Vm.SecurityRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.SecurityRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.SecurityRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.SecurityRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.SecurityRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.SecurityRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.SecurityRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties Properties { get { throw null; } set { } }
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
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse> Upload(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse>> UploadAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData>
    {
        public VirtualMachineInstanceData() { }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.Hci.Vm.AttestationStatusResource GetAttestationStatus() { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.GuestAgentResource GetGuestAgent() { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataResource GetHybridIdentityMetadata() { throw null; }
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
        public virtual Azure.ResourceManager.Hci.Vm.AttestationStatusResource GetAttestationStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.GalleryImageResource GetGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.GuestAgentResource GetGuestAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataResource GetHybridIdentityMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.LogicalNetworkResource GetLogicalNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageResource GetMarketplaceGalleryImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.NetworkInterfaceResource GetNetworkInterfaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource GetNetworkSecurityGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.SecurityRuleResource GetSecurityRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> GetNetworkSecurityGroup(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource>> GetNetworkSecurityGroupAsync(string networkSecurityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupCollection GetNetworkSecurityGroups() { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> GetNetworkSecurityGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupResource> GetNetworkSecurityGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.Hci.Vm.AttestationStatusData AttestationStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties AttestationStatusProperties(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum? attestSecureBootEnabled = default(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum?), Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum? attestationCertValidated = default(Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum?), Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum? bootIntegrityValidated = default(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum?), string linuxKernelVersion = null, Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum? healthStatus = default(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum?), string timestamp = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum? attestHardwarePlatform = default(Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum?), Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum? attestDiskSecurityEncryptionType = default(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.GalleryImageData GalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties GalleryImageProperties(Azure.Core.ResourceIdentifier containerId = null, string imagePath = null, Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType osType = default(Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType), Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials vmImageRepositoryCredentials = null, Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion version = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus status = null, Azure.Core.ResourceIdentifier sourceVirtualMachineId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus GalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatusProvisioningStatus GalleryImageStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.GuestAgentData GuestAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus GuestAgentInstallStatus(string vmUuid = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType?), System.DateTimeOffset? lastStatusChange = default(System.DateTimeOffset?), string agentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties GuestAgentProperties(Azure.ResourceManager.Hci.Vm.Models.GuestCredential credentials = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction? provisioningAction = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction?), string status = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.HybridIdentityMetadataData HybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties HybridIdentityMetadataProperties(string resourceUid = null, string publicKey = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus InstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType? level = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.IPConfigurationProperties IPConfigurationProperties(string gateway = null, string prefixLength = null, string privateIPAddress = null, Azure.Core.ResourceIdentifier subnetId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo IPPoolInfo(string used = null, string available = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.LogicalNetworkData LogicalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties LogicalNetworkProperties(System.Collections.Generic.IEnumerable<string> dhcpOptionsDnsServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet> subnets = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?), string vmSwitchName = null, Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus status = null, Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum? networkType = default(Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus LogicalNetworkStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus LogicalNetworkStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.MarketplaceGalleryImageData MarketplaceGalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties MarketplaceGalleryImageProperties(Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType osType = default(Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType), Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion version = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus MarketplaceGalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatusProvisioningStatus MarketplaceGalleryImageStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.NetworkInterfaceData NetworkInterfaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties NetworkInterfaceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration> ipConfigurations = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, bool? createFromLocal = default(bool?), Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus status = null, Azure.Core.ResourceIdentifier networkSecurityGroupId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus NetworkInterfaceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus NetworkInterfaceStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.NetworkSecurityGroupData NetworkSecurityGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties NetworkSecurityGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> networkInterfaces = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> subnets = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus NetworkSecurityGroupStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus NetworkSecurityGroupStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.RouteTable RouteTable(string etag = null, string name = null, string type = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute> routes = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.SecurityRuleData SecurityRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties SecurityRuleProperties(string description = null, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol protocol = default(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol), System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes = null, System.Collections.Generic.IEnumerable<string> destinationAddressPrefixes = null, System.Collections.Generic.IEnumerable<string> sourcePortRanges = null, System.Collections.Generic.IEnumerable<string> destinationPortRanges = null, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess access = default(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess), int priority = 0, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection direction = default(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection), Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.StorageContainerData StorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties StorageContainerProperties(string path = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus StorageContainerStatus(string errorCode = null, string errorMessage = null, long? availableSizeMB = default(long?), long? containerSizeMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus StorageContainerStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.VirtualHardDiskData VirtualHardDiskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus VirtualHardDiskDownloadStatus(long? downloadedSizeInMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties VirtualHardDiskProperties(int? blockSizeBytes = default(int?), long? diskSizeGB = default(long?), bool? dynamic = default(bool?), int? logicalSectorBytes = default(int?), int? physicalSectorBytes = default(int?), string downloadUri = null, Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration?), Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat? diskFileFormat = default(Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat?), bool? createFromLocal = default(bool?), Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?), Azure.Core.ResourceIdentifier containerId = null, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus status = null, long? maxShares = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus VirtualHardDiskStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus provisioningStatus = null, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus downloadStatus = null, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus uploadStatus = null, System.Collections.Generic.IEnumerable<string> managedBy = null, string uniqueId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus VirtualHardDiskStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse VirtualHardDiskUploadResponse(Azure.Core.ResourceIdentifier virtualHardDiskId = null, Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus uploadStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus VirtualHardDiskUploadStatus(long? uploadedSizeInMB = default(long?), Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?), long? progressPercentage = default(long?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView VirtualMachineConfigAgentInstanceView(string vmConfigAgentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Vm.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.VirtualMachineInstanceData VirtualMachineInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties properties = null, Azure.ResourceManager.Hci.Vm.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties VirtualMachineInstanceProperties(Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile hardwareProfile = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile placementProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> networkInterfaces = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile osProfile = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile securityProfile = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile storageProfile = null, Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration httpProxyConfig = null, bool? createFromLocal = default(bool?), Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? provisioningState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum?), Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView instanceViewVmAgent = null, Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus status = null, Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus guestAgentInstallStatus = null, string vmId = null, string resourceUid = null, string hyperVVmId = null, string hostNodeName = null, string hostNodeIPAddress = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus VirtualMachineInstanceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum? powerState = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum?), Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatusProvisioningStatus VirtualMachineInstanceStatusProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? status = default(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus?)) { throw null; }
    }
    public partial class AttestationStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties>
    {
        internal AttestationStatusProperties() { }
        public Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum? AttestationCertValidated { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum? AttestDiskSecurityEncryptionType { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum? AttestHardwarePlatform { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum? AttestSecureBootEnabled { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum? BootIntegrityValidated { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum? HealthStatus { get { throw null; } }
        public string LinuxKernelVersion { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public string Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AttestationStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestBootIntegrityPropertyEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestBootIntegrityPropertyEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum Invalid { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestBootIntegrityPropertyEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestCertPropertyEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestCertPropertyEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum Invalid { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestCertPropertyEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestDiskSecurityEncryptionTypeEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestDiskSecurityEncryptionTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum NonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestDiskSecurityEncryptionTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestHealthStatusEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestHealthStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum Healthy { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum Pending { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestHealthStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestHWPlatformEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestHWPlatformEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum SEVSNP { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestHWPlatformEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestSecureBootPropertyEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestSecureBootPropertyEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum Enabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum left, Azure.ResourceManager.Hci.Vm.Models.AttestSecureBootPropertyEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureStackHciVmNetworkingIPPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool>
    {
        public AzureStackHciVmNetworkingIPPool() { }
        public string End { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.IPPoolInfo Info { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum? IPPoolType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStackHciVmNetworkingRoute : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute>
    {
        public AzureStackHciVmNetworkingRoute() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NextHopIPAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStackHciVmNetworkingSubnet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet>
    {
        public AzureStackHciVmNetworkingSubnet() { }
        public string AddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum? IPAllocationMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> IPConfigurationReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingIPPool> IPPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.RouteTable RouteTable { get { throw null; } set { } }
        public int? Vlan { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStackHciVmOSProfileSshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey>
    {
        public AzureStackHciVmOSProfileSshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStackHciVmPowerStateEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStackHciVmPowerStateEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum Deallocated { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum Deallocating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum Paused { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum Running { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum Saved { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum Starting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum Stopped { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum Stopping { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStackHciVmProvisioningAction : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStackHciVmProvisioningAction(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction Install { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction Repair { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction Uninstall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStackHciVmProvisioningStateEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStackHciVmProvisioningStateEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStackHciVmSecurityType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStackHciVmSecurityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType ConfidentialVm { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStackHciVmStatus : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStackHciVmStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStackHciVmStatusLevelType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStackHciVmStatusLevelType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType Info { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStackHciVmStatusType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStackHciVmStatusType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType left, Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType right) { throw null; }
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
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.ExtendedLocationType? Type { get { throw null; } set { } }
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
    public partial class GalleryImageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties>
    {
        public GalleryImageProperties(Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType osType) { }
        public Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVirtualMachineId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion Version { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials VmImageRepositoryCredentials { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
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
        public long? OSDiskImageSizeInMB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GpuAssignmentTypeEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GpuAssignmentTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum GpuDDA { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum GpuP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum left, Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum left, Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuestAgentInstallStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>
    {
        public GuestAgentInstallStatus() { }
        public string AgentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusChange { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusType? Status { get { throw null; } }
        public string VmUuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GuestAgentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties>
    {
        public GuestAgentProperties() { }
        public Azure.ResourceManager.Hci.Vm.Models.GuestCredential Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningAction? ProvisioningAction { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.GuestAgentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU> VirtualMachineGPUs { get { throw null; } }
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
    public partial class HybridIdentityMetadataProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties>
    {
        internal HybridIdentityMetadataProperties() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } }
        public string ResourceUid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.HybridIdentityMetadataProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatusLevelType? Level { get { throw null; } }
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
    public readonly partial struct IPAllocationMethodEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAllocationMethodEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum left, Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum left, Azure.ResourceManager.Hci.Vm.Models.IPAllocationMethodEnum right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPPoolTypeEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPPoolTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum Vippool { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum Vm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum left, Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum left, Azure.ResourceManager.Hci.Vm.Models.IPPoolTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class LogicalNetworkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties>
    {
        public LogicalNetworkProperties() { }
        public System.Collections.Generic.IList<string> DhcpOptionsDnsServers { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum? NetworkType { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingSubnet> Subnets { get { throw null; } }
        public string VmSwitchName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicalNetworkTypeEnum : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicalNetworkTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum Infrastructure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum Workload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum left, Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum left, Azure.ResourceManager.Hci.Vm.Models.LogicalNetworkTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MarketplaceGalleryImageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties>
    {
        public MarketplaceGalleryImageProperties(Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType osType) { }
        public Azure.ResourceManager.Hci.Vm.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.GalleryImageVersion Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.MarketplaceGalleryImageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
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
        public Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties>
    {
        public NetworkInterfaceProperties() { }
        public bool? CreateFromLocal { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.IPConfiguration> IPConfigurations { get { throw null; } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfaceStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfacesUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties>
    {
        public NetworkInterfacesUpdateProperties() { }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkInterfacesUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch>
    {
        public NetworkSecurityGroupPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties>
    {
        public NetworkSecurityGroupProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> Subnets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityGroupStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus>
    {
        internal NetworkSecurityGroupStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityGroupStatusProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus>
    {
        internal NetworkSecurityGroupStatusProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.NetworkSecurityGroupStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType left, Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType left, Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OSProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate>
    {
        public OSProfileUpdate() { }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSProfileUpdateLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration>
    {
        public OSProfileUpdateLinuxConfiguration() { }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSProfileUpdateWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration>
    {
        public OSProfileUpdateWindowsConfiguration() { }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdateWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouteTable : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>
    {
        public RouteTable() { }
        public string ETag { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmNetworkingRoute> Routes { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.RouteTable System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.RouteTable System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.RouteTable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEncryptionType : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.SecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityEncryptionType NonPersistedTPM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.SecurityEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.SecurityEncryptionType left, Azure.ResourceManager.Hci.Vm.Models.SecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.SecurityEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.SecurityEncryptionType left, Azure.ResourceManager.Hci.Vm.Models.SecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityRuleAccess : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityRuleAccess(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess Allow { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess left, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess left, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityRuleDirection : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection left, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection left, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties>
    {
        public SecurityRuleProperties(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol protocol, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess access, int priority, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection direction) { }
        public Azure.ResourceManager.Hci.Vm.Models.SecurityRuleAccess Access { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DestinationAddressPrefixes { get { throw null; } }
        public System.Collections.Generic.IList<string> DestinationPortRanges { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.SecurityRuleDirection Direction { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> SourceAddressPrefixes { get { throw null; } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityRuleProtocol : System.IEquatable<Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityRuleProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol Asterisk { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol Icmp { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol left, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol left, Azure.ResourceManager.Hci.Vm.Models.SecurityRuleProtocol right) { throw null; }
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
    public partial class StorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties>
    {
        public StorageContainerProperties(string path) { }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.StorageContainerStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskDownloadStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus>
    {
        internal VirtualHardDiskDownloadStatus() { }
        public long? DownloadedSizeInMB { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>
    {
        public VirtualHardDiskPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public long? VirtualHardDisksUpdateDiskSizeGB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties>
    {
        public VirtualHardDiskProperties() { }
        public int? BlockSizeBytes { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ContainerId { get { throw null; } set { } }
        public bool? CreateFromLocal { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.DiskFileFormat? DiskFileFormat { get { throw null; } set { } }
        public long? DiskSizeGB { get { throw null; } set { } }
        public string DownloadUri { get { throw null; } set { } }
        public bool? Dynamic { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public int? LogicalSectorBytes { get { throw null; } set { } }
        public long? MaxShares { get { throw null; } set { } }
        public int? PhysicalSectorBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatus>
    {
        internal VirtualHardDiskStatus() { }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskDownloadStatus DownloadStatus { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus ProvisioningStatus { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus UploadStatus { get { throw null; } }
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
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskStatusProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskUploadContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent>
    {
        public VirtualHardDiskUploadContent(string azureManagedDiskUploadUri) { }
        public string AzureManagedDiskUploadUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskUploadResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse>
    {
        internal VirtualHardDiskUploadResponse() { }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus UploadStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualHardDiskId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualHardDiskUploadStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus>
    {
        internal VirtualHardDiskUploadStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
        public long? UploadedSizeInMB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualHardDiskUploadStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VirtualMachineInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties>
    {
        public VirtualMachineInstanceProperties() { }
        public bool? CreateFromLocal { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.GuestAgentInstallStatus GuestAgentInstallStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile HardwareProfile { get { throw null; } set { } }
        public string HostNodeIPAddress { get { throw null; } }
        public string HostNodeName { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.HttpProxyConfiguration HttpProxyConfig { get { throw null; } set { } }
        public string HyperVVmId { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineConfigAgentInstanceView InstanceViewVmAgent { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile PlacementProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmProvisioningStateEnum? ProvisioningState { get { throw null; } }
        public string ResourceUid { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile StorageProfile { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfile>
    {
        public VirtualMachineInstancePropertiesHardwareProfile() { }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileDynamicMemoryConfig DynamicMemoryConfig { get { throw null; } set { } }
        public long? MemoryMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU> VirtualMachineGPUs { get { throw null; } }
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
    public partial class VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU>
    {
        public VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU(Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum assignmentType) { }
        public Azure.ResourceManager.Hci.Vm.Models.GpuAssignmentTypeEnum AssignmentType { get { throw null; } set { } }
        public string GpuName { get { throw null; } set { } }
        public long? PartitionSizeMB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesHardwareProfileVirtualMachineGPU>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile>
    {
        public VirtualMachineInstancePropertiesOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesOSProfileLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>
    {
        public VirtualMachineInstancePropertiesOSProfileLinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey> SshPublicKeys { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesOSProfileWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>
    {
        public VirtualMachineInstancePropertiesOSProfileWindowsConfiguration() { }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public bool? ProvisionVmConfigAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmOSProfileSshPublicKey> SshPublicKeys { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesOSProfileWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesPlacementProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile>
    {
        public VirtualMachineInstancePropertiesPlacementProfile() { }
        public bool? StrictPlacementPolicy { get { throw null; } set { } }
        public string Zone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesPlacementProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesSecurityProfile>
    {
        public VirtualMachineInstancePropertiesSecurityProfile() { }
        public bool? EnableTPM { get { throw null; } set { } }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmSecurityType? SecurityType { get { throw null; } set { } }
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
        public Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk OSDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmConfigStoragePathId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstancePropertiesStorageProfileOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>
    {
        public VirtualMachineInstancePropertiesStorageProfileOSDisk() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.OperatingSystemType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Vm.Models.SecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstancePropertiesStorageProfileOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceStatus>
    {
        internal VirtualMachineInstanceStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmPowerStateEnum? PowerState { get { throw null; } }
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
        public Azure.ResourceManager.Hci.Vm.Models.AzureStackHciVmStatus? Status { get { throw null; } }
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
        public Azure.ResourceManager.Hci.Vm.Models.OSProfileUpdate OSProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> StorageDataDisks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VirtualMachineInstanceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmImageRepositoryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials>
    {
        public VmImageRepositoryCredentials(string username, string password) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Hci.Vm.Models.VmImageRepositoryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD16sV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD2sV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD32sV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD4sV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Vm.Models.VmSizeEnum StandardD8sV3 { get { throw null; } }
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
