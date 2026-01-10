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
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> GetAsync(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetIfExists(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> GetIfExistsAsync(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeOrderAddressData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData>
    {
        public EdgeOrderAddressData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? AddressValidationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress ShippingAddress { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> OrderStageHistory { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddresses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddressesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource GetEdgeOrderAddressResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderResource>> GetEdgeOrderAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItem(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> GetEdgeOrderItemAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource GetEdgeOrderItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderItemCollection GetEdgeOrderItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItems(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItemsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderResource GetEdgeOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderCollection GetEdgeOrders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetAll(string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetAllAsync(string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> GetAsync(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetIfExists(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> GetIfExistsAsync(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeOrderItemData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.EdgeOrderItemData>
    {
        public EdgeOrderItemData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails orderItemDetails, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails addressDetails, Azure.Core.ResourceIdentifier orderId) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails AddressDetails { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OrderId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails OrderItemDetails { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableEdgeOrderSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeOrderSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurations(Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurationsAsync(Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddresses(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderAddressResource> GetEdgeOrderAddressesAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItems(string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderItemResource> GetEdgeOrderItemsAsync(string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrders(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.EdgeOrderResource> GetEdgeOrdersAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters ConfigurationFilters(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperty = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures> registeredFeatures = null, string locationPlacementId = null, string quotaId = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderAddressData EdgeOrderAddressData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress shippingAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? addressValidationStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderData EdgeOrderData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> orderItemIds = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails currentStage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> orderStageHistory = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails EdgeOrderItemAddressDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties forwardAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties returnAddress = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties EdgeOrderItemAddressProperties(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress shippingAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? addressValidationStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.EdgeOrderItemData EdgeOrderItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails orderItemDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails addressDetails = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier orderId = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails EdgeOrderItemDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDetails productDetails = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemType orderItemType = default(Azure.ResourceManager.EdgeOrder.Models.OrderItemType), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails currentStage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> orderItemStageHistory = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences preferences = null, Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails forwardShippingDetails = null, Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails reverseShippingDetails = null, System.Collections.Generic.IEnumerable<string> notificationEmailList = null, string cancellationReason = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus? cancellationStatus = default(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus? deletionStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus?), string returnReason = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus? returnStatus = default(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus?), string firstOrDefaultManagementResourceProviderNamespace = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> managementRPDetailsList = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent EdgeOrderItemReturnContent(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties returnAddress = null, string returnReason = null, string serviceTag = null, bool? isShippingBoxRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct EdgeOrderProduct(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> configurations = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails EdgeOrderProductBillingMeterDetails(string name = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails meterDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType? meteringType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType?), string frequency = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation EdgeOrderProductCostInformation(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails> billingMeterDetails = null, System.Uri billingInfoUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails EdgeOrderProductDeviceDetails(string serialNumber = null, string managementResourceId = null, string managementResourceTenantId = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation EdgeOrderProductImageInformation(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType? imageType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType?), System.Uri imageUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails EdgeOrderProductMeterDetails(string billingType = null, double? multiplier = default(double?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? chargingType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails EdgeOrderStageDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus? stageStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName? stageName = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName?), string displayName = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails ForwardShippingDetails(string carrierName = null, string carrierDisplayName = null, string trackingId = null, System.Uri trackingUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails Pav2MeterDetails(double? multiplier = default(double?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? chargingType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType?), System.Guid? meterGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation ProductAvailabilityInformation(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage? availabilityStage = default(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage?), Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason? disabledReason = default(Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason?), string disabledReasonMessage = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration ProductConfiguration(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> specifications = null, Azure.ResourceManager.EdgeOrder.Models.ProductDimensions dimensions = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDescription ProductDescription(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType? descriptionType = default(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType?), string shortDescription = null, string longDescription = null, System.Collections.Generic.IEnumerable<string> keywords = null, System.Collections.Generic.IEnumerable<string> attributes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLink> links = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDetails ProductDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo displayInfo = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, int? count = default(int?), Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? productDoubleEncryptionStatus = default(Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails> deviceDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDimensions ProductDimensions(double? length = default(double?), double? height = default(double?), double? width = default(double?), Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit? lengthHeightUnit = default(Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit?), double? weight = default(double?), double? depth = default(double?), Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit? weightUnit = default(Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo ProductDisplayInfo(string productFamilyDisplayName = null, string configurationDisplayName = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata ProductFamiliesMetadata(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLine> productLines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> resourceProviderDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductFamily ProductFamily(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLine> productLines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> resourceProviderDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLine ProductLine(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct> products = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLink ProductLink(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType? linkType = default(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType?), System.Uri linkUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductSpecification ProductSpecification(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails PurchaseMeterDetails(double? multiplier = default(double?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? chargingType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType?), string productId = null, string skuId = null, string termId = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails ResourceProviderDetails(string resourceProviderNamespace = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails ReverseShippingDetails(string sasKeyForLabel = null, string carrierName = null, string carrierDisplayName = null, string trackingId = null, System.Uri trackingUri = null) { throw null; }
    }
    public partial class ConfigurationFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>
    {
        public ConfigurationFilters(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperty { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigurationsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent>
    {
        public ConfigurationsContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters> configurationFilters) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters> ConfigurationFilters { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus left, Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderAddressContactDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails>
    {
        public EdgeOrderAddressContactDetails(string contactName, string phone, System.Collections.Generic.IEnumerable<string> emailList) { }
        public string ContactName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailList { get { throw null; } }
        public string Mobile { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public string PhoneExtension { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderItemAddressDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>
    {
        public EdgeOrderItemAddressDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties forwardAddress) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ForwardAddress { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ReturnAddress { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderItemAddressProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties>
    {
        public EdgeOrderItemAddressProperties(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? AddressValidationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress ShippingAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> OrderItemStageHistory { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemType OrderItemType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences Preferences { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDetails ProductDetails { get { throw null; } set { } }
        public string ReturnReason { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus? ReturnStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails ReverseShippingDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderItemPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemPatch>
    {
        public EdgeOrderItemPatch() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ForwardAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationEmailList { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences Preferences { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderProductCostInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>
    {
        internal EdgeOrderProductCostInformation() { }
        public System.Uri BillingInfoUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails> BillingMeterDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOrderProductDeviceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails>
    {
        internal EdgeOrderProductDeviceDetails() { }
        public string ManagementResourceId { get { throw null; } }
        public string ManagementResourceTenantId { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EdgeOrderProductMeterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails>
    {
        protected EdgeOrderProductMeterDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? ChargingType { get { throw null; } }
        public double? Multiplier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeOrderShippingAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress>
    {
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReadyToShip { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReturnCompleted { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReturnedToMicrosoft { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReturnInitiated { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName ReturnPickedUp { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName Shipped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus left, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FilterableProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>
    {
        public FilterableProperty(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType supportedFilterType, System.Collections.Generic.IEnumerable<string> supportedValues) { }
        public Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType SupportedFilterType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedValues { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HierarchyInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation>
    {
        public HierarchyInformation() { }
        public string ConfigurationName { get { throw null; } set { } }
        public string ProductFamilyName { get { throw null; } set { } }
        public string ProductLineName { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.NotificationStageName left, Azure.ResourceManager.EdgeOrder.Models.NotificationStageName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.NotificationStageName (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus left, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus left, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OrderItemPreferences : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences>
    {
        public OrderItemPreferences() { }
        public Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? DoubleEncryptionStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference> NotificationPreferences { get { throw null; } }
        public string PreferredManagementResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType? TransportPreferencesPreferredShipmentType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus left, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus left, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderItemType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.OrderItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderItemType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemType Purchase { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemType Rental { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.OrderItemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OrderItemType left, Azure.ResourceManager.EdgeOrder.Models.OrderItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OrderItemType left, Azure.ResourceManager.EdgeOrder.Models.OrderItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Pav2MeterDetails : Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails>
    {
        internal Pav2MeterDetails() { }
        public System.Guid? MeterGuid { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage Preview { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage SignUp { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage left, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage left, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration>
    {
        internal ProductConfiguration() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDimensions Dimensions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> Specifications { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType left, Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType left, Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDetails>
    {
        public ProductDetails(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation) { }
        public int? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails> DeviceDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo DisplayInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? ProductDoubleEncryptionStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason left, Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason left, Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductDisplayInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo>
    {
        public ProductDisplayInfo() { }
        public string ConfigurationDisplayName { get { throw null; } }
        public string ProductFamilyDisplayName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLine> ProductLines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLine> ProductLines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit left, Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit (string value) { throw null; }
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
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct> Products { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType Documentation { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType Generic { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType KnowMore { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType SignUp { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType Specification { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLinkType TermsAndConditions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType left, Azure.ResourceManager.EdgeOrder.Models.ProductLinkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductLinkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType left, Azure.ResourceManager.EdgeOrder.Models.ProductLinkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification>
    {
        internal ProductSpecification() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit left, Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit left, Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurchaseMeterDetails : Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails>
    {
        internal PurchaseMeterDetails() { }
        public string ProductId { get { throw null; } }
        public string SkuId { get { throw null; } }
        public string TermId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType left, Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType left, Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType left, Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
