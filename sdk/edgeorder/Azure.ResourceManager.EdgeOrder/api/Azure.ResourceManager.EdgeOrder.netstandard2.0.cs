namespace Azure.ResourceManager.EdgeOrder
{
    public partial class AddressResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AddressResource() { }
        public virtual Azure.ResourceManager.EdgeOrder.AddressResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string addressName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.AddressResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.AddressResourcePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.AddressResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.AddressResourcePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AddressResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.AddressResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.AddressResource>, System.Collections.IEnumerable
    {
        protected AddressResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.AddressResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string addressName, Azure.ResourceManager.EdgeOrder.AddressResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.AddressResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string addressName, Azure.ResourceManager.EdgeOrder.AddressResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource> Get(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.AddressResource> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.AddressResource> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource>> GetAsync(string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeOrder.AddressResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.AddressResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeOrder.AddressResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.AddressResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AddressResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AddressResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.ContactDetails contactDetails) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus? AddressValidationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ShippingAddress ShippingAddress { get { throw null; } set { } }
    }
    public static partial class EdgeOrderExtensions
    {
        public static Azure.ResourceManager.EdgeOrder.AddressResource GetAddressResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource> GetAddressResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.AddressResource>> GetAddressResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.AddressResourceCollection GetAddressResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.AddressResource> GetAddressResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.AddressResource> GetAddressResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.OrderItemResource GetOrderItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource> GetOrderItemResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource>> GetOrderItemResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.OrderItemResourceCollection GetOrderItemResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.OrderItemResource> GetOrderItemResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.OrderItemResource> GetOrderItemResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.OrderResource GetOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.OrderResource> GetOrderResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.OrderResource>> GetOrderResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.OrderResourceCollection GetOrderResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.OrderResource> GetOrderResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.OrderResource> GetOrderResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.OrderResource> GetOrderResourcesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.OrderResource> GetOrderResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> GetProductFamilies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent content, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> GetProductFamiliesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent content, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadataDetails> GetProductFamiliesMetadata(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadataDetails> GetProductFamiliesMetadataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrderItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrderItemResource() { }
        public virtual Azure.ResourceManager.EdgeOrder.OrderItemResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelOrderItem(Azure.ResourceManager.EdgeOrder.Models.CancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelOrderItemAsync(Azure.ResourceManager.EdgeOrder.Models.CancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string orderItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReturnOrderItem(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.ReturnOrderItemDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReturnOrderItemAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.ReturnOrderItemDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.OrderItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.OrderItemResourcePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.OrderItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOrder.Models.OrderItemResourcePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrderItemResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.OrderItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.OrderItemResource>, System.Collections.IEnumerable
    {
        protected OrderItemResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.OrderItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string orderItemName, Azure.ResourceManager.EdgeOrder.OrderItemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.OrderItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string orderItemName, Azure.ResourceManager.EdgeOrder.OrderItemResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource> Get(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.OrderItemResource> GetAll(string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.OrderItemResource> GetAllAsync(string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.OrderItemResource>> GetAsync(string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeOrder.OrderItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOrder.OrderItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeOrder.OrderItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.OrderItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrderItemResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public OrderItemResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.OrderItemDetails orderItemDetails, Azure.ResourceManager.EdgeOrder.Models.AddressDetails addressDetails, string orderId) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressDetails AddressDetails { get { throw null; } set { } }
        public string OrderId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemDetails OrderItemDetails { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class OrderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrderResource() { }
        public virtual Azure.ResourceManager.EdgeOrder.OrderResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string orderName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.OrderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.OrderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrderResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected OrderResourceCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.OrderResource> Get(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.OrderResource>> GetAsync(Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrderResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public OrderResourceData() { }
        public Azure.ResourceManager.EdgeOrder.Models.StageDetails CurrentStage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OrderItemIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.StageDetails> OrderStageHistory { get { throw null; } }
    }
}
namespace Azure.ResourceManager.EdgeOrder.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionStatusEnum : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum Allowed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum NotAllowed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum left, Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum left, Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddressDetails
    {
        public AddressDetails(Azure.ResourceManager.EdgeOrder.Models.AddressProperties forwardAddress) { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressProperties ForwardAddress { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.AddressProperties ReturnAddress { get { throw null; } }
    }
    public partial class AddressProperties
    {
        public AddressProperties(Azure.ResourceManager.EdgeOrder.Models.ContactDetails contactDetails) { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus? AddressValidationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ShippingAddress ShippingAddress { get { throw null; } set { } }
    }
    public partial class AddressResourcePatch
    {
        public AddressResourcePatch() { }
        public Azure.ResourceManager.EdgeOrder.Models.ContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ShippingAddress ShippingAddress { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddressType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.AddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddressType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.AddressType Commercial { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AddressType None { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AddressType Residential { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.AddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.AddressType left, Azure.ResourceManager.EdgeOrder.Models.AddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.AddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.AddressType left, Azure.ResourceManager.EdgeOrder.Models.AddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddressValidationStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddressValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus Ambiguous { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus left, Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus left, Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailabilityInformation
    {
        internal AvailabilityInformation() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage? AvailabilityStage { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.DisabledReason? DisabledReason { get { throw null; } }
        public string DisabledReasonMessage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityStage : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityStage(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage Available { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage ComingSoon { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage Deprecated { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage Preview { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage Signup { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage left, Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage left, Azure.ResourceManager.EdgeOrder.Models.AvailabilityStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingMeterDetails
    {
        internal BillingMeterDetails() { }
        public string Frequency { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.MeterDetails MeterDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.MeteringType? MeteringType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class CancellationReason
    {
        public CancellationReason(string reason) { }
        public string Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChargingType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ChargingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChargingType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ChargingType PerDevice { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ChargingType PerOrder { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ChargingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ChargingType left, Azure.ResourceManager.EdgeOrder.Models.ChargingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ChargingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ChargingType left, Azure.ResourceManager.EdgeOrder.Models.ChargingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationFilters
    {
        public ConfigurationFilters(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperty { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
    }
    public partial class ConfigurationsContent
    {
        public ConfigurationsContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters> configurationFilters) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters> ConfigurationFilters { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails { get { throw null; } set { } }
    }
    public partial class ContactDetails
    {
        public ContactDetails(string contactName, string phone, System.Collections.Generic.IEnumerable<string> emailList) { }
        public string ContactName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailList { get { throw null; } }
        public string Mobile { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public string PhoneExtension { get { throw null; } set { } }
    }
    public partial class CostInformation
    {
        internal CostInformation() { }
        public System.Uri BillingInfoUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.BillingMeterDetails> BillingMeterDetails { get { throw null; } }
    }
    public partial class CustomerSubscriptionDetails
    {
        public CustomerSubscriptionDetails(string quotaId) { }
        public string LocationPlacementId { get { throw null; } set { } }
        public string QuotaId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionRegisteredFeatures> RegisteredFeatures { get { throw null; } }
    }
    public partial class CustomerSubscriptionRegisteredFeatures
    {
        public CustomerSubscriptionRegisteredFeatures() { }
        public string Name { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DescriptionType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.DescriptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DescriptionType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.DescriptionType Base { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.DescriptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.DescriptionType left, Azure.ResourceManager.EdgeOrder.Models.DescriptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.DescriptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.DescriptionType left, Azure.ResourceManager.EdgeOrder.Models.DescriptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceDetails
    {
        internal DeviceDetails() { }
        public string ManagementResourceId { get { throw null; } }
        public string ManagementResourceTenantId { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DisabledReason : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.DisabledReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DisabledReason(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.DisabledReason Country { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.DisabledReason Feature { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.DisabledReason None { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.DisabledReason NoSubscriptionInfo { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.DisabledReason NotAvailable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.DisabledReason OfferType { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.DisabledReason OutOfStock { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.DisabledReason Region { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.DisabledReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.DisabledReason left, Azure.ResourceManager.EdgeOrder.Models.DisabledReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.DisabledReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.DisabledReason left, Azure.ResourceManager.EdgeOrder.Models.DisabledReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DisplayInfo
    {
        public DisplayInfo() { }
        public string ConfigurationDisplayName { get { throw null; } }
        public string ProductFamilyDisplayName { get { throw null; } }
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
    public partial class EdgeOrderProduct
    {
        internal EdgeOrderProduct() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityInformation AvailabilityInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> Configurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ImageInformation> ImageInformation { get { throw null; } }
    }
    public partial class FilterableProperty
    {
        public FilterableProperty(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType supportedFilterType, System.Collections.Generic.IEnumerable<string> supportedValues) { }
        public Azure.ResourceManager.EdgeOrder.Models.SupportedFilterType SupportedFilterType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedValues { get { throw null; } }
    }
    public partial class ForwardShippingDetails
    {
        internal ForwardShippingDetails() { }
        public string CarrierDisplayName { get { throw null; } }
        public string CarrierName { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public System.Uri TrackingUri { get { throw null; } }
    }
    public partial class HierarchyInformation
    {
        public HierarchyInformation() { }
        public string ConfigurationName { get { throw null; } set { } }
        public string ProductFamilyName { get { throw null; } set { } }
        public string ProductLineName { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
    }
    public partial class ImageInformation
    {
        internal ImageInformation() { }
        public Azure.ResourceManager.EdgeOrder.Models.ImageType? ImageType { get { throw null; } }
        public System.Uri ImageUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ImageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ImageType BulletImage { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ImageType GenericImage { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ImageType MainImage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ImageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ImageType left, Azure.ResourceManager.EdgeOrder.Models.ImageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ImageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ImageType left, Azure.ResourceManager.EdgeOrder.Models.ImageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LengthHeightUnit : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LengthHeightUnit(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit CM { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit IN { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit left, Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit left, Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.LinkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.LinkType Documentation { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.LinkType Generic { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.LinkType KnowMore { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.LinkType SignUp { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.LinkType Specification { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.LinkType TermsAndConditions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.LinkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.LinkType left, Azure.ResourceManager.EdgeOrder.Models.LinkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.LinkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.LinkType left, Azure.ResourceManager.EdgeOrder.Models.LinkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MeterDetails
    {
        protected MeterDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.ChargingType? ChargingType { get { throw null; } }
        public double? Multiplier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MeteringType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.MeteringType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MeteringType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.MeteringType Adhoc { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.MeteringType OneTime { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.MeteringType Recurring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.MeteringType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.MeteringType left, Azure.ResourceManager.EdgeOrder.Models.MeteringType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.MeteringType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.MeteringType left, Azure.ResourceManager.EdgeOrder.Models.MeteringType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationPreference
    {
        public NotificationPreference(Azure.ResourceManager.EdgeOrder.Models.NotificationStageName stageName, bool sendNotification) { }
        public bool SendNotification { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.NotificationStageName StageName { get { throw null; } set { } }
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
    public readonly partial struct OrderItemCancellationEnum : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderItemCancellationEnum(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum Cancellable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum CancellableWithFee { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum NotCancellable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum left, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum left, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OrderItemDetails
    {
        public OrderItemDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDetails productDetails, Azure.ResourceManager.EdgeOrder.Models.OrderItemType orderItemType) { }
        public string CancellationReason { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationEnum? CancellationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.StageDetails CurrentStage { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ActionStatusEnum? DeletionStatus { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails ForwardShippingDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ManagementRpDetailsList { get { throw null; } }
        public string ManagementRpDetailsResourceProviderNamespace { get { throw null; } }
        public System.Collections.Generic.IList<string> NotificationEmailList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.StageDetails> OrderItemStageHistory { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemType OrderItemType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences Preferences { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDetails ProductDetails { get { throw null; } set { } }
        public string ReturnReason { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum? ReturnStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails ReverseShippingDetails { get { throw null; } }
    }
    public partial class OrderItemPreferences
    {
        public OrderItemPreferences() { }
        public Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? DoubleEncryptionStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference> NotificationPreferences { get { throw null; } }
        public string PreferredManagementResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType? TransportPreferencesPreferredShipmentType { get { throw null; } set { } }
    }
    public partial class OrderItemResourcePatch
    {
        public OrderItemResourcePatch() { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressProperties ForwardAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationEmailList { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences Preferences { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderItemReturnEnum : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderItemReturnEnum(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum NotReturnable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum Returnable { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum ReturnableWithFee { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum left, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum left, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum right) { throw null; }
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
    public partial class Pav2MeterDetails : Azure.ResourceManager.EdgeOrder.Models.MeterDetails
    {
        internal Pav2MeterDetails() { }
        public string MeterGuid { get { throw null; } }
    }
    public partial class ProductConfiguration
    {
        internal ProductConfiguration() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDimensions Dimensions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> Specifications { get { throw null; } }
    }
    public partial class ProductDescription
    {
        internal ProductDescription() { }
        public System.Collections.Generic.IReadOnlyList<string> Attributes { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.DescriptionType? DescriptionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Keywords { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLink> Links { get { throw null; } }
        public string LongDescription { get { throw null; } }
        public string ShortDescription { get { throw null; } }
    }
    public partial class ProductDetails
    {
        public ProductDetails(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation) { }
        public int? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.DeviceDetails> DeviceDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.DisplayInfo DisplayInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? ProductDoubleEncryptionStatus { get { throw null; } }
    }
    public partial class ProductDimensions
    {
        internal ProductDimensions() { }
        public double? Depth { get { throw null; } }
        public double? Height { get { throw null; } }
        public double? Length { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit? LengthHeightUnit { get { throw null; } }
        public double? Weight { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit? WeightUnit { get { throw null; } }
        public double? Width { get { throw null; } }
    }
    public partial class ProductFamiliesContent
    {
        public ProductFamiliesContent(System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>> filterableProperties) { }
        public Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>> FilterableProperties { get { throw null; } }
    }
    public partial class ProductFamiliesMetadataDetails
    {
        internal ProductFamiliesMetadataDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLine> ProductLines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetails { get { throw null; } }
    }
    public partial class ProductFamily
    {
        internal ProductFamily() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLine> ProductLines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetails { get { throw null; } }
    }
    public partial class ProductLine
    {
        internal ProductLine() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct> Products { get { throw null; } }
    }
    public partial class ProductLink
    {
        internal ProductLink() { }
        public Azure.ResourceManager.EdgeOrder.Models.LinkType? LinkType { get { throw null; } }
        public System.Uri LinkUri { get { throw null; } }
    }
    public partial class ProductSpecification
    {
        internal ProductSpecification() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class PurchaseMeterDetails : Azure.ResourceManager.EdgeOrder.Models.MeterDetails
    {
        internal PurchaseMeterDetails() { }
        public string ProductId { get { throw null; } }
        public string SkuId { get { throw null; } }
        public string TermId { get { throw null; } }
    }
    public partial class ResourceProviderDetails
    {
        internal ResourceProviderDetails() { }
        public string ResourceProviderNamespace { get { throw null; } }
    }
    public partial class ReturnOrderItemDetails
    {
        public ReturnOrderItemDetails(string returnReason) { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressProperties ReturnAddress { get { throw null; } set { } }
        public string ReturnReason { get { throw null; } }
        public string ServiceTag { get { throw null; } set { } }
        public bool? ShippingBoxRequired { get { throw null; } set { } }
    }
    public partial class ReverseShippingDetails
    {
        internal ReverseShippingDetails() { }
        public string CarrierDisplayName { get { throw null; } }
        public string CarrierName { get { throw null; } }
        public string SasKeyForLabel { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public System.Uri TrackingUri { get { throw null; } }
    }
    public partial class ShippingAddress
    {
        public ShippingAddress(string streetAddress1, string country) { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressType? AddressType { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string StateOrProvince { get { throw null; } set { } }
        public string StreetAddress1 { get { throw null; } set { } }
        public string StreetAddress2 { get { throw null; } set { } }
        public string StreetAddress3 { get { throw null; } set { } }
        public string ZipExtendedCode { get { throw null; } set { } }
    }
    public partial class StageDetails
    {
        internal StageDetails() { }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.StageName? StageName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.StageStatus? StageStatus { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StageName : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.StageName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StageName(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName Cancelled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName Confirmed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName Delivered { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName InReview { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName InUse { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName Placed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName ReadyToShip { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName ReturnCompleted { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName ReturnedToMicrosoft { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName ReturnInitiated { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName ReturnPickedUp { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageName Shipped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.StageName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.StageName left, Azure.ResourceManager.EdgeOrder.Models.StageName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.StageName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.StageName left, Azure.ResourceManager.EdgeOrder.Models.StageName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StageStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.StageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StageStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.StageStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageStatus Cancelling { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageStatus None { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.StageStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.StageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.StageStatus left, Azure.ResourceManager.EdgeOrder.Models.StageStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.StageStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.StageStatus left, Azure.ResourceManager.EdgeOrder.Models.StageStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightMeasurementUnit : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightMeasurementUnit(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit KGS { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit LBS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit left, Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit left, Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
}
