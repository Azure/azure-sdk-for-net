namespace Azure.ResourceManager.MobileNetwork
{
    public partial class AzureResourceManagerMobileNetworkContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMobileNetworkContext() { }
        public static Azure.ResourceManager.MobileNetwork.AzureResourceManagerMobileNetworkContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ExtendedUEInfoCollection : Azure.ResourceManager.ArmCollection
    {
        protected ExtendedUEInfoCollection() { }
        public virtual Azure.Response<bool> Exists(string ueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource> Get(string ueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource>> GetAsync(string ueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource> GetIfExists(string ueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource>> GetIfExistsAsync(string ueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedUEInfoData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>
    {
        public ExtendedUEInfoData(Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties properties) { }
        public Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtendedUEInfoResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtendedUEInfoResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName, string ueId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileAttachedDataNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>, System.Collections.IEnumerable
    {
        protected MobileAttachedDataNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachedDataNetworkName, Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachedDataNetworkName, Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> Get(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>> GetAsync(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> GetIfExists(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>> GetIfExistsAsync(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileAttachedDataNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>
    {
        public MobileAttachedDataNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties userPlaneDataInterface, System.Collections.Generic.IEnumerable<string> dnsAddresses) { }
        public System.Collections.Generic.IList<string> DnsAddresses { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration NaptConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> UserEquipmentAddressPoolPrefix { get { throw null; } }
        public System.Collections.Generic.IList<string> UserEquipmentStaticAddressPoolPrefix { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties UserPlaneDataInterface { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileAttachedDataNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileAttachedDataNetworkResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName, string packetCoreDataPlaneName, string attachedDataNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileDataNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>, System.Collections.IEnumerable
    {
        protected MobileDataNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataNetworkName, Azure.ResourceManager.MobileNetwork.MobileDataNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataNetworkName, Azure.ResourceManager.MobileNetwork.MobileDataNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> Get(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>> GetAsync(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> GetIfExists(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>> GetIfExistsAsync(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileDataNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>
    {
        public MobileDataNetworkData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileDataNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileDataNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileDataNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileDataNetworkResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileDataNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string dataNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileDataNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileDataNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileDataNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mobileNetworkName, Azure.ResourceManager.MobileNetwork.MobileNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mobileNetworkName, Azure.ResourceManager.MobileNetwork.MobileNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> Get(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> GetAsync(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetIfExists(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> GetIfExistsAsync(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>
    {
        public MobileNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId publicLandMobileNetworkIdentifier) { }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId PublicLandMobileNetworkIdentifier { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork> PublicLandMobileNetworks { get { throw null; } }
        public string ServiceKey { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkDiagnosticsPackageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkDiagnosticsPackageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> Get(string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>> GetAsync(string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> GetIfExists(string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>> GetIfExistsAsync(string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkDiagnosticsPackageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>
    {
        public MobileNetworkDiagnosticsPackageData() { }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkDiagnosticsPackageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkDiagnosticsPackageResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName, string diagnosticsPackageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MobileNetworkExtensions
    {
        public static Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource GetExtendedUEInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource GetMobileAttachedDataNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource GetMobileDataNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> GetMobileNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource GetMobileNetworkDiagnosticsPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource GetMobileNetworkPacketCaptureResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkResource GetMobileNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoResource GetMobileNetworkRoutingInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkCollection GetMobileNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource GetMobileNetworkServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetMobileNetworkSimGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> GetMobileNetworkSimGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource GetMobileNetworkSimGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupCollection GetMobileNetworkSimGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetMobileNetworkSimGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetMobileNetworkSimGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource GetMobileNetworkSimPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource GetMobileNetworkSimResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource GetMobileNetworkSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource GetMobileNetworkSliceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlane(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> GetPacketCoreControlPlaneAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource GetPacketCoreControlPlaneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneCollection GetPacketCoreControlPlanes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlanes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlanesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource GetPacketCoreDataPlaneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource> GetSubscriptionPacketCoreControlPlaneVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource>> GetSubscriptionPacketCoreControlPlaneVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource GetSubscriptionPacketCoreControlPlaneVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionCollection GetSubscriptionPacketCoreControlPlaneVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource> GetTenantPacketCoreControlPlaneVersion(this Azure.ResourceManager.Resources.TenantResource tenantResource, string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource>> GetTenantPacketCoreControlPlaneVersionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource GetTenantPacketCoreControlPlaneVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionCollection GetTenantPacketCoreControlPlaneVersions(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class MobileNetworkPacketCaptureCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkPacketCaptureCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string packetCaptureName, Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string packetCaptureName, Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string packetCaptureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string packetCaptureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> Get(string packetCaptureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>> GetAsync(string packetCaptureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> GetIfExists(string packetCaptureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>> GetIfExistsAsync(string packetCaptureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkPacketCaptureData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>
    {
        public MobileNetworkPacketCaptureData() { }
        public long? BytesToCapturePerPacket { get { throw null; } set { } }
        public System.DateTimeOffset? CaptureStartOn { get { throw null; } }
        public System.Collections.Generic.IList<string> NetworkInterfaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OutputFiles { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus? Status { get { throw null; } }
        public int? TimeLimitInSeconds { get { throw null; } set { } }
        public long? TotalBytesPerSession { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkPacketCaptureResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkPacketCaptureResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName, string packetCaptureName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource> GetMobileDataNetwork(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource>> GetMobileDataNetworkAsync(string dataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileDataNetworkCollection GetMobileDataNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> GetMobileNetworkService(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>> GetMobileNetworkServiceAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkServiceCollection GetMobileNetworkServices() { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyCollection GetMobileNetworkSimPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> GetMobileNetworkSimPolicy(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>> GetMobileNetworkSimPolicyAsync(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> GetMobileNetworkSite(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>> GetMobileNetworkSiteAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSiteCollection GetMobileNetworkSites() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> GetMobileNetworkSlice(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>> GetMobileNetworkSliceAsync(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSliceCollection GetMobileNetworkSlices() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetSimGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetSimGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileNetworkRoutingInfoData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>
    {
        public MobileNetworkRoutingInfoData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route> ControlPlaneAccessRoutes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route> UserPlaneAccessRoutes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem> UserPlaneDataRoutes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkRoutingInfoResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkRoutingInfoResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>
    {
        public MobileNetworkServiceData(Azure.Core.AzureLocation location, int servicePrecedence, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration> pccRules) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration> PccRules { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public int ServicePrecedence { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy ServiceQosPolicy { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkServiceResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileNetworkSimCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkSimCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string simName, Azure.ResourceManager.MobileNetwork.MobileNetworkSimData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string simName, Azure.ResourceManager.MobileNetwork.MobileNetworkSimData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> Get(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>> GetAsync(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> GetIfExists(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>> GetIfExistsAsync(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkSimData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>
    {
        public MobileNetworkSimData(string internationalMobileSubscriberIdentity) { }
        public string AuthenticationKey { get { throw null; } set { } }
        public string DeviceType { get { throw null; } set { } }
        public string IntegratedCircuitCardIdentifier { get { throw null; } set { } }
        public string InternationalMobileSubscriberIdentity { get { throw null; } set { } }
        public string OperatorKeyCode { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SimPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState? SimState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState> SiteProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties> StaticIPConfiguration { get { throw null; } }
        public string VendorKeyFingerprint { get { throw null; } }
        public string VendorName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkSimGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkSimGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string simGroupName, Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string simGroupName, Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> Get(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> GetAsync(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetIfExists(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> GetIfExistsAsync(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkSimGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>
    {
        public MobileNetworkSimGroupData(Azure.Core.AzureLocation location) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MobileNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity UserAssignedIdentity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkSimGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkSimGroupResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> BulkDeleteSim(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimDeleteList simDeleteList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> BulkDeleteSimAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimDeleteList simDeleteList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> BulkUploadEncryptedSim(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList encryptedSimUploadList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> BulkUploadEncryptedSimAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList encryptedSimUploadList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> BulkUploadSim(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimUploadList simUploadList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> BulkUploadSimAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimUploadList simUploadList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> CloneSim(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimCloneContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> CloneSimAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimCloneContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string simGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> GetMobileNetworkSim(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>> GetMobileNetworkSimAsync(string simName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSimCollection GetMobileNetworkSims() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> MoveSim(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> MoveSimAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SimMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileNetworkSimPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkSimPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string simPolicyName, Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string simPolicyName, Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> Get(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>> GetAsync(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> GetIfExists(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>> GetIfExistsAsync(string simPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkSimPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>
    {
        public MobileNetworkSimPolicyData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.Ambr ueAmbr, Azure.ResourceManager.Resources.Models.WritableSubResource defaultSlice, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration> sliceConfigurations) { }
        public Azure.Core.ResourceIdentifier DefaultSliceId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public int? RegistrationTimer { get { throw null; } set { } }
        public int? RfspIndex { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState> SiteProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration> SliceConfigurations { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.MobileNetwork.Models.Ambr UeAmbr { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.Ambr UEAmbr { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkSimPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkSimPolicyResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string simPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileNetworkSimResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkSimResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSimData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string simGroupName, string simName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSimData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSimData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.MobileNetworkSimData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.MobileNetworkSimData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileNetworkSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> GetIfExists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>> GetIfExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkSiteData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>
    {
        public MobileNetworkSiteData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> NetworkFunctions { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkSiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkSiteResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeletePacketCore(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore siteDeletePacketCore, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeletePacketCoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore siteDeletePacketCore, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MobileNetworkSliceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>, System.Collections.IEnumerable
    {
        protected MobileNetworkSliceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sliceName, Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sliceName, Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> Get(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>> GetAsync(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> GetIfExists(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>> GetIfExistsAsync(string sliceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MobileNetworkSliceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>
    {
        public MobileNetworkSliceData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.Snssai snssai) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.Snssai Snssai { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkSliceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MobileNetworkSliceResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mobileNetworkName, string sliceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PacketCoreControlPlaneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>, System.Collections.IEnumerable
    {
        protected PacketCoreControlPlaneCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string packetCoreControlPlaneName, Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string packetCoreControlPlaneName, Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> Get(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> GetAsync(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetIfExists(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> GetIfExistsAsync(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PacketCoreControlPlaneData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>
    {
        public PacketCoreControlPlaneData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sites, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration platform, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties controlPlaneAccessInterface, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku sku, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration localDiagnosticsAccess) { }
        public bool? AllowSupportTelemetryAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties ControlPlaneAccessInterface { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ControlPlaneAccessVirtualIPv4Addresses { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCoreNetworkType? CoreNetworkTechnology { get { throw null; } set { } }
        public System.Uri DiagnosticsUploadStorageAccountContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration EventHub { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState? HomeNetworkPrivateKeysProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation Installation { get { throw null; } set { } }
        public string InstalledVersion { get { throw null; } }
        public System.BinaryData InteropSettings { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration LocalDiagnosticsAccess { get { throw null; } set { } }
        public int? NasRerouteMacroMmeGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration Platform { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public string RollbackVersion { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration Signaling { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Sites { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku Sku { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? UeMtu { get { throw null; } set { } }
        public int? UEMtu { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity UserAssignedIdentity { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PacketCoreControlPlaneResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PacketCoreControlPlaneResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> CollectDiagnosticsPackage(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage packetCoreControlPlaneCollectDiagnosticsPackage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> CollectDiagnosticsPackageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage packetCoreControlPlaneCollectDiagnosticsPackage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.Models.UEInfo> GetAllUeInformation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.Models.UEInfo> GetAllUeInformationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource> GetExtendedUEInfo(string ueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource>> GetExtendedUEInfoAsync(string ueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.ExtendedUEInfoCollection GetExtendedUEInfos() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource> GetMobileNetworkDiagnosticsPackage(string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource>> GetMobileNetworkDiagnosticsPackageAsync(string diagnosticsPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageCollection GetMobileNetworkDiagnosticsPackages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource> GetMobileNetworkPacketCapture(string packetCaptureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource>> GetMobileNetworkPacketCaptureAsync(string packetCaptureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureCollection GetMobileNetworkPacketCaptures() { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoResource GetMobileNetworkRoutingInfo() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> GetPacketCoreDataPlane(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> GetPacketCoreDataPlaneAsync(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneCollection GetPacketCoreDataPlanes() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> Reinstall(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> ReinstallAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus> Rollback(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>> RollbackAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PacketCoreControlPlaneVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>
    {
        public PacketCoreControlPlaneVersionData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform> Platforms { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PacketCoreDataPlaneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>, System.Collections.IEnumerable
    {
        protected PacketCoreDataPlaneCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string packetCoreDataPlaneName, Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string packetCoreDataPlaneName, Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> Get(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> GetAsync(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> GetIfExists(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> GetIfExistsAsync(string packetCoreDataPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PacketCoreDataPlaneData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>
    {
        public PacketCoreDataPlaneData(Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties userPlaneAccessInterface) { }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties UserPlaneAccessInterface { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> UserPlaneAccessVirtualIPv4Addresses { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PacketCoreDataPlaneResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PacketCoreDataPlaneResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string packetCoreControlPlaneName, string packetCoreDataPlaneName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource> GetMobileAttachedDataNetwork(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource>> GetMobileAttachedDataNetworkAsync(string attachedDataNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkCollection GetMobileAttachedDataNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource> Update(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource>> UpdateAsync(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionPacketCoreControlPlaneVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource>, System.Collections.IEnumerable
    {
        protected SubscriptionPacketCoreControlPlaneVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionPacketCoreControlPlaneVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionPacketCoreControlPlaneVersionResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string versionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantPacketCoreControlPlaneVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource>, System.Collections.IEnumerable
    {
        protected TenantPacketCoreControlPlaneVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantPacketCoreControlPlaneVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantPacketCoreControlPlaneVersionResource() { }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string versionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.MobileNetwork.Mocking
{
    public partial class MockableMobileNetworkArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMobileNetworkArmClient() { }
        public virtual Azure.ResourceManager.MobileNetwork.ExtendedUEInfoResource GetExtendedUEInfoResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkResource GetMobileAttachedDataNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileDataNetworkResource GetMobileDataNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageResource GetMobileNetworkDiagnosticsPackageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureResource GetMobileNetworkPacketCaptureResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkResource GetMobileNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoResource GetMobileNetworkRoutingInfoResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkServiceResource GetMobileNetworkServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource GetMobileNetworkSimGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyResource GetMobileNetworkSimPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSimResource GetMobileNetworkSimResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSiteResource GetMobileNetworkSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSliceResource GetMobileNetworkSliceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource GetPacketCoreControlPlaneResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneResource GetPacketCoreDataPlaneResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource GetSubscriptionPacketCoreControlPlaneVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource GetTenantPacketCoreControlPlaneVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMobileNetworkResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMobileNetworkResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetwork(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkResource>> GetMobileNetworkAsync(string mobileNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkCollection GetMobileNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetMobileNetworkSimGroup(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource>> GetMobileNetworkSimGroupAsync(string simGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupCollection GetMobileNetworkSimGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlane(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource>> GetPacketCoreControlPlaneAsync(string packetCoreControlPlaneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneCollection GetPacketCoreControlPlanes() { throw null; }
    }
    public partial class MockableMobileNetworkSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMobileNetworkSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkResource> GetMobileNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetMobileNetworkSimGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupResource> GetMobileNetworkSimGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlanes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneResource> GetPacketCoreControlPlanesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource> GetSubscriptionPacketCoreControlPlaneVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionResource>> GetSubscriptionPacketCoreControlPlaneVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.SubscriptionPacketCoreControlPlaneVersionCollection GetSubscriptionPacketCoreControlPlaneVersions() { throw null; }
    }
    public partial class MockableMobileNetworkTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMobileNetworkTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource> GetTenantPacketCoreControlPlaneVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionResource>> GetTenantPacketCoreControlPlaneVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MobileNetwork.TenantPacketCoreControlPlaneVersionCollection GetTenantPacketCoreControlPlaneVersions() { throw null; }
    }
}
namespace Azure.ResourceManager.MobileNetwork.Models
{
    public partial class Ambr : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.Ambr>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.Ambr>
    {
        public Ambr(string uplink, string downlink) { }
        public string Downlink { get { throw null; } set { } }
        public string Uplink { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.Ambr System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.Ambr>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.Ambr>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.Ambr System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.Ambr>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.Ambr>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.Ambr>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmMobileNetworkModelFactory
    {
        public static Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus AsyncOperationStatus(string id = null, string name = null, string status = null, string resourceId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?), System.BinaryData properties = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.ExtendedUEInfoData ExtendedUEInfoData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileAttachedDataNetworkData MobileAttachedDataNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties userPlaneDataInterface = null, System.Collections.Generic.IEnumerable<string> dnsAddresses = null, Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration naptConfiguration = null, System.Collections.Generic.IEnumerable<string> userEquipmentAddressPoolPrefix = null, System.Collections.Generic.IEnumerable<string> userEquipmentStaticAddressPoolPrefix = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileDataNetworkData MobileDataNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), string description = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning MobileNetworkCertificateProvisioning(Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState? state = default(Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState?), string reason = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkData MobileNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity identity = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId publicLandMobileNetworkIdentifier = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork> publicLandMobileNetworks = null, string serviceKey = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkData MobileNetworkData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId publicLandMobileNetworkIdentifier, string serviceKey) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkDiagnosticsPackageData MobileNetworkDiagnosticsPackageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus? status = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus?), string reason = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate MobileNetworkHttpsServerCertificate(System.Uri certificateUri = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning provisioning = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation MobileNetworkInstallation(Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState? desiredState = default(Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState? state = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired? reinstallRequired = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason> reasons = null, Azure.Core.ResourceIdentifier operationId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData MobileNetworkPacketCaptureData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus? status, string reason, System.DateTimeOffset? captureStartOn, System.Collections.Generic.IEnumerable<string> networkInterfaces, long? bytesToCapturePerPacket, long? totalBytesPerSession, int? timeLimitInSeconds) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkPacketCaptureData MobileNetworkPacketCaptureData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus? status = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus?), string reason = null, System.DateTimeOffset? captureStartOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> networkInterfaces = null, long? bytesToCapturePerPacket = default(long?), long? totalBytesPerSession = default(long?), int? timeLimitInSeconds = default(int?), System.Collections.Generic.IEnumerable<string> outputFiles = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration MobileNetworkPlatformConfiguration(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType platformType = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType), Azure.Core.ResourceIdentifier azureStackEdgeDeviceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> azureStackEdgeDevices = null, Azure.Core.ResourceIdentifier azureStackHciClusterId = null, Azure.Core.ResourceIdentifier connectedClusterId = null, Azure.Core.ResourceIdentifier customLocationId = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkRoutingInfoData MobileNetworkRoutingInfoData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route> controlPlaneAccessRoutes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route> userPlaneAccessRoutes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem> userPlaneDataRoutes = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkServiceData MobileNetworkServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), int servicePrecedence = 0, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy serviceQosPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration> pccRules = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSimData MobileNetworkSimData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState? simState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState> siteProvisioningState = null, string internationalMobileSubscriberIdentity = null, string integratedCircuitCardIdentifier = null, string deviceType = null, Azure.Core.ResourceIdentifier simPolicyId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties> staticIPConfiguration = null, string vendorName = null, string vendorKeyFingerprint = null, string authenticationKey = null, string operatorKeyCode = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSimGroupData MobileNetworkSimGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity userAssignedIdentity = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), System.Uri keyUri = null, Azure.Core.ResourceIdentifier mobileNetworkId = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSimPolicyData MobileNetworkSimPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState> siteProvisioningState = null, Azure.ResourceManager.MobileNetwork.Models.Ambr ueAmbr = null, Azure.Core.ResourceIdentifier defaultSliceId = null, int? rfspIndex = default(int?), int? registrationTimer = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration> sliceConfigurations = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSiteData MobileNetworkSiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> networkFunctions = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.MobileNetworkSliceData MobileNetworkSliceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.Snssai snssai = null, string description = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData PacketCoreControlPlaneData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity userAssignedIdentity, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation installation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sites, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration platform, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCoreNetworkType? coreNetworkTechnology, string version, string installedVersion, string rollbackVersion, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties controlPlaneAccessInterface, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku sku, int? ueMtu, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration localDiagnosticsAccess, System.Uri diagnosticsUploadStorageAccountContainerUri, System.BinaryData interopSettings) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData PacketCoreControlPlaneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity userAssignedIdentity = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation installation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sites = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration platform = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCoreNetworkType? coreNetworkTechnology = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCoreNetworkType?), string version = null, string installedVersion = null, string rollbackVersion = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties controlPlaneAccessInterface = null, System.Collections.Generic.IEnumerable<string> controlPlaneAccessVirtualIPv4Addresses = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku sku = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku), int? ueMtu = default(int?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration localDiagnosticsAccess = null, System.Uri diagnosticsUploadStorageAccountContainerUri = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration eventHub = null, Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration signaling = null, System.BinaryData interopSettings = null, Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState? homeNetworkPrivateKeysProvisioningState = default(Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState?), bool? allowSupportTelemetryAccess = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData PacketCoreControlPlaneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity userAssignedIdentity = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation installation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sites = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration platform = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCoreNetworkType? coreNetworkTechnology = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCoreNetworkType?), string version = null, string installedVersion = null, string rollbackVersion = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties controlPlaneAccessInterface = null, System.Collections.Generic.IEnumerable<string> controlPlaneAccessVirtualIPv4Addresses = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku sku = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku), int? ueMtu = default(int?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration localDiagnosticsAccess = null, System.Uri diagnosticsUploadStorageAccountContainerUri = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration eventHub = null, int? nasRerouteMacroMmeGroupId = default(int?), System.BinaryData interopSettings = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneData PacketCoreControlPlaneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity userAssignedIdentity = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation installation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sites = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration platform = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCoreNetworkType? coreNetworkTechnology = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCoreNetworkType?), string version = null, string installedVersion = null, string rollbackVersion = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties controlPlaneAccessInterface = null, System.Collections.Generic.IEnumerable<string> controlPlaneAccessVirtualIPv4Addresses = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku sku = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku), int? ueMtu = default(int?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration localDiagnosticsAccess = null, System.Uri diagnosticsUploadStorageAccountContainerUri = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration eventHub = null, int? nasRerouteMacroMmeGroupId = default(int?), System.BinaryData interopSettings = null, Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState? homeNetworkPrivateKeysProvisioningState = default(Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreControlPlaneVersionData PacketCoreControlPlaneVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform> platforms = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData PacketCoreDataPlaneData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties userPlaneAccessInterface) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.PacketCoreDataPlaneData PacketCoreDataPlaneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties userPlaneAccessInterface = null, System.Collections.Generic.IEnumerable<string> userPlaneAccessVirtualIPv4Addresses = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties SimNameAndEncryptedProperties(string name = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState? simState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState> siteProvisioningState = null, string internationalMobileSubscriberIdentity = null, string integratedCircuitCardIdentifier = null, string deviceType = null, Azure.Core.ResourceIdentifier simPolicyId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties> staticIPConfiguration = null, string vendorName = null, string vendorKeyFingerprint = null, string encryptedCredentials = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties SimNameAndProperties(string name = null, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState?), Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState? simState = default(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState> siteProvisioningState = null, string internationalMobileSubscriberIdentity = null, string integratedCircuitCardIdentifier = null, string deviceType = null, Azure.Core.ResourceIdentifier simPolicyId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties> staticIPConfiguration = null, string vendorName = null, string vendorKeyFingerprint = null, string authenticationKey = null, string operatorKeyCode = null) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.UEInfo UEInfo(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MobileNetwork.Models.RatType ratType = default(Azure.ResourceManager.MobileNetwork.Models.RatType), Azure.ResourceManager.MobileNetwork.Models.UEState ueState = default(Azure.ResourceManager.MobileNetwork.Models.UEState), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.DnnIPPair> ueIPAddresses = null, System.DateTimeOffset? lastReadOn = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class AsyncOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>
    {
        internal AsyncOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.AsyncOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateProvisioningState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState NotProvisioned { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState Provisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration>
    {
        public DataNetworkConfiguration(Azure.ResourceManager.Resources.Models.WritableSubResource dataNetwork, Azure.ResourceManager.MobileNetwork.Models.Ambr sessionAmbr, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> allowedServices) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType> AdditionalAllowedSessionTypes { get { throw null; } }
        public int? AllocationAndRetentionPriorityLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> AllowedServices { get { throw null; } }
        public Azure.Core.ResourceIdentifier DataNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType? DefaultSessionType { get { throw null; } set { } }
        public int? FiveQi { get { throw null; } set { } }
        public int? MaximumNumberOfBufferedPackets { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability? PreemptionCapability { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability? PreemptionVulnerability { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.Ambr SessionAmbr { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesiredInstallationState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesiredInstallationState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState Installed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState Uninstalled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState left, Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState left, Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnnIPPair : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.DnnIPPair>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.DnnIPPair>
    {
        public DnnIPPair() { }
        public string Dnn { get { throw null; } set { } }
        public string IPV4Addr { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.DnnIPPair System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.DnnIPPair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.DnnIPPair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.DnnIPPair System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.DnnIPPair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.DnnIPPair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.DnnIPPair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptedSimUploadList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList>
    {
        public EncryptedSimUploadList(int version, int azureKeyIdentifier, string vendorKeyFingerprint, string encryptedTransportKey, string signedTransportKey, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties> sims) { }
        public int AzureKeyIdentifier { get { throw null; } }
        public string EncryptedTransportKey { get { throw null; } }
        public string SignedTransportKey { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties> Sims { get { throw null; } }
        public string VendorKeyFingerprint { get { throw null; } }
        public int Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.EncryptedSimUploadList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ExtendedUEInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties>
    {
        protected ExtendedUEInfoProperties() { }
        public System.DateTimeOffset? LastReadOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HomeNetworkPrivateKeysProvisioningState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HomeNetworkPrivateKeysProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState NotProvisioned { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState Provisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPrivateKeysProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HomeNetworkPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey>
    {
        public HomeNetworkPublicKey(int id) { }
        public int Id { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkAuthenticationType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType Aad { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType Password { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkBillingSku : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkBillingSku(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku G0 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku G1 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku G10 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku G2 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku G5 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkBillingSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobileNetworkCertificateProvisioning : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning>
    {
        internal MobileNetworkCertificateProvisioning() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.CertificateProvisioningState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MobileNetworkCoreNetworkType
    {
        FiveGC = 0,
        Epc = 1,
        Epc5GC = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkDiagnosticsPackageStatus : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkDiagnosticsPackageStatus(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus Collected { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus Collecting { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus Error { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus NotStarted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkDiagnosticsPackageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobileNetworkEventHubConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration>
    {
        public MobileNetworkEventHubConfiguration(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public int? ReportingInterval { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkEventHubConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkHttpsServerCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate>
    {
        public MobileNetworkHttpsServerCertificate(System.Uri certificateUri) { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkCertificateProvisioning Provisioning { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkInstallation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation>
    {
        public MobileNetworkInstallation() { }
        public Azure.ResourceManager.MobileNetwork.Models.DesiredInstallationState? DesiredState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OperationId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason> Reasons { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired? ReinstallRequired { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkInstallationReason : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkInstallationReason(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason ControlPlaneAccessInterfaceHasChanged { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason ControlPlaneAccessVirtualIPv4AddressesHasChanged { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason NoAttachedDataNetworks { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason NoPacketCoreDataPlane { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason NoSlices { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason PublicLandMobileNetworkIdentifierHasChanged { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason UserPlaneAccessInterfaceHasChanged { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason UserPlaneAccessVirtualIPv4AddressesHasChanged { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason UserPlaneDataInterfaceHasChanged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkInstallationState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkInstallationState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState Failed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState Installed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState Installing { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState Reinstalling { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState RollingBack { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState Uninstalled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState Uninstalling { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState Updating { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInstallationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobileNetworkInterfaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties>
    {
        public MobileNetworkInterfaceProperties() { }
        public System.Collections.Generic.IList<string> BfdIPv4Endpoints { get { throw null; } }
        public string IPv4Address { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPv4AddressList { get { throw null; } }
        public string IPv4Gateway { get { throw null; } set { } }
        public string IPv4Subnet { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkInterfaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkIPv4Route : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route>
    {
        public MobileNetworkIPv4Route() { }
        public string Destination { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop> NextHops { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkIPv4RouteNextHop : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop>
    {
        public MobileNetworkIPv4RouteNextHop() { }
        public string Address { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4RouteNextHop>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkLocalDiagnosticsAccessConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration>
    {
        public MobileNetworkLocalDiagnosticsAccessConfiguration(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType authenticationType) { }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkAuthenticationType AuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkHttpsServerCertificate HttpsServerCertificate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkLocalDiagnosticsAccessConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkManagedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity>
    {
        public MobileNetworkManagedServiceIdentity(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType identityType) { }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType IdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkNasEncryptionType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkNasEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType NEA0EEA0 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType NEA1EEA1 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType NEA2EEA2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkObsoleteVersion : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkObsoleteVersion(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion NotObsolete { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion Obsolete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkPacketCaptureStatus : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkPacketCaptureStatus(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus Error { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus Running { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPacketCaptureStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkPduSessionType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkPduSessionType(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPduSessionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobileNetworkPlatform : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform>
    {
        public MobileNetworkPlatform() { }
        public System.Collections.Generic.IList<string> HaUpgradesAvailable { get { throw null; } }
        public string MaximumPlatformSoftwareVersion { get { throw null; } set { } }
        public string MinimumPlatformSoftwareVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkObsoleteVersion? ObsoleteVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType? PlatformType { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion? RecommendedVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState? VersionState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkPlatformConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration>
    {
        public MobileNetworkPlatformConfiguration(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType platformType) { }
        public Azure.Core.ResourceIdentifier AzureStackEdgeDeviceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> AzureStackEdgeDevices { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzureStackHciClusterId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ConnectedClusterId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomLocationId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType PlatformType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkPlatformType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkPlatformType(string value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType AKSHCI { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType AksHci { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType ThreePAzureStackHCI { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType ThreePAzureStackHci { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobileNetworkPlmnId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId>
    {
        public MobileNetworkPlmnId(string mcc, string mnc) { }
        public string Mcc { get { throw null; } set { } }
        public string Mnc { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkPortRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange>
    {
        public MobileNetworkPortRange() { }
        public int? MaxPort { get { throw null; } set { } }
        public int? MinPort { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkPortReuseHoldTimes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes>
    {
        public MobileNetworkPortReuseHoldTimes() { }
        public int? Tcp { get { throw null; } set { } }
        public int? Udp { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkPreemptionCapability : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkPreemptionCapability(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability MayPreempt { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability NotPreempt { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkPreemptionVulnerability : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkPreemptionVulnerability(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability NotPreemptable { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability Preemptable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkProvisioningState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobileNetworkQosPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy>
    {
        public MobileNetworkQosPolicy(Azure.ResourceManager.MobileNetwork.Models.Ambr maximumBitRate) { }
        public int? AllocationAndRetentionPriorityLevel { get { throw null; } set { } }
        public int? FiveQi { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.Ambr MaximumBitRate { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionCapability? PreemptionCapability { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPreemptionVulnerability? PreemptionVulnerability { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkRecommendedVersion : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkRecommendedVersion(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion NotRecommended { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion Recommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkRecommendedVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkReinstallRequired : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkReinstallRequired(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired NotRequired { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkReinstallRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobileNetworkResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch>
    {
        public MobileNetworkResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkManagedServiceIdentity UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkSdfDirectionS : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkSdfDirectionS(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS Bidirectional { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS Downlink { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS Uplink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobileNetworkServiceDataFlowTemplate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate>
    {
        public MobileNetworkServiceDataFlowTemplate(string templateName, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS direction, System.Collections.Generic.IEnumerable<string> protocol, System.Collections.Generic.IEnumerable<string> remoteIPList) { }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSdfDirectionS Direction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ports { get { throw null; } }
        public System.Collections.Generic.IList<string> Protocol { get { throw null; } }
        public System.Collections.Generic.IList<string> RemoteIPList { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkSimState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkSimState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState Enabled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkSiteProvisioningState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkSiteProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState Adding { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MobileNetworkSliceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration>
    {
        public MobileNetworkSliceConfiguration(Azure.ResourceManager.Resources.Models.WritableSubResource slice, Azure.ResourceManager.Resources.Models.WritableSubResource defaultDataNetwork, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration> dataNetworkConfigurations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.DataNetworkConfiguration> DataNetworkConfigurations { get { throw null; } }
        public Azure.Core.ResourceIdentifier DefaultDataNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SliceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSliceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MobileNetworkTagsPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch>
    {
        public MobileNetworkTagsPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTagsPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkTrafficControlPermission : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkTrafficControlPermission(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission Blocked { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MobileNetworkVersionState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MobileNetworkVersionState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState Active { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState Deprecated { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState Preview { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState Validating { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState ValidationFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState left, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkVersionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NaptConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration>
    {
        public NaptConfiguration() { }
        public Azure.ResourceManager.MobileNetwork.Models.NaptState? Enabled { get { throw null; } set { } }
        public int? PinholeLimits { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts PinholeTimeouts { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortRange PortRange { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPortReuseHoldTimes PortReuseHoldTime { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.NaptConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NaptState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.NaptState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NaptState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.NaptState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.NaptState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.NaptState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.NaptState left, Azure.ResourceManager.MobileNetwork.Models.NaptState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.NaptState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.NaptState left, Azure.ResourceManager.MobileNetwork.Models.NaptState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PacketCoreControlPlaneCollectDiagnosticsPackage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage>
    {
        public PacketCoreControlPlaneCollectDiagnosticsPackage(System.Uri storageAccountBlobUri) { }
        public System.Uri StorageAccountBlobUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreControlPlaneCollectDiagnosticsPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PacketCoreSignalingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration>
    {
        public PacketCoreSignalingConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkNasEncryptionType> NasEncryption { get { throw null; } }
        public int? NasRerouteMacroMmeGroupId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PacketCoreSignalingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PccRuleConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration>
    {
        public PccRuleConfiguration(string ruleName, int rulePrecedence, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate> serviceDataFlowTemplates) { }
        public string RuleName { get { throw null; } set { } }
        public int RulePrecedence { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy RuleQosPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkServiceDataFlowTemplate> ServiceDataFlowTemplates { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkTrafficControlPermission? TrafficControl { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PccRuleQosPolicy : Azure.ResourceManager.MobileNetwork.Models.MobileNetworkQosPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy>
    {
        public PccRuleQosPolicy(Azure.ResourceManager.MobileNetwork.Models.Ambr maximumBitRate) : base (default(Azure.ResourceManager.MobileNetwork.Models.Ambr)) { }
        public Azure.ResourceManager.MobileNetwork.Models.Ambr GuaranteedBitRate { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PccRuleQosPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PdnType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.PdnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PdnType(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.PdnType IPV4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.PdnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.PdnType left, Azure.ResourceManager.MobileNetwork.Models.PdnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.PdnType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.PdnType left, Azure.ResourceManager.MobileNetwork.Models.PdnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PinholeTimeouts : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts>
    {
        public PinholeTimeouts() { }
        public int? Icmp { get { throw null; } set { } }
        public int? Tcp { get { throw null; } set { } }
        public int? Udp { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PinholeTimeouts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicLandMobileNetwork : Azure.ResourceManager.MobileNetwork.Models.MobileNetworkPlmnId, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork>
    {
        public PublicLandMobileNetwork(string mcc, string mnc) : base (default(string), default(string)) { }
        public Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys HomeNetworkPublicKeys { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicLandMobileNetworkHomeNetworkPublicKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys>
    {
        public PublicLandMobileNetworkHomeNetworkPublicKeys() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey> ProfileA { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.HomeNetworkPublicKey> ProfileB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.PublicLandMobileNetworkHomeNetworkPublicKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RatType : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.RatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RatType(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.RatType FiveG { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.RatType FourG { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.RatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.RatType left, Azure.ResourceManager.MobileNetwork.Models.RatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.RatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.RatType left, Azure.ResourceManager.MobileNetwork.Models.RatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RrcEstablishmentCause : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RrcEstablishmentCause(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause Emergency { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause MobileOriginatedData { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause MobileOriginatedSignaling { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause MobileTerminatedData { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause MobileTerminatedSignaling { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause Sms { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause left, Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause left, Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SimCloneContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimCloneContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimCloneContent>
    {
        public SimCloneContent() { }
        public System.Collections.Generic.IList<string> Sims { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetSimGroupIdId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimCloneContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimCloneContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimCloneContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimCloneContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimCloneContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimCloneContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimCloneContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimDeleteList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimDeleteList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimDeleteList>
    {
        public SimDeleteList(System.Collections.Generic.IEnumerable<string> sims) { }
        public System.Collections.Generic.IList<string> Sims { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimDeleteList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimDeleteList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimDeleteList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimDeleteList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimDeleteList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimDeleteList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimDeleteList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimMoveContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimMoveContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimMoveContent>
    {
        public SimMoveContent() { }
        public System.Collections.Generic.IList<string> Sims { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetSimGroupIdId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimMoveContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimMoveContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimMoveContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimMoveContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimMoveContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimMoveContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimMoveContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimNameAndEncryptedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties>
    {
        public SimNameAndEncryptedProperties(string name, string internationalMobileSubscriberIdentity) { }
        public string DeviceType { get { throw null; } set { } }
        public string EncryptedCredentials { get { throw null; } set { } }
        public string IntegratedCircuitCardIdentifier { get { throw null; } set { } }
        public string InternationalMobileSubscriberIdentity { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SimPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState? SimState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState> SiteProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties> StaticIPConfiguration { get { throw null; } }
        public string VendorKeyFingerprint { get { throw null; } }
        public string VendorName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndEncryptedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimNameAndProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties>
    {
        public SimNameAndProperties(string name, string internationalMobileSubscriberIdentity) { }
        public string AuthenticationKey { get { throw null; } set { } }
        public string DeviceType { get { throw null; } set { } }
        public string IntegratedCircuitCardIdentifier { get { throw null; } set { } }
        public string InternationalMobileSubscriberIdentity { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperatorKeyCode { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SimPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSimState? SimState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.MobileNetwork.Models.MobileNetworkSiteProvisioningState> SiteProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties> StaticIPConfiguration { get { throw null; } }
        public string VendorKeyFingerprint { get { throw null; } }
        public string VendorName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimStaticIPProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties>
    {
        public SimStaticIPProperties() { }
        public Azure.Core.ResourceIdentifier AttachedDataNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SliceId { get { throw null; } set { } }
        public string StaticIPIPv4Address { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimStaticIPProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimUploadList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimUploadList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimUploadList>
    {
        public SimUploadList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties> sims) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.SimNameAndProperties> Sims { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimUploadList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimUploadList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SimUploadList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SimUploadList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimUploadList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimUploadList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SimUploadList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteDeletePacketCore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore>
    {
        public SiteDeletePacketCore() { }
        public Azure.Core.ResourceIdentifier PacketCoreId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.SiteDeletePacketCore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Snssai : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.Snssai>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.Snssai>
    {
        public Snssai(int sst) { }
        public string Sd { get { throw null; } set { } }
        public int Sst { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.Snssai System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.Snssai>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.Snssai>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.Snssai System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.Snssai>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.Snssai>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.Snssai>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UEInfo : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo>
    {
        public UEInfo(Azure.ResourceManager.MobileNetwork.Models.RatType ratType, Azure.ResourceManager.MobileNetwork.Models.UEState ueState) { }
        public System.DateTimeOffset? LastReadOn { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.RatType RatType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.DnnIPPair> UEIPAddresses { get { throw null; } }
        public Azure.ResourceManager.MobileNetwork.Models.UEState UEState { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UEInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UEInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UEInfo4G : Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo4G>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo4G>
    {
        public UEInfo4G(string imsi, int mTmsi, int groupId, int code, string mccInfoGutiPlmnMcc, string mncInfoGutiPlmnMnc) { }
        public int? BitLength { get { throw null; } set { } }
        public int Code { get { throw null; } set { } }
        public string ENbId { get { throw null; } set { } }
        public int? EnbS1ApId { get { throw null; } set { } }
        public string GNBValue { get { throw null; } set { } }
        public int GroupId { get { throw null; } set { } }
        public string Imei { get { throw null; } set { } }
        public string Imeisv { get { throw null; } set { } }
        public string Imsi { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivityOn { get { throw null; } set { } }
        public string LastVisitedTai { get { throw null; } set { } }
        public string LocationType { get { throw null; } set { } }
        public string MccInfoConnectionInfoGlobalRanNodeIdPlmnIdMcc { get { throw null; } set { } }
        public string MccInfoConnectionInfoLocationInfoPlmnMcc { get { throw null; } set { } }
        public string MccInfoGutiPlmnMcc { get { throw null; } set { } }
        public int? MmeS1ApId { get { throw null; } set { } }
        public string MncInfoConnectionInfoGlobalRanNodeIdPlmnIdMnc { get { throw null; } set { } }
        public string MncInfoConnectionInfoLocationInfoPlmnMnc { get { throw null; } set { } }
        public string MncInfoGutiPlmnMnc { get { throw null; } set { } }
        public int MTmsi { get { throw null; } set { } }
        public string N3IwfId { get { throw null; } set { } }
        public string NgeNbId { get { throw null; } set { } }
        public string Nid { get { throw null; } set { } }
        public string PerUETnla { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause? RrcEstablishmentCause { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G> SessionInfo { get { throw null; } }
        public string Tac { get { throw null; } set { } }
        public string TngfId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.UEState? UEState { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting? UEUsageSetting { get { throw null; } set { } }
        public string WagfId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UEInfo4G System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo4G>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo4G>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UEInfo4G System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo4G>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo4G>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo4G>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UEInfo5G : Azure.ResourceManager.MobileNetwork.Models.ExtendedUEInfoProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo5G>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo5G>
    {
        public UEInfo5G(string supi, int fivegTmsi, int regionId, int setId, int pointer, string mccInfoFivegGutiPlmnMcc, string mncInfoFivegGutiPlmnMnc) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.Snssai> AllowedNssai { get { throw null; } }
        public long? AmfUENgapId { get { throw null; } set { } }
        public int? BitLength { get { throw null; } set { } }
        public string ENbId { get { throw null; } set { } }
        public int FivegTmsi { get { throw null; } set { } }
        public string GNBValue { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivityOn { get { throw null; } set { } }
        public string LastVisitedTai { get { throw null; } set { } }
        public string LocationType { get { throw null; } set { } }
        public string MccInfoConnectionInfoGlobalRanNodeIdPlmnIdMcc { get { throw null; } set { } }
        public string MccInfoConnectionInfoLocationInfoPlmnMcc { get { throw null; } set { } }
        public string MccInfoFivegGutiPlmnMcc { get { throw null; } set { } }
        public string MncInfoConnectionInfoGlobalRanNodeIdPlmnIdMnc { get { throw null; } set { } }
        public string MncInfoConnectionInfoLocationInfoPlmnMnc { get { throw null; } set { } }
        public string MncInfoFivegGutiPlmnMnc { get { throw null; } set { } }
        public string N3IwfId { get { throw null; } set { } }
        public string NgeNbId { get { throw null; } set { } }
        public string Nid { get { throw null; } set { } }
        public string Pei { get { throw null; } set { } }
        public string PerUETnla { get { throw null; } set { } }
        public int Pointer { get { throw null; } set { } }
        public int? RanUENgapId { get { throw null; } set { } }
        public int RegionId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.RrcEstablishmentCause? RrcEstablishmentCause { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G> SessionInfo { get { throw null; } }
        public int SetId { get { throw null; } set { } }
        public string Supi { get { throw null; } set { } }
        public string Tac { get { throw null; } set { } }
        public string TngfId { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.UEState? UEState { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting? UEUsageSetting { get { throw null; } set { } }
        public string WagfId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UEInfo5G System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo5G>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo5G>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UEInfo5G System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo5G>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo5G>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEInfo5G>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UEQosFlow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEQosFlow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEQosFlow>
    {
        public UEQosFlow(int qfi, int fiveqi) { }
        public string DownlinkGbrDownlink { get { throw null; } set { } }
        public string DownlinkMbrDownlink { get { throw null; } set { } }
        public int Fiveqi { get { throw null; } set { } }
        public int Qfi { get { throw null; } set { } }
        public string UplinkGbrUplink { get { throw null; } set { } }
        public string UplinkMbrUplink { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UEQosFlow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEQosFlow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UEQosFlow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UEQosFlow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEQosFlow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEQosFlow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UEQosFlow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UESessionInfo4G : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G>
    {
        public UESessionInfo4G(int ebi, string apn, Azure.ResourceManager.MobileNetwork.Models.PdnType pdnType) { }
        public string Apn { get { throw null; } set { } }
        public int Ebi { get { throw null; } set { } }
        public string IPV4Addr { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PdnType PdnType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo4G>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UESessionInfo5G : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G>
    {
        public UESessionInfo5G(int pduSessionId, string dnn, Azure.ResourceManager.MobileNetwork.Models.PdnType pdnType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MobileNetwork.Models.UEQosFlow> qosFlow, string uplink, string downlink, int sst) { }
        public string Dnn { get { throw null; } set { } }
        public string Downlink { get { throw null; } set { } }
        public string IPV4Addr { get { throw null; } set { } }
        public Azure.ResourceManager.MobileNetwork.Models.PdnType PdnType { get { throw null; } set { } }
        public int PduSessionId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.UEQosFlow> QosFlow { get { throw null; } }
        public string Sd { get { throw null; } set { } }
        public int Sst { get { throw null; } set { } }
        public string Uplink { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UESessionInfo5G>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UEState : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.UEState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UEState(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.UEState Connected { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.UEState Deregistered { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.UEState Detached { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.UEState Idle { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.UEState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.UEState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.UEState left, Azure.ResourceManager.MobileNetwork.Models.UEState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.UEState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.UEState left, Azure.ResourceManager.MobileNetwork.Models.UEState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UEUsageSetting : System.IEquatable<Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UEUsageSetting(string value) { throw null; }
        public static Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting DataCentric { get { throw null; } }
        public static Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting VoiceCentric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting left, Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting left, Azure.ResourceManager.MobileNetwork.Models.UEUsageSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserPlaneDataRoutesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem>
    {
        public UserPlaneDataRoutesItem() { }
        public Azure.Core.ResourceIdentifier AttachedDataNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MobileNetwork.Models.MobileNetworkIPv4Route> Routes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MobileNetwork.Models.UserPlaneDataRoutesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
