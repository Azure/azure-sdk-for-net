namespace Azure.ResourceManager.Search
{
    public partial class AzureResourceManagerSearchContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSearchContext() { }
        public static Azure.ResourceManager.Search.AzureResourceManagerSearchContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource>, System.Collections.IEnumerable
    {
        protected NetworkSecurityPerimeterConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource> Get(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource>> GetAsync(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource> GetIfExists(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>
    {
        public NetworkSecurityPerimeterConfigurationData() { }
        public Azure.ResourceManager.Search.Models.NspConfigPerimeter NetworkSecurityPerimeter { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.NspConfigProfile Profile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.NspProvisioningIssue> ProvisioningIssues { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Search.Models.NspConfigAssociation ResourceAssociation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkSecurityPerimeterConfigurationResource() { }
        public virtual Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName, string nspConfigName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reconcile(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReconcileAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SearchExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult> CheckSearchServiceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>> CheckSearchServiceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource GetNetworkSecurityPerimeterConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion> GetOfferings(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion> GetOfferingsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource GetSearchPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> GetSearchService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetSearchServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceResource GetSearchServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceCollection GetSearchServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource GetSharedSearchServicePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Search.Models.QuotaUsageResult> GetUsagesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Search.Models.QuotaUsageResult> GetUsagesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Search.Models.QuotaUsageResult> UsageBySubscriptionSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string skuName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.QuotaUsageResult>> UsageBySubscriptionSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string skuName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected SearchPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetAll(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetAllAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SearchPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>
    {
        public SearchPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SearchPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> Get(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SearchServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchServiceResource>, System.Collections.IEnumerable
    {
        protected SearchServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string searchServiceName, Azure.ResourceManager.Search.SearchServiceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string searchServiceName, Azure.ResourceManager.Search.SearchServiceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> Get(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SearchServiceResource> GetAll(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SearchServiceResource> GetAllAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetAsync(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Search.SearchServiceResource> GetIfExists(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Search.SearchServiceResource>> GetIfExistsAsync(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SearchServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SearchServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SearchServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>
    {
        public SearchServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions AuthOptions { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceComputeType? ComputeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption> DisabledDataExfiltrationOptions { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk EncryptionWithCmk { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceHostingMode? HostingMode { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchServiceIPRule> IPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public bool? IsUpgradeAvailable { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public int? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess? PublicInternetAccess { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceSkuName? SearchSkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchSemanticSearch? SemanticSearch { get { throw null; } set { } }
        public System.DateTimeOffset? ServiceUpgradeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Search.Models.SearchSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SearchServiceResource() { }
        public virtual Azure.ResourceManager.Search.SearchServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceQueryKey> CreateQueryKey(string name, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>> CreateQueryKeyAsync(string name, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteQueryKey(string key, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueryKeyAsync(string key, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> Get(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult> GetAdminKey(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>> GetAdminKeyAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource> GetNetworkSecurityPerimeterConfiguration(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource>> GetNetworkSecurityPerimeterConfigurationAsync(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationCollection GetNetworkSecurityPerimeterConfigurations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.SearchServiceQueryKey> GetQueryKeysBySearchService(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.SearchServiceQueryKey> GetQueryKeysBySearchServiceAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetSearchPrivateEndpointConnection(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetSearchPrivateEndpointConnectionAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchPrivateEndpointConnectionCollection GetSearchPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> GetSharedSearchServicePrivateLinkResource(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> GetSharedSearchServicePrivateLinkResourceAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceCollection GetSharedSearchServicePrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource> GetSupportedPrivateLinkResources(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource> GetSupportedPrivateLinkResourcesAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult> RegenerateAdminKey(Azure.ResourceManager.Search.Models.SearchServiceAdminKeyKind keyKind, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>> RegenerateAdminKeyAsync(Azure.ResourceManager.Search.Models.SearchServiceAdminKeyKind keyKind, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Search.SearchServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> Update(Azure.ResourceManager.Search.Models.SearchServicePatch patch, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> UpdateAsync(Azure.ResourceManager.Search.Models.SearchServicePatch patch, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchServiceResource> Upgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SearchServiceResource>> UpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedSearchServicePrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedSearchServicePrivateLinkResource() { }
        public virtual Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> Get(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> GetAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedSearchServicePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected SharedSearchServicePrivateLinkResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData data, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> Get(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> GetAll(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> GetAllAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> GetIfExists(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>> GetIfExistsAsync(string sharedPrivateLinkResourceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedSearchServicePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>
    {
        public SharedSearchServicePrivateLinkResourceData() { }
        public Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Search.Mocking
{
    public partial class MockableSearchArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSearchArmClient() { }
        public virtual Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationResource GetNetworkSecurityPerimeterConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource GetSearchPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchServiceResource GetSearchServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResource GetSharedSearchServicePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSearchResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSearchResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> GetSearchService(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetSearchServiceAsync(string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchServiceCollection GetSearchServices() { throw null; }
    }
    public partial class MockableSearchSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSearchSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult> CheckSearchServiceNameAvailability(Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>> CheckSearchServiceNameAvailabilityAsync(Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServices(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SearchServiceResource> GetSearchServicesAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.QuotaUsageResult> GetUsagesBySubscription(Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.QuotaUsageResult> GetUsagesBySubscriptionAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.Models.QuotaUsageResult> UsageBySubscriptionSku(Azure.Core.AzureLocation location, string skuName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.QuotaUsageResult>> UsageBySubscriptionSkuAsync(Azure.Core.AzureLocation location, string skuName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSearchTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSearchTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion> GetOfferings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion> GetOfferingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Search.Models
{
    public static partial class ArmSearchModelFactory
    {
        public static Azure.ResourceManager.Search.NetworkSecurityPerimeterConfigurationData NetworkSecurityPerimeterConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, Azure.ResourceManager.Search.Models.NspConfigPerimeter networkSecurityPerimeter = null, Azure.ResourceManager.Search.Models.NspConfigAssociation resourceAssociation = null, Azure.ResourceManager.Search.Models.NspConfigProfile profile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.NspProvisioningIssue> provisioningIssues = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.QuotaUsageResult QuotaUsageResult(Azure.Core.ResourceIdentifier id = null, string unit = null, int? currentValue = default(int?), int? limit = default(int?), Azure.ResourceManager.Search.Models.QuotaUsageResultName name = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.QuotaUsageResultName QuotaUsageResultName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk SearchEncryptionWithCmk(Azure.ResourceManager.Search.Models.SearchEncryptionWithCmkEnforcement? enforcement = default(Azure.ResourceManager.Search.Models.SearchEncryptionWithCmkEnforcement?), Azure.ResourceManager.Search.Models.SearchEncryptionComplianceStatus? encryptionComplianceStatus = default(Azure.ResourceManager.Search.Models.SearchEncryptionComplianceStatus?)) { throw null; }
        public static Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData SearchPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkResource SearchPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties SearchPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType> shareablePrivateLinkResourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult SearchServiceAdminKeyResult(string primaryKey = null, string secondaryKey = null) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceData SearchServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchServiceSkuName? searchSkuName = default(Azure.ResourceManager.Search.Models.SearchServiceSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), System.Uri endpoint = null, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType = default(Azure.ResourceManager.Search.Models.SearchServiceComputeType?), Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess? publicInternetAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet networkRuleSet = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption> disabledDataExfiltrationOptions = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null, Azure.ETag? eTag = default(Azure.ETag?), bool? isUpgradeAvailable = default(bool?), System.DateTimeOffset? serviceUpgradeOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Search.SearchServiceData SearchServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchSkuName? skuName = default(Azure.ResourceManager.Search.Models.SearchSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceData SearchServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchSkuName? skuName = default(Azure.ResourceManager.Search.Models.SearchSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), System.Uri endpoint = null, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType = default(Azure.ResourceManager.Search.Models.SearchServiceComputeType?), Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption> disabledDataExfiltrationOptions = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null, bool? upgradeAvailable = default(bool?), System.DateTimeOffset? serviceUpgradeOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering SearchServiceFeatureOffering(Azure.ResourceManager.Search.Models.SearchServiceFeatureName? name = default(Azure.ResourceManager.Search.Models.SearchServiceFeatureName?)) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent SearchServiceNameAvailabilityContent(string name = null, Azure.ResourceManager.Search.Models.SearchServiceResourceType resourceType = default(Azure.ResourceManager.Search.Models.SearchServiceResourceType)) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult SearchServiceNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason? reason = default(Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion SearchServiceOfferingsByRegion(string regionName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering> features = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceSkuOffering> skus = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServicePatch SearchServicePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchServiceSkuName? searchSkuName = default(Azure.ResourceManager.Search.Models.SearchServiceSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), System.Uri endpoint = null, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType = default(Azure.ResourceManager.Search.Models.SearchServiceComputeType?), Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess? publicInternetAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet networkRuleSet = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption> disabledDataExfiltrationOptions = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null, Azure.ETag? eTag = default(Azure.ETag?), bool? isUpgradeAvailable = default(bool?), System.DateTimeOffset? serviceUpgradeOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Search.Models.SearchServicePatch SearchServicePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchSkuName? skuName = default(Azure.ResourceManager.Search.Models.SearchSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServicePatch SearchServicePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchSkuName? skuName = default(Azure.ResourceManager.Search.Models.SearchSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), System.Uri endpoint = null, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType = default(Azure.ResourceManager.Search.Models.SearchServiceComputeType?), Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption> disabledDataExfiltrationOptions = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null, bool? upgradeAvailable = default(bool?), System.DateTimeOffset? serviceUpgradeOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceQueryKey SearchServiceQueryKey(string name = null, string key = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceSkuOffering SearchServiceSkuOffering(Azure.ResourceManager.Search.Models.SearchServiceSkuName? skuName = default(Azure.ResourceManager.Search.Models.SearchServiceSkuName?), Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits limits = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits SearchServiceSkuOfferingLimits(int? indexes = default(int?), int? indexers = default(int?), float? partitionStorageInGigabytes = default(float?), float? partitionVectorStorageInGigabytes = default(float?), int? searchUnits = default(int?), int? replicas = default(int?), int? partitions = default(int?)) { throw null; }
        public static Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties ShareableSearchServicePrivateLinkResourceProperties(string shareablePrivateLinkResourcePropertiesType = null, string groupId = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType ShareableSearchServicePrivateLinkResourceType(string name = null, Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData SharedSearchServicePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties properties = null) { throw null; }
    }
    public partial class NspConfigAccessRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigAccessRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAccessRule>
    {
        public NspConfigAccessRule() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigAccessRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigAccessRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigAccessRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigAccessRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAccessRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAccessRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAccessRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NspConfigAccessRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties>
    {
        public NspConfigAccessRuleProperties() { }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public string Direction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FullyQualifiedDomainNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule> NetworkSecurityPerimeters { get { throw null; } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAccessRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NspConfigAssociation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigAssociation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAssociation>
    {
        public NspConfigAssociation() { }
        public string AccessMode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigAssociation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigAssociation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigAssociation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigAssociation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAssociation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAssociation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigAssociation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NspConfigNetworkSecurityPerimeterRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule>
    {
        public NspConfigNetworkSecurityPerimeterRule() { }
        public string Id { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string PerimeterGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigNetworkSecurityPerimeterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NspConfigPerimeter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigPerimeter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigPerimeter>
    {
        public NspConfigPerimeter() { }
        public string Id { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string PerimeterGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigPerimeter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigPerimeter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigPerimeter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigPerimeter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigPerimeter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigPerimeter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigPerimeter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NspConfigProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigProfile>
    {
        public NspConfigProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.NspConfigAccessRule> AccessRules { get { throw null; } }
        public string AccessRulesVersion { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspConfigProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspConfigProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspConfigProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NspProvisioningIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspProvisioningIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspProvisioningIssue>
    {
        public NspProvisioningIssue() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspProvisioningIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspProvisioningIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspProvisioningIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspProvisioningIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspProvisioningIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspProvisioningIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspProvisioningIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NspProvisioningIssueProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties>
    {
        public NspProvisioningIssueProperties() { }
        public string Description { get { throw null; } set { } }
        public string IssueType { get { throw null; } set { } }
        public string Severity { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SuggestedAccessRules { get { throw null; } }
        public System.Collections.Generic.IList<string> SuggestedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.NspProvisioningIssueProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaUsageResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>
    {
        internal QuotaUsageResult() { }
        public int? CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Search.Models.QuotaUsageResultName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.QuotaUsageResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.QuotaUsageResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaUsageResultName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>
    {
        internal QuotaUsageResultName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.QuotaUsageResultName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.QuotaUsageResultName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.QuotaUsageResultName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchAadAuthDataPlaneAuthOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>
    {
        public SearchAadAuthDataPlaneAuthOptions() { }
        public Azure.ResourceManager.Search.Models.SearchAadAuthFailureMode? AadAuthFailureMode { get { throw null; } set { } }
        public System.BinaryData ApiKeyOnly { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SearchAadAuthFailureMode
    {
        Http403 = 0,
        Http401WithBearerChallenge = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchBypass : System.IEquatable<Azure.ResourceManager.Search.Models.SearchBypass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchBypass(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchBypass AzurePortal { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchBypass AzureServices { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchBypass None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchBypass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchBypass left, Azure.ResourceManager.Search.Models.SearchBypass right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchBypass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchBypass left, Azure.ResourceManager.Search.Models.SearchBypass right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchDisabledDataExfiltrationOption : System.IEquatable<Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchDisabledDataExfiltrationOption(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption All { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption left, Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption left, Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SearchEncryptionComplianceStatus
    {
        Compliant = 0,
        NonCompliant = 1,
    }
    public partial class SearchEncryptionWithCmk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>
    {
        public SearchEncryptionWithCmk() { }
        public Azure.ResourceManager.Search.Models.SearchEncryptionComplianceStatus? EncryptionComplianceStatus { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchEncryptionWithCmkEnforcement? Enforcement { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SearchEncryptionWithCmkEnforcement
    {
        Unspecified = 0,
        Disabled = 1,
        Enabled = 2,
    }
    public partial class SearchManagementRequestOptions
    {
        public SearchManagementRequestOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
    }
    public partial class SearchPrivateLinkResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>
    {
        public SearchPrivateLinkResource() { }
        public Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchPrivateLinkResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchPrivateLinkResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>
    {
        internal SearchPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType> ShareablePrivateLinkResourceTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchPrivateLinkServiceConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchPrivateLinkServiceConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Incomplete { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState left, Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState left, Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchSemanticSearch : System.IEquatable<Azure.ResourceManager.Search.Models.SearchSemanticSearch>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchSemanticSearch(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchSemanticSearch Disabled { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchSemanticSearch Free { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchSemanticSearch Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchSemanticSearch other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchSemanticSearch left, Azure.ResourceManager.Search.Models.SearchSemanticSearch right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchSemanticSearch (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchSemanticSearch left, Azure.ResourceManager.Search.Models.SearchSemanticSearch right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SearchServiceAdminKeyKind
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class SearchServiceAdminKeyResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>
    {
        internal SearchServiceAdminKeyResult() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceComputeType : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceComputeType(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceComputeType Confidential { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceComputeType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceComputeType left, Azure.ResourceManager.Search.Models.SearchServiceComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceComputeType left, Azure.ResourceManager.Search.Models.SearchServiceComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceFeatureName : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceFeatureName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceFeatureName(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureName AvailabilityZones { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureName DocumentIntelligence { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureName Grok { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureName ImageVectorization { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureName MegaStore { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureName QueryRewrite { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureName S3 { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureName SemanticSearch { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceFeatureName StorageOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceFeatureName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceFeatureName left, Azure.ResourceManager.Search.Models.SearchServiceFeatureName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceFeatureName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceFeatureName left, Azure.ResourceManager.Search.Models.SearchServiceFeatureName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchServiceFeatureOffering : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering>
    {
        internal SearchServiceFeatureOffering() { }
        public Azure.ResourceManager.Search.Models.SearchServiceFeatureName? Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SearchServiceHostingMode
    {
        Default = 0,
        HighDensity = 1,
    }
    public partial class SearchServiceIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>
    {
        public SearchServiceIPRule() { }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>
    {
        public SearchServiceNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>
    {
        internal SearchServiceNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason left, Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason left, Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchServiceNetworkRuleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet>
    {
        public SearchServiceNetworkRuleSet() { }
        public Azure.ResourceManager.Search.Models.SearchBypass? Bypass { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchServiceIPRule> IPRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceOfferingsByRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion>
    {
        internal SearchServiceOfferingsByRegion() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.Models.SearchServiceFeatureOffering> Features { get { throw null; } }
        public string RegionName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.Models.SearchServiceSkuOffering> Skus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceOfferingsByRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServicePatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePatch>
    {
        public SearchServicePatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions AuthOptions { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceComputeType? ComputeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchDisabledDataExfiltrationOption> DisabledDataExfiltrationOptions { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk EncryptionWithCmk { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceHostingMode? HostingMode { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchServiceIPRule> IPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public bool? IsUpgradeAvailable { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public int? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess? PublicInternetAccess { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceSkuName? SearchSkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchSemanticSearch? SemanticSearch { get { throw null; } set { } }
        public System.DateTimeOffset? ServiceUpgradeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Search.Models.SearchSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServicePrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>
    {
        public SearchServicePrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchPrivateLinkServiceConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServicePrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>
    {
        public SearchServicePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SearchServicePrivateLinkServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum SearchServiceProvisioningState
    {
        Succeeded = 0,
        Provisioning = 1,
        Failed = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServicePublicInternetAccess : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServicePublicInternetAccess(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess left, Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess left, Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum SearchServicePublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SearchServiceQueryKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>
    {
        internal SearchServiceQueryKey() { }
        public string Key { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceQueryKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceQueryKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceQueryKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceResourceType : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceResourceType SearchServices { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceResourceType left, Azure.ResourceManager.Search.Models.SearchServiceResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceResourceType left, Azure.ResourceManager.Search.Models.SearchServiceResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceSharedPrivateLinkResourceProvisioningState : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceSharedPrivateLinkResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState Incomplete { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState left, Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState left, Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceSharedPrivateLinkResourceStatus : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceSharedPrivateLinkResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus left, Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus left, Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceSkuName : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSkuName Standard { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSkuName Standard2 { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSkuName Standard3 { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSkuName StorageOptimizedL1 { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceSkuName StorageOptimizedL2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceSkuName left, Azure.ResourceManager.Search.Models.SearchServiceSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceSkuName left, Azure.ResourceManager.Search.Models.SearchServiceSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchServiceSkuOffering : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOffering>
    {
        internal SearchServiceSkuOffering() { }
        public Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits Limits { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceSkuName? SkuName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceSkuOffering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceSkuOffering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOffering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOffering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOffering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceSkuOfferingLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits>
    {
        internal SearchServiceSkuOfferingLimits() { }
        public int? Indexers { get { throw null; } }
        public int? Indexes { get { throw null; } }
        public int? Partitions { get { throw null; } }
        public float? PartitionStorageInGigabytes { get { throw null; } }
        public float? PartitionVectorStorageInGigabytes { get { throw null; } }
        public int? Replicas { get { throw null; } }
        public int? SearchUnits { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceSkuOfferingLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SearchServiceStatus
    {
        Running = 0,
        Provisioning = 1,
        Deleting = 2,
        Degraded = 3,
        Disabled = 4,
        Error = 5,
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum SearchSkuName
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Standard2 = 3,
        Standard3 = 4,
        StorageOptimizedL1 = 5,
        StorageOptimizedL2 = 6,
    }
    public partial class ShareableSearchServicePrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>
    {
        internal ShareableSearchServicePrivateLinkResourceProperties() { }
        public string Description { get { throw null; } }
        public string GroupId { get { throw null; } }
        public string ShareablePrivateLinkResourcePropertiesType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareableSearchServicePrivateLinkResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>
    {
        internal ShareableSearchServicePrivateLinkResourceType() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedSearchServicePrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>
    {
        public SharedSearchServicePrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.Core.AzureLocation? ResourceRegion { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceProvisioningState? SharedPrivateLinkResourceProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceSharedPrivateLinkResourceStatus? SharedPrivateLinkResourceStatus { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum SharedSearchServicePrivateLinkResourceProvisioningState
    {
        Updating = 0,
        Deleting = 1,
        Failed = 2,
        Succeeded = 3,
        Incomplete = 4,
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum SharedSearchServicePrivateLinkResourceStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
}
