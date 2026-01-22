namespace Azure.ResourceManager.EdgeOrder
{
    public partial class AzureResourceManagerEdgeOrderContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerEdgeOrderContext() { }
        public static Azure.ResourceManager.EdgeOrder.AzureResourceManagerEdgeOrderContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EdgeOrderAddressCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>, System.Collections.IEnumerable
    {
        protected EdgeOrderAddressCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string addressName, Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string addressName, Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> Get(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetAll(string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetAll(string filter, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetAllAsync(string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetAllAsync(string filter, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> GetAsync(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetIfExists(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> GetIfExistsAsync(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeOrderAddressData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>
    {
        public EdgeOrderAddressData(Azure.Core.AzureLocation location) { }
        public EdgeOrderAddressData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification? AddressClassification { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? AddressValidationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress ShippingAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderAddressResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeOrderAddressResource() { }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string addressName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch patch, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch patch, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderCollection : Azure.ResourceManager.ArmCollection
    {
        protected EdgeOrderCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> Get(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderResource>> GetAsync(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetIfExists(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>
    {
        public EdgeOrderData() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails CurrentStage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> OrderItemIds { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode? OrderMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> OrderStageHistory { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.EdgeOrderData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.EdgeOrderData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class EdgeOrderExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrder(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddress(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> GetEdgeOrderAddressAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderAddressCollection GetEdgeOrderAddresses(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddresses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddresses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddressesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddressesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource GetEdgeOrderAddressResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderResource>> GetEdgeOrderAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItem(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> GetEdgeOrderItemAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource GetEdgeOrderItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderItemCollection GetEdgeOrderItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItems(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItems(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, string expand, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItemsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItemsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, string expand, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderResource GetEdgeOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderCollection GetEdgeOrders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> GetProductFamilies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent content, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> GetProductFamiliesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent content, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata> GetProductFamiliesMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata> GetProductFamiliesMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>, System.Collections.IEnumerable
    {
        protected EdgeOrderItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string orderItemName, Azure.ResourceManager.EdgeOrder.EdgeOrderItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string orderItemName, Azure.ResourceManager.EdgeOrder.EdgeOrderItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> Get(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetAll(string filter = null, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetAll(string filter, string expand, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetAllAsync(string filter = null, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetAllAsync(string filter, string expand, string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> GetAsync(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetIfExists(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> GetIfExistsAsync(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeOrderItemData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>
    {
        public EdgeOrderItemData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails orderItemDetails, Azure.Core.ResourceIdentifier orderId) { }
        public EdgeOrderItemData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails orderItemDetails, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails addressDetails, Azure.Core.ResourceIdentifier orderId) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails AddressDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OrderId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails OrderItemDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.EdgeOrderItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.EdgeOrderItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderItemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeOrderItemResource() { }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string orderItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Return(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReturnAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeOrder.EdgeOrderItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.EdgeOrderItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch patch, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch patch, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeOrderResource() { }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string orderName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeOrder.EdgeOrderData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.EdgeOrderData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeOrder.Mocking
{
    public partial class MockableEdgeOrderArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeOrderArmClient() { }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource GetEdgeOrderAddressResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource GetEdgeOrderItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderResource GetEdgeOrderResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEdgeOrderResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeOrderResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrder(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddress(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> GetEdgeOrderAddressAsync(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderAddressCollection GetEdgeOrderAddresses() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderResource>> GetEdgeOrderAsync(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItem(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> GetEdgeOrderItemAsync(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderItemCollection GetEdgeOrderItems() { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderCollection GetEdgeOrders() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class MockableEdgeOrderSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeOrderSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurations(Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurationsAsync(Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddresses(string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddresses(string filter, string skipToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddressesAsync(string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddressesAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItems(string filter = null, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItems(string filter, string expand, string skipToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItemsAsync(string filter = null, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItemsAsync(string filter, string expand, string skipToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(string skipToken, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> GetProductFamilies(Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent content, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> GetProductFamiliesAsync(Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent content, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata> GetProductFamiliesMetadata(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata> GetProductFamiliesMetadataAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeOrder.Models
{
    public static partial class ArmEdgeOrderModelFactory
    {
        public static Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters ConfigurationFilters(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperty) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters ConfigurationFilters(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperty = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter childConfigurationFilter = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures> registeredFeatures = null, string locationPlacementId = null, string quotaId = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails DevicePresenceVerificationDetails(Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus? status = default(Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus?), string message = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration EdgeOrderAdditionalConfiguration(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, int quantity = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails> provisioningDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails EdgeOrderAddressContactDetails(string contactName = null, string phone = null, string phoneExtension = null, string mobile = null, System.Collections.Generic.IEnumerable<string> emailList = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData EdgeOrderAddressData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress shippingAddress, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? addressValidationStatus) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData EdgeOrderAddressData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification? addressClassification = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress shippingAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? addressValidationStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch EdgeOrderAddressPatch(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress shippingAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation EdgeOrderCategoryInformation(string categoryName = null, string categoryDisplayName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLink> links = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration EdgeOrderChildConfiguration(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType? childConfigurationType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType?), bool? isPartOfBaseConfiguration = default(bool?), int? minimumQuantity = default(int?), int? maximumQuantity = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> specifications = null, Azure.ResourceManager.EdgeOrder.Models.ProductDimensions dimensions = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport? provisioningSupport = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType> childConfigurationTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations> groupedChildConfigurations = null, System.Collections.Generic.IEnumerable<System.TimeSpan> supportedTermCommitmentDurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter EdgeOrderChildConfigurationFilter(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation> hierarchyInformations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType> childConfigurationTypes = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails EdgeOrderConfigurationDeviceDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo displayInfo = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, int? quantity = default(int?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType? identificationType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails> deviceDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation termCommitmentInformation = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderData EdgeOrderData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> orderItemIds, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails currentStage, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> orderStageHistory) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderData EdgeOrderData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> orderItemIds = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails currentStage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> orderStageHistory = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode? orderMode = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations EdgeOrderGroupedChildConfigurations(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation categoryInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration> childConfigurations = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails EdgeOrderItemAddressDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties forwardAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties returnAddress = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties EdgeOrderItemAddressProperties(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress shippingAddress, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? addressValidationStatus) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties EdgeOrderItemAddressProperties(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification? addressClassification = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress shippingAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? addressValidationStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason EdgeOrderItemCancellationReason(string reason = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderItemData EdgeOrderItemData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails orderItemDetails, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails addressDetails, System.DateTimeOffset? startOn, Azure.Core.ResourceIdentifier orderId) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderItemData EdgeOrderItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails orderItemDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails addressDetails = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier orderId = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails EdgeOrderItemDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDetails productDetails, Azure.ResourceManager.EdgeOrder.Models.OrderItemType orderItemType, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails currentStage, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> orderItemStageHistory, Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences preferences, Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails forwardShippingDetails, Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails reverseShippingDetails, System.Collections.Generic.IEnumerable<string> notificationEmailList, string cancellationReason, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus? cancellationStatus, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus? deletionStatus, string returnReason, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus? returnStatus, string firstOrDefaultManagementResourceProviderNamespace, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> managementRPDetailsList, Azure.ResponseError error) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails EdgeOrderItemDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDetails productDetails = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemType orderItemType = default(Azure.ResourceManager.EdgeOrder.Models.OrderItemType), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode? orderItemMode = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode?), System.Guid? siteId = default(System.Guid?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails currentStage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> orderItemStageHistory = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences preferences = null, Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails forwardShippingDetails = null, Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails reverseShippingDetails = null, System.Collections.Generic.IEnumerable<string> notificationEmailList = null, string cancellationReason = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus? cancellationStatus = default(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus? deletionStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus?), string returnReason = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus? returnStatus = default(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> managementRPDetailsList = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch EdgeOrderItemPatch(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties forwardAddress = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences preferences = null, System.Collections.Generic.IEnumerable<string> notificationEmailList = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch orderItemDetails = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent EdgeOrderItemReturnContent(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties returnAddress = null, string returnReason = null, string serviceTag = null, bool? isShippingBoxRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct EdgeOrderProduct(string displayName, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> configurations) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct EdgeOrderProduct(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> configurations = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails EdgeOrderProductBillingMeterDetails(string name, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails meterDetails, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType? meteringType, string frequency) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails EdgeOrderProductBillingMeterDetails(string name = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails meterDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType? meteringType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType?), string frequency = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails termTypeDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation EdgeOrderProductCostInformation(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails> billingMeterDetails = null, System.Uri billingInfoUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails EdgeOrderProductDeviceDetails(string serialNumber, string managementResourceId, string managementResourceTenantId) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails EdgeOrderProductDeviceDetails(string serialNumber = null, string displaySerialNumber = null, string managementResourceId = null, string managementResourceTenantId = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport? provisioningSupport = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails provisioningDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation EdgeOrderProductImageInformation(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType? imageType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType?), System.Uri imageUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails EdgeOrderProductMeterDetails(string billingType = null, double? multiplier = default(double?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? chargingType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails EdgeOrderProvisioningDetails(int? quantity = default(int?), Azure.Core.ResourceIdentifier provisioningArmId = null, string provisioningEndPoint = null, string serialNumber = null, string vendorName = null, Azure.Core.ResourceIdentifier readyToConnectArmId = null, Azure.Core.ResourceIdentifier managementResourceArmId = null, System.Guid? uniqueDeviceIdentifier = default(System.Guid?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus? autoProvisioningStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus?), Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails devicePresenceVerification = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity EdgeOrderResourceIdentity(string type = null, string principalId = null, string tenantId = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails EdgeOrderStageDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus? stageStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName? stageName = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName?), string displayName = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation EdgeOrderTermCommitmentInformation(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType termCommitmentType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType), System.TimeSpan? termCommitmentTypeDuration = default(System.TimeSpan?), int? pendingDaysForTerm = default(int?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails EdgeOrderTermTypeDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType termType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType), System.TimeSpan termTypeDuration = default(System.TimeSpan)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.FilterableProperty FilterableProperty(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType supportedFilterType = default(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType), System.Collections.Generic.IEnumerable<string> supportedValues = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails ForwardShippingDetails(string carrierName = null, string carrierDisplayName = null, string trackingId = null, System.Uri trackingUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences OrderItemPreferences(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference> notificationPreferences = null, Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType? transportPreferencesPreferredShipmentType = default(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType?), Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? doubleEncryptionStatus = default(Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus?), string preferredManagementResourceId = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences termCommitmentPreferences = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails Pav2MeterDetails(double? multiplier = default(double?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? chargingType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType?), System.Guid? meterGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation ProductAvailabilityInformation(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage? availabilityStage = default(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage?), Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason? disabledReason = default(Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason?), string disabledReasonMessage = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration ProductConfiguration(string displayName, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> specifications, Azure.ResourceManager.EdgeOrder.Models.ProductDimensions dimensions) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration ProductConfiguration(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> specifications = null, Azure.ResourceManager.EdgeOrder.Models.ProductDimensions dimensions = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport? provisioningSupport = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType> childConfigurationTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations> groupedChildConfigurations = null, System.Collections.Generic.IEnumerable<System.TimeSpan> supportedTermCommitmentDurations = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDescription ProductDescription(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType? descriptionType = default(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType?), string shortDescription = null, string longDescription = null, System.Collections.Generic.IEnumerable<string> keywords = null, System.Collections.Generic.IEnumerable<string> attributes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLink> links = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDetails ProductDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo displayInfo = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? productDoubleEncryptionStatus = default(Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType? identificationType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails parentDeviceDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails parentProvisioningDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration> optInAdditionalConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails> childConfigurationDeviceDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation termCommitmentInformation = null, int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDetails ProductDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo displayInfo, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation, int? count, Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? productDoubleEncryptionStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails> deviceDetails) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDimensions ProductDimensions(double? length = default(double?), double? height = default(double?), double? width = default(double?), Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit? lengthHeightUnit = default(Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit?), double? weight = default(double?), double? depth = default(double?), Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit? weightUnit = default(Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo ProductDisplayInfo(string productFamilyDisplayName = null, string configurationDisplayName = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent ProductFamiliesContent(System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>> filterableProperties = null, Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails customerSubscriptionDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata ProductFamiliesMetadata(string displayName, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLine> productLines, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> resourceProviderDetails) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata ProductFamiliesMetadata(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLine> productLines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> resourceProviderDetailsList = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductFamily ProductFamily(string displayName, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLine> productLines, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> resourceProviderDetails) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductFamily ProductFamily(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLine> productLines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> resourceProviderDetailsList = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLine ProductLine(string displayName, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct> products) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLine ProductLine(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct> products = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLink ProductLink(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType? linkType = default(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType?), System.Uri linkUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductSpecification ProductSpecification(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails PurchaseMeterDetails(double? multiplier = default(double?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? chargingType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType?), string productId = null, string skuId = null, string termId = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails ResourceProviderDetails(string resourceProviderNamespace = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails ReverseShippingDetails(string sasKeyForLabel = null, string carrierName = null, string carrierDisplayName = null, string trackingId = null, System.Uri trackingUri = null) { throw null; }
    }
    public partial class ConfigurationFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>
    {
        public ConfigurationFilters(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter ChildConfigurationFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperty { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigurationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent>
    {
        public ConfigurationsContent() { }
        public ConfigurationsContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters> configurationFilters) { }
        public Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters ConfigurationFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters> ConfigurationFilters { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomerSubscriptionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails>
    {
        public CustomerSubscriptionDetails(string quotaId) { }
        public string LocationPlacementId { get { throw null; } set { } }
        public string QuotaId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures> RegisteredFeatures { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomerSubscriptionRegisteredFeatures : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>
    {
        public CustomerSubscriptionRegisteredFeatures() { }
        public string Name { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevicePresenceVerificationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails>
    {
        public DevicePresenceVerificationDetails() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevicePresenceVerificationStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevicePresenceVerificationStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus NotInitiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus left, Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus left, Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DoubleEncryptionStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DoubleEncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus left, Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus left, Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderActionStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderActionStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus Allowed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus NotAllowed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderAdditionalConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration>
    {
        public EdgeOrderAdditionalConfiguration(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation, int quantity) { }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails> ProvisioningDetails { get { throw null; } }
        public int Quantity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderAddressClassification : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderAddressClassification(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification Shipping { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification Site { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderAddressContactDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails>
    {
        public EdgeOrderAddressContactDetails() { }
        public EdgeOrderAddressContactDetails(string contactName, string phone, System.Collections.Generic.IEnumerable<string> emailList) { }
        public string ContactName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailList { get { throw null; } }
        public string Mobile { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public string PhoneExtension { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderAddressPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch>
    {
        public EdgeOrderAddressPatch() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress ShippingAddress { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderAddressType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderAddressType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType Commercial { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType None { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType Residential { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderAddressValidationStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderAddressValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus Ambiguous { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderAutoProvisioningStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderAutoProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderCategoryInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation>
    {
        internal EdgeOrderCategoryInformation() { }
        public string CategoryDisplayName { get { throw null; } }
        public string CategoryName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.ProductLink> Links { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderChildConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration>
    {
        internal EdgeOrderChildConfiguration() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType? ChildConfigurationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType> ChildConfigurationTypes { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDimensions Dimensions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? FulfilledBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations> GroupedChildConfigurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public bool? IsPartOfBaseConfiguration { get { throw null; } }
        public int? MaximumQuantity { get { throw null; } }
        public int? MinimumQuantity { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport? ProvisioningSupport { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> Specifications { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.TimeSpan> SupportedTermCommitmentDurations { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderChildConfigurationFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter>
    {
        public EdgeOrderChildConfigurationFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType> ChildConfigurationTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation> HierarchyInformations { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderChildConfigurationType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderChildConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType AdditionalConfiguration { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType DeviceConfiguration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderConfigurationDeviceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails>
    {
        internal EdgeOrderConfigurationDeviceDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails> DeviceDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo DisplayInfo { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType? IdentificationType { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation TermCommitmentInformation { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderFulfillmentType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderFulfillmentType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType External { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType Microsoft { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderGroupedChildConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations>
    {
        internal EdgeOrderGroupedChildConfigurations() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderCategoryInformation CategoryInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfiguration> ChildConfigurations { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderIdentificationType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderIdentificationType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType NotSupported { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType SerialNumber { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderItemAddressDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>
    {
        public EdgeOrderItemAddressDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties forwardAddress) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ForwardAddress { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ReturnAddress { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderItemAddressProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties>
    {
        public EdgeOrderItemAddressProperties() { }
        public EdgeOrderItemAddressProperties(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressClassification? AddressClassification { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? AddressValidationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress ShippingAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderItemCancellationReason : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason>
    {
        public EdgeOrderItemCancellationReason(string reason) { }
        public string Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderItemDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>
    {
        public EdgeOrderItemDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDetails productDetails, Azure.ResourceManager.EdgeOrder.Models.OrderItemType orderItemType) { }
        public string CancellationReason { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus? CancellationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails CurrentStage { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus? DeletionStatus { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string FirstOrDefaultManagementResourceProviderNamespace { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails ForwardShippingDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ManagementRPDetailsList { get { throw null; } }
        public System.Collections.Generic.IList<string> NotificationEmailList { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode? OrderItemMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> OrderItemStageHistory { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemType OrderItemType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences Preferences { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDetails ProductDetails { get { throw null; } set { } }
        public string ReturnReason { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus? ReturnStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails ReverseShippingDetails { get { throw null; } }
        public System.Guid? SiteId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderItemDetailsPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch>
    {
        public EdgeOrderItemDetailsPatch() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails ParentProvisioningDetails { get { throw null; } set { } }
        public System.Guid? SiteId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderItemPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch>
    {
        public EdgeOrderItemPatch() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ForwardAddress { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationEmailList { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetailsPatch OrderItemDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences Preferences { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderItemReturnContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>
    {
        public EdgeOrderItemReturnContent(string returnReason) { }
        public bool? IsShippingBoxRequired { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ReturnAddress { get { throw null; } set { } }
        public string ReturnReason { get { throw null; } }
        public string ServiceTag { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderOrderMode : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderOrderMode(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode Default { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode DoNotFulfill { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderOrderMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderProduct : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct>
    {
        internal EdgeOrderProduct() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> Configurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? FulfilledBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderProductBillingMeterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails>
    {
        internal EdgeOrderProductBillingMeterDetails() { }
        public string Frequency { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails MeterDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType? MeteringType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails TermTypeDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderProductChargingType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderProductChargingType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType PerDevice { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType PerOrder { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderProductCostInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>
    {
        internal EdgeOrderProductCostInformation() { }
        public System.Uri BillingInfoUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails> BillingMeterDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderProductDeviceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails>
    {
        internal EdgeOrderProductDeviceDetails() { }
        public string DisplaySerialNumber { get { throw null; } }
        public string ManagementResourceId { get { throw null; } }
        public string ManagementResourceTenantId { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails ProvisioningDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport? ProvisioningSupport { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderProductImageInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation>
    {
        internal EdgeOrderProductImageInformation() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType? ImageType { get { throw null; } }
        public System.Uri ImageUri { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderProductImageType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderProductImageType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType BulletImage { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType GenericImage { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType MainImage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EdgeOrderProductMeterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails>
    {
        protected EdgeOrderProductMeterDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? ChargingType { get { throw null; } }
        public double? Multiplier { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderProductMeteringType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderProductMeteringType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType Adhoc { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType OneTime { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType Recurring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderProvisioningDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails>
    {
        public EdgeOrderProvisioningDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAutoProvisioningStatus? AutoProvisioningStatus { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.DevicePresenceVerificationDetails DevicePresenceVerification { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagementResourceArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProvisioningArmId { get { throw null; } set { } }
        public string ProvisioningEndPoint { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ReadyToConnectArmId { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public System.Guid? UniqueDeviceIdentifier { get { throw null; } }
        public string VendorName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderProvisioningSupport : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderProvisioningSupport(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport CloudBased { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderResourceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity>
    {
        public EdgeOrderResourceIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderResourceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderShippingAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress>
    {
        public EdgeOrderShippingAddress(string country) { }
        public EdgeOrderShippingAddress(string streetAddress1, string country) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType? AddressType { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string StateOrProvince { get { throw null; } set { } }
        public string StreetAddress1 { get { throw null; } set { } }
        public string StreetAddress2 { get { throw null; } set { } }
        public string StreetAddress3 { get { throw null; } set { } }
        public string ZipExtendedCode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderStageDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails>
    {
        internal EdgeOrderStageDetails() { }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName? StageName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus? StageStatus { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderStageName : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderStageName(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName Cancelled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName Confirmed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName Delivered { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName InReview { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName InUse { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName Placed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReadyToSetup { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReadyToShip { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReturnCompleted { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReturnedToMicrosoft { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReturnInitiated { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReturnPickedUp { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName Shipped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderStageStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderStageStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus Cancelling { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus None { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderTermCommitmentInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation>
    {
        internal EdgeOrderTermCommitmentInformation() { }
        public int? PendingDaysForTerm { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType TermCommitmentType { get { throw null; } }
        public System.TimeSpan? TermCommitmentTypeDuration { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderTermCommitmentPreferences : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences>
    {
        public EdgeOrderTermCommitmentPreferences(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType preferredTermCommitmentType) { }
        public System.TimeSpan? PreferredTermCommitmentDuration { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType PreferredTermCommitmentType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeOrderTermCommitmentType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeOrderTermCommitmentType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType None { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType Timed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType Trial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderTermTypeDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails>
    {
        internal EdgeOrderTermTypeDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentType TermType { get { throw null; } }
        public System.TimeSpan TermTypeDuration { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermTypeDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FilterableProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>
    {
        public FilterableProperty(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType supportedFilterType, System.Collections.Generic.IEnumerable<string> supportedValues) { }
        public Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType SupportedFilterType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedValues { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.FilterableProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.FilterableProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.FilterableProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.FilterableProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForwardShippingDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>
    {
        internal ForwardShippingDetails() { }
        public string CarrierDisplayName { get { throw null; } }
        public string CarrierName { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public System.Uri TrackingUri { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HierarchyInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation>
    {
        public HierarchyInformation() { }
        public string ConfigurationIdDisplayName { get { throw null; } set { } }
        public string ConfigurationName { get { throw null; } set { } }
        public string ProductFamilyName { get { throw null; } set { } }
        public string ProductLineName { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationPreference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference>
    {
        public NotificationPreference(Azure.ResourceManager.EdgeOrder.Models.NotificationStageName stageName, bool isNotificationRequired) { }
        public bool IsNotificationRequired { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.NotificationStageName StageName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.NotificationPreference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.NotificationPreference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.NotificationPreference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.NotificationPreference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationStageName : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.NotificationStageName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationStageName(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.NotificationStageName Delivered { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.NotificationStageName Shipped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.NotificationStageName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.NotificationStageName left, Azure.ResourceManager.EdgeOrder.Models.NotificationStageName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.NotificationStageName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.NotificationStageName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.NotificationStageName left, Azure.ResourceManager.EdgeOrder.Models.NotificationStageName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderItemCancellationStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderItemCancellationStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus Cancellable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus CancellableWithFee { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus NotCancellable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus left, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus left, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OrderItemPreferences : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences>
    {
        public OrderItemPreferences() { }
        public Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? DoubleEncryptionStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference> NotificationPreferences { get { throw null; } }
        public string PreferredManagementResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentPreferences TermCommitmentPreferences { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType? TransportPreferencesPreferredShipmentType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderItemReturnStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderItemReturnStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus NotReturnable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus Returnable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus ReturnableWithFee { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus left, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus left, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderItemType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.OrderItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderItemType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemType External { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemType Purchase { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemType Rental { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.OrderItemType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OrderItemType left, Azure.ResourceManager.EdgeOrder.Models.OrderItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OrderItemType left, Azure.ResourceManager.EdgeOrder.Models.OrderItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Pav2MeterDetails : Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails>
    {
        internal Pav2MeterDetails() { }
        public System.Guid? MeterGuid { get { throw null; } }
        protected override Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProductAvailabilityInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation>
    {
        internal ProductAvailabilityInformation() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage? AvailabilityStage { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason? DisabledReason { get { throw null; } }
        public string DisabledReasonMessage { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProductAvailabilityStage : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProductAvailabilityStage(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage Available { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage ComingSoon { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage Deprecated { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage Discoverable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage Preview { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage SignUp { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage left, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage left, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration>
    {
        internal ProductConfiguration() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderChildConfigurationType> ChildConfigurationTypes { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDimensions Dimensions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? FulfilledBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderGroupedChildConfigurations> GroupedChildConfigurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningSupport? ProvisioningSupport { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> Specifications { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.TimeSpan> SupportedTermCommitmentDurations { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProductDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDescription>
    {
        internal ProductDescription() { }
        public System.Collections.Generic.IReadOnlyList<string> Attributes { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType? DescriptionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Keywords { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLink> Links { get { throw null; } }
        public string LongDescription { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductDescription JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductDescription PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProductDescriptionType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProductDescriptionType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType Base { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType left, Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType left, Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDetails>
    {
        public ProductDetails(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderConfigurationDeviceDetails> ChildConfigurationDeviceDetails { get { throw null; } }
        public int? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails> DeviceDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo DisplayInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderIdentificationType? IdentificationType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAdditionalConfiguration> OptInAdditionalConfigurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails ParentDeviceDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProvisioningDetails ParentProvisioningDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? ProductDoubleEncryptionStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderTermCommitmentInformation TermCommitmentInformation { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProductDimensions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDimensions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDimensions>
    {
        internal ProductDimensions() { }
        public double? Depth { get { throw null; } }
        public double? Height { get { throw null; } }
        public double? Length { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit? LengthHeightUnit { get { throw null; } }
        public double? Weight { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit? WeightUnit { get { throw null; } }
        public double? Width { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductDimensions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductDimensions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductDimensions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDimensions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDimensions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductDimensions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDimensions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDimensions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDimensions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProductDisabledReason : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProductDisabledReason(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason Country { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason Feature { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason None { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason NoSubscriptionInfo { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason NotAvailable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason OfferType { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason OutOfStock { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason Region { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason left, Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason left, Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductDisplayInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo>
    {
        public ProductDisplayInfo() { }
        public string ConfigurationDisplayName { get { throw null; } }
        public string ProductFamilyDisplayName { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProductFamiliesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent>
    {
        public ProductFamiliesContent(System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>> filterableProperties) { }
        public Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>> FilterableProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProductFamiliesMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata>
    {
        internal ProductFamiliesMetadata() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? FulfilledBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLine> ProductLines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetailsList { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProductFamily : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamily>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamily>
    {
        internal ProductFamily() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? FulfilledBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLine> ProductLines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetailsList { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductFamily JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductFamily PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductFamily System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamily>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamily>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductFamily System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamily>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamily>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductFamily>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProductLengthHeightWidthUnit : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProductLengthHeightWidthUnit(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit CM { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit IN { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit left, Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit left, Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductLine : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductLine>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductLine>
    {
        internal ProductLine() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderFulfillmentType? FulfilledBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct> Products { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductLine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductLine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductLine System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductLine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductLine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductLine System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductLine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductLine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductLine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProductLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductLink>
    {
        internal ProductLink() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductLinkType? LinkType { get { throw null; } }
        public System.Uri LinkUri { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductLink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductLink PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProductLinkType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ProductLinkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProductLinkType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType Discoverable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType Documentation { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType Generic { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType KnowMore { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType SignUp { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType Specification { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType TermsAndConditions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType left, Azure.ResourceManager.EdgeOrder.Models.ProductLinkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductLinkType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductLinkType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType left, Azure.ResourceManager.EdgeOrder.Models.ProductLinkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification>
    {
        internal ProductSpecification() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ProductSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ProductSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ProductSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProductWeightMeasurementUnit : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProductWeightMeasurementUnit(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit Kgs { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit Lbs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit left, Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit left, Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurchaseMeterDetails : Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails>
    {
        internal PurchaseMeterDetails() { }
        public string ProductId { get { throw null; } }
        public string SkuId { get { throw null; } }
        public string TermId { get { throw null; } }
        protected override Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails>
    {
        internal ResourceProviderDetails() { }
        public string ResourceProviderNamespace { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReverseShippingDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails>
    {
        internal ReverseShippingDetails() { }
        public string CarrierDisplayName { get { throw null; } }
        public string CarrierName { get { throw null; } }
        public string SasKeyForLabel { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public System.Uri TrackingUri { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportedFilterType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportedFilterType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType DoubleEncryptionStatus { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType ShipToCountries { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType left, Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType left, Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransportShipmentType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransportShipmentType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType CustomerManaged { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType MicrosoftManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType left, Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType left, Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
