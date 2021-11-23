namespace Azure.ResourceManager.EdgeOrder
{
    public partial class EdgeOrderManagementClient
    {
        protected EdgeOrderManagementClient() { }
        public EdgeOrderManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.EdgeOrder.EdgeOrderManagementClientOptions options = null) { }
        public EdgeOrderManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.EdgeOrder.EdgeOrderManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderManagementOperations EdgeOrderManagement { get { throw null; } }
    }
    public partial class EdgeOrderManagementClientOptions : Azure.Core.ClientOptions
    {
        public EdgeOrderManagementClientOptions() { }
    }
    public partial class EdgeOrderManagementCreateAddressOperation : Azure.Operation<Azure.ResourceManager.EdgeOrder.Models.AddressResource>
    {
        protected EdgeOrderManagementCreateAddressOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.EdgeOrder.Models.AddressResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.AddressResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.AddressResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderManagementCreateOrderItemOperation : Azure.Operation<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource>
    {
        protected EdgeOrderManagementCreateOrderItemOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.EdgeOrder.Models.OrderItemResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderManagementDeleteAddressByNameOperation : Azure.Operation<Azure.Response>
    {
        protected EdgeOrderManagementDeleteAddressByNameOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderManagementDeleteOrderItemByNameOperation : Azure.Operation<Azure.Response>
    {
        protected EdgeOrderManagementDeleteOrderItemByNameOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderManagementOperations
    {
        protected EdgeOrderManagementOperations() { }
        public virtual Azure.Response CancelOrderItem(string orderItemName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.CancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelOrderItemAsync(string orderItemName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.CancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.Models.AddressResource> GetAddressByName(string addressName, string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.AddressResource>> GetAddressByNameAsync(string addressName, string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.Models.OrderResource> GetOrderByName(string orderName, string resourceGroupName, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.OrderResource>> GetOrderByNameAsync(string orderName, string resourceGroupName, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource> GetOrderItemByName(string orderItemName, string resourceGroupName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource>> GetOrderItemByNameAsync(string orderItemName, string resourceGroupName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.AddressResource> ListAddressesAtResourceGroupLevel(string resourceGroupName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.AddressResource> ListAddressesAtResourceGroupLevelAsync(string resourceGroupName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.AddressResource> ListAddressesAtSubscriptionLevel(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.AddressResource> ListAddressesAtSubscriptionLevelAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.Configuration> ListConfigurations(Azure.ResourceManager.EdgeOrder.Models.ConfigurationsRequest configurationsRequest, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.Configuration> ListConfigurationsAsync(Azure.ResourceManager.EdgeOrder.Models.ConfigurationsRequest configurationsRequest, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.Operation> ListOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.Operation> ListOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.OrderResource> ListOrderAtResourceGroupLevel(string resourceGroupName, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.OrderResource> ListOrderAtResourceGroupLevelAsync(string resourceGroupName, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.OrderResource> ListOrderAtSubscriptionLevel(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.OrderResource> ListOrderAtSubscriptionLevelAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource> ListOrderItemsAtResourceGroupLevel(string resourceGroupName, string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource> ListOrderItemsAtResourceGroupLevelAsync(string resourceGroupName, string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource> ListOrderItemsAtSubscriptionLevel(string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource> ListOrderItemsAtSubscriptionLevelAsync(string filter = null, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> ListProductFamilies(Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesRequest productFamiliesRequest, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> ListProductFamiliesAsync(Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesRequest productFamiliesRequest, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadataDetails> ListProductFamiliesMetadata(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadataDetails> ListProductFamiliesMetadataAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderManagementCreateAddressOperation StartCreateAddress(string addressName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.AddressResource addressResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EdgeOrder.EdgeOrderManagementCreateAddressOperation> StartCreateAddressAsync(string addressName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.AddressResource addressResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderManagementCreateOrderItemOperation StartCreateOrderItem(string orderItemName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.OrderItemResource orderItemResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EdgeOrder.EdgeOrderManagementCreateOrderItemOperation> StartCreateOrderItemAsync(string orderItemName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.OrderItemResource orderItemResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderManagementDeleteAddressByNameOperation StartDeleteAddressByName(string addressName, string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EdgeOrder.EdgeOrderManagementDeleteAddressByNameOperation> StartDeleteAddressByNameAsync(string addressName, string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderManagementDeleteOrderItemByNameOperation StartDeleteOrderItemByName(string orderItemName, string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EdgeOrder.EdgeOrderManagementDeleteOrderItemByNameOperation> StartDeleteOrderItemByNameAsync(string orderItemName, string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderManagementReturnOrderItemOperation StartReturnOrderItem(string orderItemName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.ReturnOrderItemDetails returnOrderItemDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EdgeOrder.EdgeOrderManagementReturnOrderItemOperation> StartReturnOrderItemAsync(string orderItemName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.ReturnOrderItemDetails returnOrderItemDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderManagementUpdateAddressOperation StartUpdateAddress(string addressName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.AddressUpdateParameter addressUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EdgeOrder.EdgeOrderManagementUpdateAddressOperation> StartUpdateAddressAsync(string addressName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.AddressUpdateParameter addressUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrder.EdgeOrderManagementUpdateOrderItemOperation StartUpdateOrderItem(string orderItemName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.OrderItemUpdateParameter orderItemUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EdgeOrder.EdgeOrderManagementUpdateOrderItemOperation> StartUpdateOrderItemAsync(string orderItemName, string resourceGroupName, Azure.ResourceManager.EdgeOrder.Models.OrderItemUpdateParameter orderItemUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderManagementReturnOrderItemOperation : Azure.Operation<Azure.Response>
    {
        protected EdgeOrderManagementReturnOrderItemOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderManagementUpdateAddressOperation : Azure.Operation<Azure.ResourceManager.EdgeOrder.Models.AddressResource>
    {
        protected EdgeOrderManagementUpdateAddressOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.EdgeOrder.Models.AddressResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.AddressResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.AddressResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderManagementUpdateOrderItemOperation : Azure.Operation<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource>
    {
        protected EdgeOrderManagementUpdateOrderItemOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.EdgeOrder.Models.OrderItemResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.OrderItemResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ActionType Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ActionType left, Azure.ResourceManager.EdgeOrder.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ActionType left, Azure.ResourceManager.EdgeOrder.Models.ActionType right) { throw null; }
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
    public partial class AddressResource : Azure.ResourceManager.EdgeOrder.Models.TrackedResource
    {
        public AddressResource(string location, Azure.ResourceManager.EdgeOrder.Models.ContactDetails contactDetails) : base (default(string)) { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressValidationStatus? AddressValidationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ShippingAddress ShippingAddress { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.SystemData SystemData { get { throw null; } }
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
    public partial class AddressUpdateParameter
    {
        public AddressUpdateParameter() { }
        public Azure.ResourceManager.EdgeOrder.Models.ContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ShippingAddress ShippingAddress { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.BillingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.BillingType Pav2 { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.BillingType Purchase { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.BillingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.BillingType left, Azure.ResourceManager.EdgeOrder.Models.BillingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.BillingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.BillingType left, Azure.ResourceManager.EdgeOrder.Models.BillingType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class Configuration
    {
        internal Configuration() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.Description Description { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.Dimensions Dimensions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.Specification> Specifications { get { throw null; } }
    }
    public partial class ConfigurationFilters
    {
        public ConfigurationFilters(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperty { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
    }
    public partial class ConfigurationsRequest
    {
        public ConfigurationsRequest(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilters> configurationFilters) { }
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
        public string BillingInfoUrl { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.BillingMeterDetails> BillingMeterDetails { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.CreatedByType left, Azure.ResourceManager.EdgeOrder.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.CreatedByType left, Azure.ResourceManager.EdgeOrder.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class Description
    {
        internal Description() { }
        public System.Collections.Generic.IReadOnlyList<string> Attributes { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.DescriptionType? DescriptionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Keywords { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.Link> Links { get { throw null; } }
        public string LongDescription { get { throw null; } }
        public string ShortDescription { get { throw null; } }
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
    public partial class Dimensions
    {
        internal Dimensions() { }
        public double? Depth { get { throw null; } }
        public double? Height { get { throw null; } }
        public double? Length { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.LengthHeightUnit? LengthHeightUnit { get { throw null; } }
        public double? Weight { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.WeightMeasurementUnit? WeightUnit { get { throw null; } }
        public double? Width { get { throw null; } }
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
    public partial class EncryptionPreferences
    {
        public EncryptionPreferences() { }
        public Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? DoubleEncryptionStatus { get { throw null; } set { } }
    }
    public partial class ErrorAdditionalInfo
    {
        internal ErrorAdditionalInfo() { }
        public object Info { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ErrorDetail
    {
        internal ErrorDetail() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class FilterableProperty
    {
        public FilterableProperty(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes type, System.Collections.Generic.IEnumerable<string> supportedValues) { }
        public System.Collections.Generic.IList<string> SupportedValues { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes Type { get { throw null; } set { } }
    }
    public partial class ForwardShippingDetails
    {
        internal ForwardShippingDetails() { }
        public string CarrierDisplayName { get { throw null; } }
        public string CarrierName { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public string TrackingUrl { get { throw null; } }
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
        public string ImageUrl { get { throw null; } }
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
    public partial class Link
    {
        internal Link() { }
        public Azure.ResourceManager.EdgeOrder.Models.LinkType? LinkType { get { throw null; } }
        public string LinkUrl { get { throw null; } }
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
    public partial class ManagementResourcePreferences
    {
        public ManagementResourcePreferences() { }
        public string PreferredManagementResourceId { get { throw null; } set { } }
    }
    public partial class MeterDetails
    {
        internal MeterDetails() { }
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
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.EdgeOrder.Models.ActionType? ActionType { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.Origin? Origin { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
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
        public Azure.ResourceManager.EdgeOrder.Models.ErrorDetail Error { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails ForwardShippingDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails ManagementRpDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ManagementRpDetailsList { get { throw null; } }
        public System.Collections.Generic.IList<string> NotificationEmailList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.StageDetails> OrderItemStageHistory { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemType OrderItemType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.Preferences Preferences { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDetails ProductDetails { get { throw null; } set { } }
        public string ReturnReason { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnEnum? ReturnStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails ReverseShippingDetails { get { throw null; } }
    }
    public partial class OrderItemResource : Azure.ResourceManager.EdgeOrder.Models.TrackedResource
    {
        public OrderItemResource(string location, Azure.ResourceManager.EdgeOrder.Models.OrderItemDetails orderItemDetails, Azure.ResourceManager.EdgeOrder.Models.AddressDetails addressDetails, string orderId) : base (default(string)) { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressDetails AddressDetails { get { throw null; } set { } }
        public string OrderId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemDetails OrderItemDetails { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.SystemData SystemData { get { throw null; } }
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
    public partial class OrderItemUpdateParameter
    {
        public OrderItemUpdateParameter() { }
        public Azure.ResourceManager.EdgeOrder.Models.AddressProperties ForwardAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationEmailList { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.Preferences Preferences { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class OrderResource : Azure.ResourceManager.EdgeOrder.Models.ProxyResource
    {
        public OrderResource() { }
        public Azure.ResourceManager.EdgeOrder.Models.StageDetails CurrentStage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OrderItemIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.StageDetails> OrderStageHistory { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.SystemData SystemData { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Origin : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.Origin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Origin(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.Origin System { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.Origin User { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.Origin UserSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.Origin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.Origin left, Azure.ResourceManager.EdgeOrder.Models.Origin right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.Origin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.Origin left, Azure.ResourceManager.EdgeOrder.Models.Origin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Pav2MeterDetails : Azure.ResourceManager.EdgeOrder.Models.MeterDetails
    {
        internal Pav2MeterDetails() { }
        public string MeterGuid { get { throw null; } }
    }
    public partial class Preferences
    {
        public Preferences() { }
        public Azure.ResourceManager.EdgeOrder.Models.EncryptionPreferences EncryptionPreferences { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ManagementResourcePreferences ManagementResourcePreferences { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference> NotificationPreferences { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.TransportPreferences TransportPreferences { get { throw null; } set { } }
    }
    public partial class Product
    {
        internal Product() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityInformation AvailabilityInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.Configuration> Configurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.Description Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ImageInformation> ImageInformation { get { throw null; } }
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
    public partial class ProductFamiliesMetadataDetails
    {
        internal ProductFamiliesMetadataDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.Description Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLine> ProductLines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetails { get { throw null; } }
    }
    public partial class ProductFamiliesRequest
    {
        public ProductFamiliesRequest(System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>> filterableProperties) { }
        public Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>> FilterableProperties { get { throw null; } }
    }
    public partial class ProductFamily
    {
        internal ProductFamily() { }
        public Azure.ResourceManager.EdgeOrder.Models.AvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.Description Description { get { throw null; } }
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
        public Azure.ResourceManager.EdgeOrder.Models.Description Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.Product> Products { get { throw null; } }
    }
    public partial class ProxyResource : Azure.ResourceManager.EdgeOrder.Models.Resource
    {
        public ProxyResource() { }
    }
    public partial class PurchaseMeterDetails : Azure.ResourceManager.EdgeOrder.Models.MeterDetails
    {
        internal PurchaseMeterDetails() { }
        public string ProductId { get { throw null; } }
        public string SkuId { get { throw null; } }
        public string TermId { get { throw null; } }
    }
    public partial class Resource
    {
        public Resource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
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
        public string TrackingUrl { get { throw null; } }
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
    public partial class Specification
    {
        internal Specification() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StageDetails
    {
        internal StageDetails() { }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.StageName? StageName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.StageStatus? StageStatus { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
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
    public readonly partial struct SupportedFilterTypes : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportedFilterTypes(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes DoubleEncryptionStatus { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes ShipToCountries { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes left, Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes left, Azure.ResourceManager.EdgeOrder.Models.SupportedFilterTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SystemData
    {
        internal SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CreatedByType? CreatedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.CreatedByType? LastModifiedByType { get { throw null; } }
    }
    public partial class TrackedResource : Azure.ResourceManager.EdgeOrder.Models.Resource
    {
        public TrackedResource(string location) { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TransportPreferences
    {
        public TransportPreferences(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes preferredShipmentType) { }
        public Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes PreferredShipmentType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransportShipmentTypes : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransportShipmentTypes(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes CustomerManaged { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes MicrosoftManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes left, Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes left, Azure.ResourceManager.EdgeOrder.Models.TransportShipmentTypes right) { throw null; }
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
