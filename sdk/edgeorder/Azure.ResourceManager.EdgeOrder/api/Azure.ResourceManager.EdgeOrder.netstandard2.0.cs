namespace Azure.ResourceManager.EdgeOrder
{
    public static partial class EdgeOrderExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.UploadArtifactsResult> ArtifactsUpload(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string name, Azure.ResourceManager.EdgeOrder.Models.UploadArtifactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.UploadArtifactsResult>> ArtifactsUploadAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string name, Azure.ResourceManager.EdgeOrder.Models.UploadArtifactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response CancelOrderItem(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string orderItemName, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> CancelOrderItemAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string orderItemName, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemCancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress> CreateAddress(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string addressName, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress addressResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress>> CreateAddressAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string addressName, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress addressResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource> CreateBootstrapConfiguration(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string name, Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource bootstrapConfigurationResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource>> CreateBootstrapConfigurationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string name, Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource bootstrapConfigurationResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem> CreateOrderItem(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string orderItemName, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem orderItemResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem>> CreateOrderItemAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string orderItemName, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem orderItemResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation DeleteAddress(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAddressAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response DeleteBootstrapConfiguration(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> DeleteBootstrapConfigurationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation DeleteOrderItem(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string orderItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteOrderItemAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string orderItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress> GetAddress(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress>> GetAddressAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string addressName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress> GetAddressesByResourceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress> GetAddressesByResourceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress> GetAddressesBySubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress> GetAddressesBySubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string filter = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource> GetBootstrapConfiguration(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource>> GetBootstrapConfigurationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource> GetBootstrapConfigurationsByResourceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource> GetBootstrapConfigurationsByResourceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource> GetBootstrapConfigurationsBySubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource> GetBootstrapConfigurationsBySubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurationsProductsAndConfigurations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> GetConfigurationsProductsAndConfigurationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, Azure.ResourceManager.EdgeOrder.Models.ConfigurationsContent content, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.Models.EdgeOrder> GetOrder(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.EdgeOrder>> GetOrderAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, Azure.Core.AzureLocation location, string orderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem> GetOrderItem(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem>> GetOrderItemAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string orderItemName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem> GetOrderItemsByResourceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.EdgeOrder.Models.TenantResourceGetOrderItemsByResourceGroupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem> GetOrderItemsByResourceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.EdgeOrder.Models.TenantResourceGetOrderItemsByResourceGroupOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem> GetOrderItemsBySubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string filter = null, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem> GetOrderItemsBySubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string filter = null, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrder> GetOrdersByResourceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrder> GetOrdersByResourceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrder> GetOrdersBySubscription(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrder> GetOrdersBySubscriptionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata> GetProductFamiliesMetadataProductsAndConfigurations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata> GetProductFamiliesMetadataProductsAndConfigurationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> GetProductFamiliesProductsAndConfigurations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent content, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeOrder.Models.ProductFamily> GetProductFamiliesProductsAndConfigurationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesContent content, string expand = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.TokenResult> GetToken(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.TokenResult>> GetTokenAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation ReturnOrderItem(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string orderItemName, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReturnOrderItemAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string orderItemName, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemReturnContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress> UpdateAddress(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string addressName, Azure.ResourceManager.EdgeOrder.Models.AddressUpdateParameter addressUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress>> UpdateAddressAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string addressName, Azure.ResourceManager.EdgeOrder.Models.AddressUpdateParameter addressUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource> UpdateBootstrapConfiguration(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string name, Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationUpdateParameter bootstrapConfigurationUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource>> UpdateBootstrapConfigurationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid subscriptionId, string resourceGroupName, string name, Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationUpdateParameter bootstrapConfigurationUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem> UpdateOrderItem(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string orderItemName, Azure.ResourceManager.EdgeOrder.Models.OrderItemUpdateParameter orderItemUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem>> UpdateOrderItemAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, System.Guid subscriptionId, string resourceGroupName, string orderItemName, Azure.ResourceManager.EdgeOrder.Models.OrderItemUpdateParameter orderItemUpdateParameter, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeOrder.Models
{
    public partial class AdditionalConfiguration
    {
        public AdditionalConfiguration(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation, int quantity) { }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProvisioningDetails ProvisioningDetails { get { throw null; } set { } }
        public int Quantity { get { throw null; } set { } }
    }
    public partial class AddressUpdateParameter
    {
        public AddressUpdateParameter() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress ShippingAddress { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public static partial class ArmEdgeOrderModelFactory
    {
        public static Azure.ResourceManager.EdgeOrder.Models.BootstrapConfigurationResource BootstrapConfigurationResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string siteResourceId = null, int maximumNumberOfDevicesToOnboard = 0, System.DateTimeOffset tokenExpiryDate = default(System.DateTimeOffset), int? numberOfDevicesOnboarded = default(int?), Azure.ResourceManager.EdgeOrder.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeOrder.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.CategoryInformation CategoryInformation(string categoryName = null, string categoryDisplayName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLink> links = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ChildConfiguration ChildConfiguration(Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType? childConfigurationType = default(Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType?), bool? isPartOfBaseConfiguration = default(bool?), int? minimumQuantity = default(int?), int? maximumQuantity = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> specifications = null, Azure.ResourceManager.EdgeOrder.Models.ProductDimensions dimensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType> childConfigurationTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.GroupedChildConfigurations> groupedChildConfigurations = null, System.Collections.Generic.IEnumerable<System.TimeSpan> supportedTermCommitmentDurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.FulfillmentType?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ConfigurationDeviceDetails ConfigurationDeviceDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo displayInfo = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, int? quantity = default(int?), Azure.ResourceManager.EdgeOrder.Models.IdentificationType? identificationType = default(Azure.ResourceManager.EdgeOrder.Models.IdentificationType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails> deviceDetails = null, Azure.ResourceManager.EdgeOrder.Models.TermCommitmentInformation termCommitmentInformation = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrder EdgeOrder(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> orderItemIds = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails currentStage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> orderStageHistory = null, Azure.ResourceManager.EdgeOrder.Models.OrderMode? orderMode = default(Azure.ResourceManager.EdgeOrder.Models.OrderMode?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddress EdgeOrderAddress(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress shippingAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? addressValidationStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus?), Azure.ResourceManager.EdgeOrder.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeOrder.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItem EdgeOrderItem(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails orderItemDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails addressDetails = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier orderId = null, Azure.ResourceManager.EdgeOrder.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeOrder.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails EdgeOrderItemAddressDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties forwardAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties returnAddress = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties EdgeOrderItemAddressProperties(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress shippingAddress = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? addressValidationStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus?), Azure.ResourceManager.EdgeOrder.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeOrder.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails EdgeOrderItemDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDetails productDetails = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemType orderItemType = default(Azure.ResourceManager.EdgeOrder.Models.OrderItemType), Azure.ResourceManager.EdgeOrder.Models.OrderMode? orderItemMode = default(Azure.ResourceManager.EdgeOrder.Models.OrderMode?), string siteId = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails currentStage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> orderItemStageHistory = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences preferences = null, Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails forwardShippingDetails = null, Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails reverseShippingDetails = null, System.Collections.Generic.IEnumerable<string> notificationEmailList = null, string cancellationReason = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus? cancellationStatus = default(Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus? deletionStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus?), string returnReason = null, Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus? returnStatus = default(Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> managementRPDetailsList = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct EdgeOrderProduct(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.FulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> configurations = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails EdgeOrderProductBillingMeterDetails(string name = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails meterDetails = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType? meteringType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType?), string frequency = null, Azure.ResourceManager.EdgeOrder.Models.TermTypeDetails termTypeDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation EdgeOrderProductCostInformation(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails> billingMeterDetails = null, System.Uri billingInfoUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails EdgeOrderProductDeviceDetails(string serialNumber = null, string managementResourceId = null, string managementResourceTenantId = null, Azure.ResourceManager.EdgeOrder.Models.ProvisioningDetails provisioningDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation EdgeOrderProductImageInformation(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType? imageType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType?), System.Uri imageUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails EdgeOrderProductMeterDetails(string billingType = "Unknown", double? multiplier = default(double?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? chargingType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails EdgeOrderStageDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus? stageStatus = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName? stageName = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName?), string displayName = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails ForwardShippingDetails(string carrierName = null, string carrierDisplayName = null, string trackingId = null, System.Uri trackingUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.GroupedChildConfigurations GroupedChildConfigurations(Azure.ResourceManager.EdgeOrder.Models.CategoryInformation categoryInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ChildConfiguration> childConfigurations = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.IPv4 IPv4(Azure.ResourceManager.EdgeOrder.Models.IPv4AddressRange addressRange = null, string ipAddress = null, string subnetMask = null, string defaultGateway = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, int vLanId = 0) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.Pav2MeterDetails Pav2MeterDetails(double? multiplier = default(double?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? chargingType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType?), System.Guid? meterGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation ProductAvailabilityInformation(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage? availabilityStage = default(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage?), Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason? disabledReason = default(Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason?), string disabledReasonMessage = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration ProductConfiguration(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.FulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> specifications = null, Azure.ResourceManager.EdgeOrder.Models.ProductDimensions dimensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType> childConfigurationTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.GroupedChildConfigurations> groupedChildConfigurations = null, System.Collections.Generic.IEnumerable<System.TimeSpan> supportedTermCommitmentDurations = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDescription ProductDescription(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType? descriptionType = default(Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType?), string shortDescription = null, string longDescription = null, System.Collections.Generic.IEnumerable<string> keywords = null, System.Collections.Generic.IEnumerable<string> attributes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLink> links = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDetails ProductDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo displayInfo = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? productDoubleEncryptionStatus = default(Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus?), Azure.ResourceManager.EdgeOrder.Models.IdentificationType? identificationType = default(Azure.ResourceManager.EdgeOrder.Models.IdentificationType?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails parentDeviceDetails = null, Azure.ResourceManager.EdgeOrder.Models.ProvisioningDetails parentProvisioningDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.AdditionalConfiguration> optInAdditionalConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ConfigurationDeviceDetails> childConfigurationDeviceDetails = null, Azure.ResourceManager.EdgeOrder.Models.TermCommitmentInformation termCommitmentInformation = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDimensions ProductDimensions(double? length = default(double?), double? height = default(double?), double? width = default(double?), Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit? lengthHeightUnit = default(Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit?), double? weight = default(double?), double? depth = default(double?), Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit? weightUnit = default(Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo ProductDisplayInfo(string productFamilyDisplayName = null, string configurationDisplayName = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductFamiliesMetadata ProductFamiliesMetadata(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.FulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLine> productLines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> resourceProviderDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductFamily ProductFamily(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.FulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ProductLine> productLines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> resourceProviderDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLine ProductLine(string displayName = null, Azure.ResourceManager.EdgeOrder.Models.ProductDescription description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> imageInformation = null, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation costInformation = null, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation availabilityInformation = null, Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation = null, Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? fulfilledBy = default(Azure.ResourceManager.EdgeOrder.Models.FulfillmentType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> filterableProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct> products = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductLink ProductLink(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType? linkType = default(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType?), System.Uri linkUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProductSpecification ProductSpecification(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProvisioningDetails ProvisioningDetails(Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus? autoProvisioningStatus = default(Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus?), int? quantity = default(int?), Azure.Core.ResourceIdentifier provisioningArmId = null, string provisioningEndPoint = null, string serialNumber = null, string vendorName = null, string model = null, Azure.Core.ResourceIdentifier readyToConnectArmId = null, string onboardingArmId = null, Azure.Core.ResourceIdentifier managementResourceArmId = null, string uniqueDeviceIdentifier = null, string ownershipVoucher = null, Azure.ResourceManager.EdgeOrder.Models.OperatingSystemPreferences operatingSystemPreferences = null, Azure.ResourceManager.EdgeOrder.Models.DeviceConfigurations deviceConfigurations = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.PurchaseMeterDetails PurchaseMeterDetails(double? multiplier = default(double?), Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? chargingType = default(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType?), string productId = null, string skuId = null, string termId = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails ResourceProviderDetails(string resourceProviderNamespace = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails ReverseShippingDetails(string sasKeyForLabel = null, string carrierName = null, string carrierDisplayName = null, string trackingId = null, System.Uri trackingUri = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.TermCommitmentInformation TermCommitmentInformation(Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType termCommitmentType = default(Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType), System.TimeSpan? termCommitmentTypeDuration = default(System.TimeSpan?), int? pendingDaysForTerm = default(int?)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.TermTypeDetails TermTypeDetails(Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType termType = default(Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType), System.TimeSpan termTypeDuration = default(System.TimeSpan)) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.TokenResult TokenResult(string token = null) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.UploadArtifactsResult UploadArtifactsResult(string serialNumber = null, string deviceUniqueCode = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoProvisioningStatus : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoProvisioningStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus left, Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus left, Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BootstrapConfigurationResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BootstrapConfigurationResource(Azure.Core.AzureLocation location, string siteResourceId, int maximumNumberOfDevicesToOnboard, System.DateTimeOffset tokenExpiryDate) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public int MaximumNumberOfDevicesToOnboard { get { throw null; } set { } }
        public int? NumberOfDevicesOnboarded { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SiteResourceId { get { throw null; } set { } }
        public System.DateTimeOffset TokenExpiryDate { get { throw null; } set { } }
    }
    public partial class BootstrapConfigurationUpdateParameter
    {
        public BootstrapConfigurationUpdateParameter() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CategoryInformation
    {
        internal CategoryInformation() { }
        public string CategoryDisplayName { get { throw null; } }
        public string CategoryName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLink> Links { get { throw null; } }
    }
    public partial class ChildConfiguration
    {
        internal ChildConfiguration() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType? ChildConfigurationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType> ChildConfigurationTypes { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDimensions Dimensions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? FulfilledBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.GroupedChildConfigurations> GroupedChildConfigurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public bool? IsPartOfBaseConfiguration { get { throw null; } }
        public int? MaximumQuantity { get { throw null; } }
        public int? MinimumQuantity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> Specifications { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.TimeSpan> SupportedTermCommitmentDurations { get { throw null; } }
    }
    public partial class ChildConfigurationFilter
    {
        public ChildConfigurationFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType> ChildConfigurationTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation> HierarchyInformations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChildConfigurationType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChildConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType AdditionalConfiguration { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType DeviceConfiguration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType left, Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType left, Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationDeviceDetails
    {
        internal ConfigurationDeviceDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails> DeviceDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo DisplayInfo { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.IdentificationType? IdentificationType { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.TermCommitmentInformation TermCommitmentInformation { get { throw null; } }
    }
    public partial class ConfigurationFilter
    {
        public ConfigurationFilter(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation) { }
        public Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationFilter ChildConfigurationFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperty { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
    }
    public partial class ConfigurationsContent
    {
        public ConfigurationsContent() { }
        public Azure.ResourceManager.EdgeOrder.Models.ConfigurationFilter ConfigurationFilter { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails { get { throw null; } set { } }
    }
    public partial class ConnectivityConfigurationProperties
    {
        public ConnectivityConfigurationProperties(string timezone, string connectivityType) { }
        public string ConnectivityType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProxyConfiguration ProxyConfiguration { get { throw null; } set { } }
        public string Timezone { get { throw null; } set { } }
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
    public partial class DeviceConfigurations
    {
        public DeviceConfigurations() { }
        public Azure.ResourceManager.EdgeOrder.Models.ConnectivityConfigurationProperties ConnectivityProperties { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.NetworkConfiguration> NetworkConfigurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.TimeServerConfigurationProperties TimeServerProperties { get { throw null; } set { } }
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
    public partial class EdgeOrder : Azure.ResourceManager.Models.ResourceData
    {
        public EdgeOrder() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails CurrentStage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> OrderItemIds { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderMode? OrderMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> OrderStageHistory { get { throw null; } }
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
    public partial class EdgeOrderAddress : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EdgeOrderAddress(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? AddressValidationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress ShippingAddress { get { throw null; } set { } }
    }
    public partial class EdgeOrderAddressContactDetails
    {
        public EdgeOrderAddressContactDetails(string contactName, string phone, System.Collections.Generic.IEnumerable<string> emailList) { }
        public string ContactName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailList { get { throw null; } }
        public string Mobile { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public string PhoneExtension { get { throw null; } set { } }
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
    public partial class EdgeOrderItem : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EdgeOrderItem(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails orderItemDetails, Azure.Core.ResourceIdentifier orderId) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressDetails AddressDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OrderId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemDetails OrderItemDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class EdgeOrderItemAddressDetails
    {
        public EdgeOrderItemAddressDetails(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties forwardAddress) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ForwardAddress { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ReturnAddress { get { throw null; } }
    }
    public partial class EdgeOrderItemAddressProperties
    {
        public EdgeOrderItemAddressProperties(Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails contactDetails) { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressValidationStatus? AddressValidationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderAddressContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderShippingAddress ShippingAddress { get { throw null; } set { } }
    }
    public partial class EdgeOrderItemCancellationReason
    {
        public EdgeOrderItemCancellationReason(string reason) { }
        public string Reason { get { throw null; } }
    }
    public partial class EdgeOrderItemDetails
    {
        public EdgeOrderItemDetails(Azure.ResourceManager.EdgeOrder.Models.ProductDetails productDetails, Azure.ResourceManager.EdgeOrder.Models.OrderItemType orderItemType) { }
        public string CancellationReason { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemCancellationStatus? CancellationStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails CurrentStage { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderActionStatus? DeletionStatus { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ForwardShippingDetails ForwardShippingDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ManagementRPDetailsList { get { throw null; } }
        public System.Collections.Generic.IList<string> NotificationEmailList { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderMode? OrderItemMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageDetails> OrderItemStageHistory { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemType OrderItemType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences Preferences { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDetails ProductDetails { get { throw null; } set { } }
        public string ReturnReason { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemReturnStatus? ReturnStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ReverseShippingDetails ReverseShippingDetails { get { throw null; } }
        public string SiteId { get { throw null; } set { } }
    }
    public partial class EdgeOrderItemReturnContent
    {
        public EdgeOrderItemReturnContent(string returnReason) { }
        public bool? IsShippingBoxRequired { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ReturnAddress { get { throw null; } set { } }
        public string ReturnReason { get { throw null; } }
        public string ServiceTag { get { throw null; } set { } }
    }
    public partial class EdgeOrderProduct
    {
        internal EdgeOrderProduct() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductConfiguration> Configurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? FulfilledBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
    }
    public partial class EdgeOrderProductBillingMeterDetails
    {
        internal EdgeOrderProductBillingMeterDetails() { }
        public string Frequency { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails MeterDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeteringType? MeteringType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.TermTypeDetails TermTypeDetails { get { throw null; } }
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
    public partial class EdgeOrderProductCostInformation
    {
        internal EdgeOrderProductCostInformation() { }
        public System.Uri BillingInfoUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductBillingMeterDetails> BillingMeterDetails { get { throw null; } }
    }
    public partial class EdgeOrderProductDeviceDetails
    {
        internal EdgeOrderProductDeviceDetails() { }
        public string ManagementResourceId { get { throw null; } }
        public string ManagementResourceTenantId { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProvisioningDetails ProvisioningDetails { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    public partial class EdgeOrderProductImageInformation
    {
        internal EdgeOrderProductImageInformation() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageType? ImageType { get { throw null; } }
        public System.Uri ImageUri { get { throw null; } }
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
    public abstract partial class EdgeOrderProductMeterDetails
    {
        protected EdgeOrderProductMeterDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductChargingType? ChargingType { get { throw null; } }
        public double? Multiplier { get { throw null; } }
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
    public partial class EdgeOrderShippingAddress
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
    }
    public partial class EdgeOrderStageDetails
    {
        internal EdgeOrderStageDetails() { }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageName? StageName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderStageStatus? StageStatus { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FulfillmentType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.FulfillmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FulfillmentType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.FulfillmentType External { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.FulfillmentType Microsoft { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.FulfillmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.FulfillmentType left, Azure.ResourceManager.EdgeOrder.Models.FulfillmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.FulfillmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.FulfillmentType left, Azure.ResourceManager.EdgeOrder.Models.FulfillmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GroupedChildConfigurations
    {
        internal GroupedChildConfigurations() { }
        public Azure.ResourceManager.EdgeOrder.Models.CategoryInformation CategoryInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ChildConfiguration> ChildConfigurations { get { throw null; } }
    }
    public partial class HierarchyInformation
    {
        public HierarchyInformation() { }
        public string ConfigurationIdDisplayName { get { throw null; } set { } }
        public string ConfigurationName { get { throw null; } set { } }
        public string ProductFamilyName { get { throw null; } set { } }
        public string ProductLineName { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentificationType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.IdentificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentificationType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.IdentificationType NotSupported { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.IdentificationType SerialNumber { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.IdentificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.IdentificationType left, Azure.ResourceManager.EdgeOrder.Models.IdentificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.IdentificationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.IdentificationType left, Azure.ResourceManager.EdgeOrder.Models.IdentificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAssignment
    {
        public IPAssignment(string ipAssignmentType, Azure.ResourceManager.EdgeOrder.Models.IPv4 ipv4) { }
        public string IPAssignmentType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.IPv4 IPv4 { get { throw null; } set { } }
    }
    public partial class IPv4
    {
        public IPv4(Azure.ResourceManager.EdgeOrder.Models.IPv4AddressRange addressRange, string subnetMask, string defaultGateway, System.Collections.Generic.IEnumerable<string> dnsServers, int vLanId) { }
        public Azure.ResourceManager.EdgeOrder.Models.IPv4AddressRange AddressRange { get { throw null; } set { } }
        public string DefaultGateway { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string SubnetMask { get { throw null; } set { } }
        public int VLanId { get { throw null; } set { } }
    }
    public partial class IPv4AddressRange
    {
        public IPv4AddressRange(string startIP, string endIP) { }
        public string EndIP { get { throw null; } set { } }
        public string StartIP { get { throw null; } set { } }
    }
    public partial class KeyVaultSecret
    {
        public KeyVaultSecret(System.Uri keyVaultSecretUri, string keyVaultArmId) { }
        public string KeyVaultArmId { get { throw null; } set { } }
        public System.Uri KeyVaultSecretUri { get { throw null; } set { } }
    }
    public partial class NetworkConfiguration
    {
        public NetworkConfiguration(Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationProperties properties, Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind kind) { }
        public Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationProperties Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkConfigurationKind : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkConfigurationKind(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind LAN { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind Wan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind left, Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind left, Azure.ResourceManager.EdgeOrder.Models.NetworkConfigurationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkConfigurationProperties
    {
        public NetworkConfigurationProperties(Azure.ResourceManager.EdgeOrder.Models.IPAssignment ipAssignments) { }
        public string CommonName { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.IPAssignment IPAssignments { get { throw null; } set { } }
    }
    public partial class NotificationPreference
    {
        public NotificationPreference(Azure.ResourceManager.EdgeOrder.Models.NotificationStageName stageName, bool isNotificationRequired) { }
        public bool IsNotificationRequired { get { throw null; } set { } }
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
    public partial class NtpServerConfiguration
    {
        public NtpServerConfiguration() { }
        public string AlternateNtpServer { get { throw null; } set { } }
        public string NtpServer { get { throw null; } set { } }
    }
    public partial class OperatingSystemPreferences
    {
        public OperatingSystemPreferences(Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType operatingSystemType, string operatingSystemVersion, string adminUserName, Azure.ResourceManager.EdgeOrder.Models.KeyVaultSecret adminPassword) { }
        public Azure.ResourceManager.EdgeOrder.Models.KeyVaultSecret AdminPassword { get { throw null; } set { } }
        public string AdminUserName { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType OperatingSystemType { get { throw null; } set { } }
        public string OperatingSystemVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType AzureLinux { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType left, Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType left, Azure.ResourceManager.EdgeOrder.Models.OperatingSystemType right) { throw null; }
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
    public partial class OrderItemPreferences
    {
        public OrderItemPreferences() { }
        public Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? DoubleEncryptionStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.NotificationPreference> NotificationPreferences { get { throw null; } }
        public string PreferredManagementResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.TermCommitmentPreferences TermCommitmentPreferences { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.TransportShipmentType? TransportPreferencesPreferredShipmentType { get { throw null; } set { } }
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
        public static Azure.ResourceManager.EdgeOrder.Models.OrderItemType External { get { throw null; } }
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
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderItemAddressProperties ForwardAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationEmailList { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.OrderItemPreferences Preferences { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderMode : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.OrderMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderMode(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderMode Default { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.OrderMode DoNotFulfill { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.OrderMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.OrderMode left, Azure.ResourceManager.EdgeOrder.Models.OrderMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.OrderMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.OrderMode left, Azure.ResourceManager.EdgeOrder.Models.OrderMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Pav2MeterDetails : Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails
    {
        internal Pav2MeterDetails() { }
        public System.Guid? MeterGuid { get { throw null; } }
    }
    public partial class ProductAvailabilityInformation
    {
        internal ProductAvailabilityInformation() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage? AvailabilityStage { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDisabledReason? DisabledReason { get { throw null; } }
        public string DisabledReasonMessage { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage left, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage left, Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductConfiguration
    {
        internal ProductConfiguration() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ChildConfigurationType> ChildConfigurationTypes { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDimensions Dimensions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? FulfilledBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.GroupedChildConfigurations> GroupedChildConfigurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductSpecification> Specifications { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.TimeSpan> SupportedTermCommitmentDurations { get { throw null; } }
    }
    public partial class ProductDescription
    {
        internal ProductDescription() { }
        public System.Collections.Generic.IReadOnlyList<string> Attributes { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescriptionType? DescriptionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Keywords { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLink> Links { get { throw null; } }
        public string LongDescription { get { throw null; } }
        public string ShortDescription { get { throw null; } }
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
    public partial class ProductDetails
    {
        public ProductDetails(Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation hierarchyInformation) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ConfigurationDeviceDetails> ChildConfigurationDeviceDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDisplayInfo DisplayInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.IdentificationType? IdentificationType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.AdditionalConfiguration> OptInAdditionalConfigurations { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductDeviceDetails ParentDeviceDetails { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProvisioningDetails ParentProvisioningDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.DoubleEncryptionStatus? ProductDoubleEncryptionStatus { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.TermCommitmentInformation TermCommitmentInformation { get { throw null; } }
    }
    public partial class ProductDimensions
    {
        internal ProductDimensions() { }
        public double? Depth { get { throw null; } }
        public double? Height { get { throw null; } }
        public double? Length { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductLengthHeightWidthUnit? LengthHeightUnit { get { throw null; } }
        public double? Weight { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductWeightMeasurementUnit? WeightUnit { get { throw null; } }
        public double? Width { get { throw null; } }
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
    public partial class ProductDisplayInfo
    {
        public ProductDisplayInfo() { }
        public string ConfigurationDisplayName { get { throw null; } }
        public string ProductFamilyDisplayName { get { throw null; } }
    }
    public partial class ProductFamiliesContent
    {
        public ProductFamiliesContent(System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>> filterableProperties) { }
        public Azure.ResourceManager.EdgeOrder.Models.CustomerSubscriptionDetails CustomerSubscriptionDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty>> FilterableProperties { get { throw null; } }
    }
    public partial class ProductFamiliesMetadata
    {
        internal ProductFamiliesMetadata() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? FulfilledBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLine> ProductLines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetails { get { throw null; } }
    }
    public partial class ProductFamily
    {
        internal ProductFamily() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? FulfilledBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ProductLine> ProductLines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.ResourceProviderDetails> ResourceProviderDetails { get { throw null; } }
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
    public partial class ProductLine
    {
        internal ProductLine() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductAvailabilityInformation AvailabilityInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductCostInformation CostInformation { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.ProductDescription Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.FilterableProperty> FilterableProperties { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.FulfillmentType? FulfilledBy { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.HierarchyInformation HierarchyInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductImageInformation> ImageInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProduct> Products { get { throw null; } }
    }
    public partial class ProductLink
    {
        internal ProductLink() { }
        public Azure.ResourceManager.EdgeOrder.Models.ProductLinkType? LinkType { get { throw null; } }
        public System.Uri LinkUri { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType left, Azure.ResourceManager.EdgeOrder.Models.ProductLinkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProductLinkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProductLinkType left, Azure.ResourceManager.EdgeOrder.Models.ProductLinkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductSpecification
    {
        internal ProductSpecification() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
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
    public partial class ProvisioningDetails
    {
        public ProvisioningDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.AutoProvisioningStatus? AutoProvisioningStatus { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.DeviceConfigurations DeviceConfigurations { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagementResourceArmId { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string OnboardingArmId { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.OperatingSystemPreferences OperatingSystemPreferences { get { throw null; } set { } }
        public string OwnershipVoucher { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProvisioningArmId { get { throw null; } set { } }
        public string ProvisioningEndPoint { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ReadyToConnectArmId { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string UniqueDeviceIdentifier { get { throw null; } }
        public string VendorName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.ProvisioningState left, Azure.ResourceManager.EdgeOrder.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.ProvisioningState left, Azure.ResourceManager.EdgeOrder.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyConfiguration
    {
        public ProxyConfiguration(System.Uri uri, int port, System.Collections.Generic.IEnumerable<string> byPassUrls) { }
        public System.Collections.Generic.IList<string> ByPassUrls { get { throw null; } }
        public int Port { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class PurchaseMeterDetails : Azure.ResourceManager.EdgeOrder.Models.EdgeOrderProductMeterDetails
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
    public partial class ReverseShippingDetails
    {
        internal ReverseShippingDetails() { }
        public string CarrierDisplayName { get { throw null; } }
        public string CarrierName { get { throw null; } }
        public string SasKeyForLabel { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public System.Uri TrackingUri { get { throw null; } }
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
    public partial class TenantResourceGetOrderItemsByResourceGroupOptions
    {
        public TenantResourceGetOrderItemsByResourceGroupOptions(System.Guid subscriptionId, string resourceGroupName) { }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
        public System.Guid SubscriptionId { get { throw null; } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class TermCommitmentInformation
    {
        internal TermCommitmentInformation() { }
        public int? PendingDaysForTerm { get { throw null; } }
        public Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType TermCommitmentType { get { throw null; } }
        public System.TimeSpan? TermCommitmentTypeDuration { get { throw null; } }
    }
    public partial class TermCommitmentPreferences
    {
        public TermCommitmentPreferences(Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType preferredTermCommitmentType) { }
        public System.TimeSpan? PreferredTermCommitmentDuration { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType PreferredTermCommitmentType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TermCommitmentType : System.IEquatable<Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TermCommitmentType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType None { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType Timed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType Trial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType left, Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType left, Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TermTypeDetails
    {
        internal TermTypeDetails() { }
        public Azure.ResourceManager.EdgeOrder.Models.TermCommitmentType TermType { get { throw null; } }
        public System.TimeSpan TermTypeDuration { get { throw null; } }
    }
    public partial class TimeServerConfigurationProperties
    {
        public TimeServerConfigurationProperties(string timezone, string ntpConfigurationChoice) { }
        public string NtpConfigurationChoice { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOrder.Models.NtpServerConfiguration NtpServerConfiguration { get { throw null; } set { } }
        public string Timezone { get { throw null; } set { } }
    }
    public partial class TokenResult
    {
        internal TokenResult() { }
        public string Token { get { throw null; } }
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
    public partial class UploadArtifactsContent
    {
        public UploadArtifactsContent(string inventoryDetails, string serialNumber) { }
        public string InventoryDetails { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    public partial class UploadArtifactsResult
    {
        internal UploadArtifactsResult() { }
        public string DeviceUniqueCode { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
}
