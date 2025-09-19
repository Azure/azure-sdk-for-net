namespace Azure.ResourceManager.Search
{
    public partial class AzureResourceManagerSearchContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSearchContext() { }
        public static Azure.ResourceManager.Search.AzureResourceManagerSearchContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class SearchExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult> CheckSearchServiceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult>> CheckSearchServiceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent content, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Search.Models.OfferingsByRegion> GetOfferings(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Search.Models.OfferingsByRegion> GetOfferingsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource GetSearchPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Search.SearchServiceResource> GetSearchService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceResource>> GetSearchServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string searchServiceName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource GetSearchServiceNetworkSecurityPerimeterConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public Azure.ResourceManager.Search.Models.DomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceComputeType? ComputeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection> DataExfiltrationProtections { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk EncryptionWithCmk { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceHostingMode? HostingMode { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchServiceIPRule> IPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable? IsUpgradeAvailable { get { throw null; } set { } }
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
        public System.DateTimeOffset? ServiceUpgradedOn { get { throw null; } }
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
    public partial class SearchServiceNetworkSecurityPerimeterConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource>, System.Collections.IEnumerable
    {
        protected SearchServiceNetworkSecurityPerimeterConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource> Get(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource>> GetAsync(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource> GetIfExists(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SearchServiceNetworkSecurityPerimeterConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>
    {
        public SearchServiceNetworkSecurityPerimeterConfigurationData() { }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceNetworkSecurityPerimeterConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SearchServiceNetworkSecurityPerimeterConfigurationResource() { }
        public virtual Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string searchServiceName, string nspConfigName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reconcile(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReconcileAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.SearchServiceQueryKey> GetQueryKeysBySearchService(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.SearchServiceQueryKey> GetQueryKeysBySearchServiceAsync(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource> GetSearchPrivateEndpointConnection(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource>> GetSearchPrivateEndpointConnectionAsync(string privateEndpointConnectionName, Azure.ResourceManager.Search.Models.SearchManagementRequestOptions searchManagementRequestOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchPrivateEndpointConnectionCollection GetSearchPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource> GetSearchServiceNetworkSecurityPerimeterConfiguration(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource>> GetSearchServiceNetworkSecurityPerimeterConfigurationAsync(string nspConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationCollection GetSearchServiceNetworkSecurityPerimeterConfigurations() { throw null; }
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
        public virtual Azure.ResourceManager.Search.SearchPrivateEndpointConnectionResource GetSearchPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationResource GetSearchServiceNetworkSecurityPerimeterConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Search.Models.OfferingsByRegion> GetOfferings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Search.Models.OfferingsByRegion> GetOfferingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Search.Models
{
    public static partial class ArmSearchModelFactory
    {
        public static Azure.ResourceManager.Search.Models.FeatureOffering FeatureOffering(Azure.ResourceManager.Search.Models.FeatureName? name = default(Azure.ResourceManager.Search.Models.FeatureName?)) { throw null; }
        public static Azure.ResourceManager.Search.Models.OfferingsByRegion OfferingsByRegion(string regionName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.FeatureOffering> features = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SkuOffering> skus = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.QuotaUsageResult QuotaUsageResult(Azure.Core.ResourceIdentifier id = null, string unit = null, int? currentValue = default(int?), int? limit = default(int?), Azure.ResourceManager.Search.Models.QuotaUsageResultName name = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.QuotaUsageResultName QuotaUsageResultName(string value = null, string localizedValue = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk SearchEncryptionWithCmk(Azure.ResourceManager.Search.Models.SearchEncryptionWithCmkEnforcement? enforcement, Azure.ResourceManager.Search.Models.SearchEncryptionComplianceStatus? encryptionComplianceStatus) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk SearchEncryptionWithCmk(Azure.ResourceManager.Search.Models.SearchEncryptionWithCmkEnforcement? enforcement = default(Azure.ResourceManager.Search.Models.SearchEncryptionWithCmkEnforcement?), Azure.ResourceManager.Search.Models.SearchEncryptionComplianceStatus? encryptionComplianceStatus = default(Azure.ResourceManager.Search.Models.SearchEncryptionComplianceStatus?), Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey serviceLevelEncryptionKey = null) { throw null; }
        public static Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData SearchPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SearchServicePrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkResource SearchPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchPrivateLinkResourceProperties SearchPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType> shareablePrivateLinkResourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceAdminKeyResult SearchServiceAdminKeyResult(string primaryKey = null, string secondaryKey = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Search.SearchServiceData SearchServiceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchServiceSkuName? searchSkuName, Azure.ResourceManager.Models.ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, System.Uri endpoint, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode, Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType, Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess? publicInternetAccess, Azure.ResourceManager.Search.Models.SearchServiceStatus? status, string statusDetails, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState, Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet networkRuleSet, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection> dataExfiltrationProtections, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, Azure.ETag? eTag, Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable? isUpgradeAvailable, System.DateTimeOffset? serviceUpgradedOn) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceData SearchServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchServiceSkuName? searchSkuName = default(Azure.ResourceManager.Search.Models.SearchServiceSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), System.Uri endpoint = null, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType = default(Azure.ResourceManager.Search.Models.SearchServiceComputeType?), Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess? publicInternetAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet networkRuleSet = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection> dataExfiltrationProtections = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable? isUpgradeAvailable = default(Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable?), System.DateTimeOffset? serviceUpgradedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Search.Models.DomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.Search.Models.DomainNameLabelScope?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Search.SearchServiceData SearchServiceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchSkuName? skuName, Azure.ResourceManager.Models.ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode, Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Search.Models.SearchServiceStatus? status, string statusDetails, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceData SearchServiceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchSkuName? skuName, Azure.ResourceManager.Models.ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, System.Uri endpoint, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode, Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType, Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Search.Models.SearchServiceStatus? status, string statusDetails, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection> dataExfiltrationProtections, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, bool? upgradeAvailable, System.DateTimeOffset? serviceUpgradeOn) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityContent SearchServiceNameAvailabilityContent(string name = null, Azure.ResourceManager.Search.Models.SearchServiceResourceType resourceType = default(Azure.ResourceManager.Search.Models.SearchServiceResourceType)) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNameAvailabilityResult SearchServiceNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason? reason = default(Azure.ResourceManager.Search.Models.SearchServiceNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Search.SearchServiceNetworkSecurityPerimeterConfigurationData SearchServiceNetworkSecurityPerimeterConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties SearchServiceNetworkSecurityPerimeterConfigurationProperties(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue> provisioningIssues = null, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter networkSecurityPerimeter = null, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation resourceAssociation = null, Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile profile = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue SearchServiceNetworkSecurityPerimeterProvisioningIssue(string name = null, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType? issueType = default(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType?), Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity? severity = default(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity?), string description = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> suggestedResourceIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule> suggestedAccessRules = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Search.Models.SearchServicePatch SearchServicePatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchServiceSkuName? searchSkuName, Azure.ResourceManager.Models.ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, System.Uri endpoint, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode, Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType, Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess? publicInternetAccess, Azure.ResourceManager.Search.Models.SearchServiceStatus? status, string statusDetails, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState, Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet networkRuleSet, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection> dataExfiltrationProtections, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, Azure.ETag? eTag, Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable? isUpgradeAvailable, System.DateTimeOffset? serviceUpgradedOn) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServicePatch SearchServicePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Search.Models.SearchServiceSkuName? searchSkuName = default(Azure.ResourceManager.Search.Models.SearchServiceSkuName?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, int? replicaCount = default(int?), int? partitionCount = default(int?), System.Uri endpoint = null, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode = default(Azure.ResourceManager.Search.Models.SearchServiceHostingMode?), Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType = default(Azure.ResourceManager.Search.Models.SearchServiceComputeType?), Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess? publicInternetAccess = default(Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess?), Azure.ResourceManager.Search.Models.SearchServiceStatus? status = default(Azure.ResourceManager.Search.Models.SearchServiceStatus?), string statusDetails = null, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Search.Models.SearchServiceProvisioningState?), Azure.ResourceManager.Search.Models.SearchServiceNetworkRuleSet networkRuleSet = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection> dataExfiltrationProtections = null, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions = null, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch = default(Azure.ResourceManager.Search.Models.SearchSemanticSearch?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable? isUpgradeAvailable = default(Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable?), System.DateTimeOffset? serviceUpgradedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Search.Models.DomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.Search.Models.DomainNameLabelScope?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Search.Models.SearchServicePatch SearchServicePatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchSkuName? skuName, Azure.ResourceManager.Models.ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode, Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Search.Models.SearchServiceStatus? status, string statusDetails, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServicePatch SearchServicePatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Search.Models.SearchSkuName? skuName, Azure.ResourceManager.Models.ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, System.Uri endpoint, Azure.ResourceManager.Search.Models.SearchServiceHostingMode? hostingMode, Azure.ResourceManager.Search.Models.SearchServiceComputeType? computeType, Azure.ResourceManager.Search.Models.SearchServicePublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Search.Models.SearchServiceStatus? status, string statusDetails, Azure.ResourceManager.Search.Models.SearchServiceProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchServiceIPRule> ipRules, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection> dataExfiltrationProtections, Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions authOptions, Azure.ResourceManager.Search.Models.SearchSemanticSearch? semanticSearch, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SearchPrivateEndpointConnectionData> privateEndpointConnections, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, bool? upgradeAvailable, System.DateTimeOffset? serviceUpgradeOn) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceQueryKey SearchServiceQueryKey(string name = null, string key = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties ShareableSearchServicePrivateLinkResourceProperties(string shareablePrivateLinkResourcePropertiesType = null, string groupId = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceType ShareableSearchServicePrivateLinkResourceType(string name = null, Azure.ResourceManager.Search.Models.ShareableSearchServicePrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.SharedSearchServicePrivateLinkResourceData SharedSearchServicePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Search.Models.SharedSearchServicePrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SkuOffering SkuOffering(Azure.ResourceManager.Search.Models.SearchServiceSkuName? skuName = default(Azure.ResourceManager.Search.Models.SearchServiceSkuName?), Azure.ResourceManager.Search.Models.SkuOfferingLimits limits = null) { throw null; }
        public static Azure.ResourceManager.Search.Models.SkuOfferingLimits SkuOfferingLimits(int? indexes = default(int?), int? indexers = default(int?), float? partitionStorageInGigabytes = default(float?), float? partitionVectorStorageInGigabytes = default(float?), int? searchUnits = default(int?), int? replicas = default(int?), int? partitions = default(int?)) { throw null; }
    }
    public partial class AzureActiveDirectoryApplicationCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials>
    {
        public AzureActiveDirectoryApplicationCredentials() { }
        public string ApplicationId { get { throw null; } set { } }
        public string ApplicationSecret { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.DataIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataIdentity>
    {
        protected DataIdentity() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.DataIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.DataIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.DataIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.DataIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataNoneIdentity : Azure.ResourceManager.Search.Models.DataIdentity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.DataNoneIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataNoneIdentity>
    {
        public DataNoneIdentity() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.DataNoneIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.DataNoneIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.DataNoneIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.DataNoneIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataNoneIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataNoneIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataNoneIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataUserAssignedIdentity : Azure.ResourceManager.Search.Models.DataIdentity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.DataUserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataUserAssignedIdentity>
    {
        public DataUserAssignedIdentity(Azure.Core.ResourceIdentifier userAssignedIdentity) { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.DataUserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.DataUserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.DataUserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.DataUserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataUserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataUserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.DataUserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScope : System.IEquatable<Azure.ResourceManager.Search.Models.DomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.DomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.DomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.DomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.DomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.DomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.DomainNameLabelScope left, Azure.ResourceManager.Search.Models.DomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.DomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.DomainNameLabelScope left, Azure.ResourceManager.Search.Models.DomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureName : System.IEquatable<Azure.ResourceManager.Search.Models.FeatureName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureName(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.FeatureName AvailabilityZones { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.FeatureName DocumentIntelligence { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.FeatureName Grok { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.FeatureName ImageVectorization { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.FeatureName MegaStore { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.FeatureName QueryRewrite { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.FeatureName S3 { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.FeatureName SemanticSearch { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.FeatureName StorageOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.FeatureName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.FeatureName left, Azure.ResourceManager.Search.Models.FeatureName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.FeatureName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.FeatureName left, Azure.ResourceManager.Search.Models.FeatureName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FeatureOffering : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.FeatureOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.FeatureOffering>
    {
        internal FeatureOffering() { }
        public Azure.ResourceManager.Search.Models.FeatureName? Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.FeatureOffering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.FeatureOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.FeatureOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.FeatureOffering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.FeatureOffering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.FeatureOffering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.FeatureOffering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferingsByRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.OfferingsByRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.OfferingsByRegion>
    {
        internal OfferingsByRegion() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.Models.FeatureOffering> Features { get { throw null; } }
        public string RegionName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.Models.SkuOffering> Skus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.OfferingsByRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.OfferingsByRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.OfferingsByRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.OfferingsByRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.OfferingsByRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.OfferingsByRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.OfferingsByRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct SearchDataExfiltrationProtection : System.IEquatable<Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchDataExfiltrationProtection(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection BlockAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection left, Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection left, Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection right) { throw null; }
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
        public Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey ServiceLevelEncryptionKey { get { throw null; } set { } }
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
    public partial class SearchNetworkSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile>
    {
        public SearchNetworkSecurityProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule> AccessRules { get { throw null; } }
        public int? AccessRulesVersion { get { throw null; } set { } }
        public int? DiagnosticSettingsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnabledLogCategories { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SearchResourceEncryptionKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey>
    {
        public SearchResourceEncryptionKey() { }
        public Azure.ResourceManager.Search.Models.AzureActiveDirectoryApplicationCredentials AccessCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.DataIdentity Identity { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchResourceEncryptionKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SearchServiceNetworkSecurityPerimeter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter>
    {
        public SearchServiceNetworkSecurityPerimeter() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Guid? PerimeterGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceNetworkSecurityPerimeterAccessRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule>
    {
        public SearchServiceNetworkSecurityPerimeterAccessRule() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceNetworkSecurityPerimeterAccessRuleDirection : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceNetworkSecurityPerimeterAccessRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchServiceNetworkSecurityPerimeterAccessRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties>
    {
        public SearchServiceNetworkSecurityPerimeterAccessRuleProperties() { }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleDirection? Direction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public System.Collections.Generic.IList<string> FullyQualifiedDomainNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter> NetworkSecurityPerimeters { get { throw null; } }
        public System.Collections.Generic.IList<string> PhoneNumbers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Subscriptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceNetworkSecurityPerimeterConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties>
    {
        public SearchServiceNetworkSecurityPerimeterConfigurationProperties() { }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeter NetworkSecurityPerimeter { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchNetworkSecurityProfile Profile { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue> ProvisioningIssues { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation ResourceAssociation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchServiceNetworkSecurityPerimeterProvisioningIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue>
    {
        internal SearchServiceNetworkSecurityPerimeterProvisioningIssue() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties>
    {
        internal SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType? IssueType { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity? Severity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterAccessRule> SuggestedAccessRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> SuggestedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceNetworkSecurityPerimeterProvisioningIssueType : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceNetworkSecurityPerimeterProvisioningIssueType(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType ConfigurationPropagationFailure { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType MissingIdentityConfiguration { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType MissingPerimeterConfiguration { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterProvisioningIssueType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchServiceNetworkSecurityPerimeterResourceAssociation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation>
    {
        public SearchServiceNetworkSecurityPerimeterResourceAssociation() { }
        public Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode? AccessMode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode Audit { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode Enforced { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode Learning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode left, Azure.ResourceManager.Search.Models.SearchServiceNetworkSecurityPerimeterResourceAssociationAccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchServicePatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SearchServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SearchServicePatch>
    {
        public SearchServicePatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Search.Models.SearchAadAuthDataPlaneAuthOptions AuthOptions { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.DomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceComputeType? ComputeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchDataExfiltrationProtection> DataExfiltrationProtections { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchEncryptionWithCmk EncryptionWithCmk { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceHostingMode? HostingMode { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<Azure.ResourceManager.Search.Models.SearchServiceIPRule> IPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable? IsUpgradeAvailable { get { throw null; } set { } }
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
        public System.DateTimeOffset? ServiceUpgradedOn { get { throw null; } }
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
        public static Azure.ResourceManager.Search.Models.SearchServicePublicInternetAccess SecuredByPerimeter { get { throw null; } }
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
    public enum SearchServiceStatus
    {
        Running = 0,
        Provisioning = 1,
        Deleting = 2,
        Degraded = 3,
        Disabled = 4,
        Error = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SearchServiceUpgradeAvailable : System.IEquatable<Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SearchServiceUpgradeAvailable(string value) { throw null; }
        public static Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable Available { get { throw null; } }
        public static Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable NotAvailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable left, Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable right) { throw null; }
        public static implicit operator Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable left, Azure.ResourceManager.Search.Models.SearchServiceUpgradeAvailable right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class SkuOffering : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SkuOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SkuOffering>
    {
        internal SkuOffering() { }
        public Azure.ResourceManager.Search.Models.SkuOfferingLimits Limits { get { throw null; } }
        public Azure.ResourceManager.Search.Models.SearchServiceSkuName? SkuName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SkuOffering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SkuOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SkuOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SkuOffering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SkuOffering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SkuOffering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SkuOffering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuOfferingLimits : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SkuOfferingLimits>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SkuOfferingLimits>
    {
        internal SkuOfferingLimits() { }
        public int? Indexers { get { throw null; } }
        public int? Indexes { get { throw null; } }
        public int? Partitions { get { throw null; } }
        public float? PartitionStorageInGigabytes { get { throw null; } }
        public float? PartitionVectorStorageInGigabytes { get { throw null; } }
        public int? Replicas { get { throw null; } }
        public int? SearchUnits { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SkuOfferingLimits System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SkuOfferingLimits>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Search.Models.SkuOfferingLimits>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Search.Models.SkuOfferingLimits System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SkuOfferingLimits>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SkuOfferingLimits>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Search.Models.SkuOfferingLimits>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
