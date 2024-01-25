namespace Azure.ResourceManager.NetworkAnalytics
{
    public partial class DataProductCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkAnalytics.DataProductResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.DataProductResource>, System.Collections.IEnumerable
    {
        protected DataProductCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkAnalytics.DataProductResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataProductName, Azure.ResourceManager.NetworkAnalytics.DataProductData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataProductName, Azure.ResourceManager.NetworkAnalytics.DataProductData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> Get(string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkAnalytics.DataProductResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkAnalytics.DataProductResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> GetAsync(string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkAnalytics.DataProductResource> GetIfExists(string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> GetIfExistsAsync(string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkAnalytics.DataProductResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkAnalytics.DataProductResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkAnalytics.DataProductResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.DataProductResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataProductData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.DataProductData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.DataProductData>
    {
        public DataProductData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<string> AvailableMinorVersions { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties ConsumptionEndpoints { get { throw null; } }
        public string CurrentMinorVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails CustomerEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState? CustomerManagedKeyEncryptionEnabled { get { throw null; } set { } }
        public string Documentation { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } }
        public string MajorVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls Networkacls { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Owners { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState? PrivateLinksEnabled { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState? PublicNetworkAccess { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string PurviewAccount { get { throw null; } set { } }
        public string PurviewCollection { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState? Redundancy { get { throw null; } set { } }
        public string ResourceGuid { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.DataProductData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.DataProductData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.DataProductData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.DataProductData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.DataProductData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.DataProductData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.DataProductData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProductResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataProductResource() { }
        public virtual Azure.ResourceManager.NetworkAnalytics.DataProductData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail> AddUserRole(Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail>> AddUserRoleAsync(Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dataProductName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken> GenerateStorageAccountSasToken(Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken>> GenerateStorageAccountSasTokenAsync(Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType> GetDataTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType> GetDataTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult> GetRolesAssignments(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult>> GetRolesAssignmentsAsync(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveUserRole(Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveUserRoleAsync(Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RotateKey(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RotateKeyAsync(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkAnalytics.DataProductResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataProductsCatalogData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData>
    {
        public DataProductsCatalogData() { }
        public Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation> Publishers { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProductsCatalogResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataProductsCatalogResource() { }
        public virtual Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NetworkAnalyticsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> GetDataProduct(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> GetDataProductAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.DataProductResource GetDataProductResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.DataProductCollection GetDataProducts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkAnalytics.DataProductResource> GetDataProducts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkAnalytics.DataProductResource> GetDataProductsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource GetDataProductsCatalog(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource GetDataProductsCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource> GetDataProductsCatalogs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource> GetDataProductsCatalogsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkAnalytics.Mocking
{
    public partial class MockableNetworkAnalyticsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkAnalyticsArmClient() { }
        public virtual Azure.ResourceManager.NetworkAnalytics.DataProductResource GetDataProductResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource GetDataProductsCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNetworkAnalyticsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkAnalyticsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> GetDataProduct(string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> GetDataProductAsync(string dataProductName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkAnalytics.DataProductCollection GetDataProducts() { throw null; }
        public virtual Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource GetDataProductsCatalog() { throw null; }
    }
    public partial class MockableNetworkAnalyticsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkAnalyticsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkAnalytics.DataProductResource> GetDataProducts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkAnalytics.DataProductResource> GetDataProductsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource> GetDataProductsCatalogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogResource> GetDataProductsCatalogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkAnalytics.Models
{
    public partial class AccountSasContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent>
    {
        public AccountSasContent(System.DateTimeOffset startTimeStamp, System.DateTimeOffset expiryTimeStamp, string ipAddress) { }
        public System.DateTimeOffset ExpiryTimeStamp { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public System.DateTimeOffset StartTimeStamp { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountSasToken : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken>
    {
        internal AccountSasToken() { }
        public string StorageAccountSasToken { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmNetworkAnalyticsModelFactory
    {
        public static Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken AccountSasToken(string storageAccountSasToken = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties ConsumptionEndpointsProperties(System.Uri ingestionUri = null, Azure.Core.ResourceIdentifier ingestionResourceId = null, System.Uri fileAccessUri = null, Azure.Core.ResourceIdentifier fileAccessResourceId = null, System.Uri queryUri = null, Azure.Core.ResourceIdentifier queryResourceId = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.DataProductData DataProductData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string resourceGuid = null, Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState?), string publisher = null, string product = null, string majorVersion = null, System.Collections.Generic.IEnumerable<string> owners = null, Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState? redundancy = default(Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState?), string purviewAccount = null, string purviewCollection = null, Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState? privateLinksEnabled = default(Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState?), Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState? publicNetworkAccess = default(Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState?), Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState? customerManagedKeyEncryptionEnabled = default(Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState?), Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails customerEncryptionKey = null, Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls networkacls = null, Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, System.Collections.Generic.IEnumerable<string> availableMinorVersions = null, string currentMinorVersion = null, string documentation = null, Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties consumptionEndpoints = null, System.Uri keyVaultUri = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType DataProductDataType(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState?), Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState? state = default(Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState?), string stateReason = null, int? storageOutputRetention = default(int?), int? databaseCacheRetention = default(int?), int? databaseRetention = default(int?), System.Uri visualizationUri = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData DataProductsCatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation> publishers = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult RoleAssignmentListResult(int count = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail> roleAssignmentResponse = null) { throw null; }
    }
    public partial class ConsumptionEndpointsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties>
    {
        internal ConsumptionEndpointsProperties() { }
        public Azure.Core.ResourceIdentifier FileAccessResourceId { get { throw null; } }
        public System.Uri FileAccessUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier IngestionResourceId { get { throw null; } }
        public System.Uri IngestionUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier QueryResourceId { get { throw null; } }
        public System.Uri QueryUri { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProductControlState : System.IEquatable<Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProductControlState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState left, Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState left, Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataProductDataType : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType>
    {
        public DataProductDataType() { }
        public int? DatabaseCacheRetention { get { throw null; } set { } }
        public int? DatabaseRetention { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState? State { get { throw null; } set { } }
        public string StateReason { get { throw null; } }
        public int? StorageOutputRetention { get { throw null; } set { } }
        public System.Uri VisualizationUri { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProductDataTypeState : System.IEquatable<Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProductDataTypeState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState Running { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState left, Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState left, Azure.ResourceManager.NetworkAnalytics.Models.DataProductDataTypeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataProductInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation>
    {
        public DataProductInformation(string dataProductName, string description, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion> dataProductVersions) { }
        public string DataProductName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion> DataProductVersions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProductNetworkAcls : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls>
    {
        public DataProductNetworkAcls(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule> virtualNetworkRule, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules> ipRules, System.Collections.Generic.IEnumerable<string> allowedQueryIPRangeList, Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction defaultAction) { }
        public System.Collections.Generic.IList<string> AllowedQueryIPRangeList { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule> VirtualNetworkRule { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataProductPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch>
    {
        public DataProductPatch() { }
        public string CurrentMinorVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Owners { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductControlState? PrivateLinksEnabled { get { throw null; } set { } }
        public string PurviewAccount { get { throw null; } set { } }
        public string PurviewCollection { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProductUserRole : System.IEquatable<Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProductUserRole(string value) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole Reader { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole SensitiveReader { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole left, Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole left, Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataProductVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion>
    {
        public DataProductVersion(string version) { }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptionKeyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails>
    {
        public EncryptionKeyDetails(System.Uri keyVaultUri, string keyName, string keyVersion) { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkAclDefaultAction : System.IEquatable<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAclDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction left, Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction left, Azure.ResourceManager.NetworkAnalytics.Models.NetworkAclDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkAnalyticsIPRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules>
    {
        public NetworkAnalyticsIPRules(string action) { }
        public string Action { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsIPRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkAnalyticsKeyVaultContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent>
    {
        public NetworkAnalyticsKeyVaultContent(System.Uri keyVaultUri) { }
        public System.Uri KeyVaultUri { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsKeyVaultContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkAnalyticsManagedResourceGroupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration>
    {
        public NetworkAnalyticsManagedResourceGroupConfiguration(string name, Azure.Core.AzureLocation location) { }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsManagedResourceGroupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkAnalyticsProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAnalyticsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState left, Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState left, Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkAnalyticsVirtualNetworkRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule>
    {
        public NetworkAnalyticsVirtualNetworkRule(string id) { }
        public string Action { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.NetworkAnalyticsVirtualNetworkRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublisherInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation>
    {
        public PublisherInformation(string publisherName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation> dataProducts) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation> DataProducts { get { throw null; } }
        public string PublisherName { get { throw null; } set { } }
        Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentCommonProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties>
    {
        public RoleAssignmentCommonProperties(string roleId, string principalId, string userName, System.Collections.Generic.IEnumerable<string> dataTypeScope, string principalType, Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole role) { }
        public System.Collections.Generic.IList<string> DataTypeScope { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string PrincipalType { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole Role { get { throw null; } }
        public string RoleId { get { throw null; } }
        public string UserName { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentCommonProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail>
    {
        public RoleAssignmentDetail(string roleId, string principalId, string userName, System.Collections.Generic.IEnumerable<string> dataTypeScope, string principalType, Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole role, string roleAssignmentId) { }
        public System.Collections.Generic.IList<string> DataTypeScope { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole Role { get { throw null; } set { } }
        public string RoleAssignmentId { get { throw null; } set { } }
        public string RoleId { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult>
    {
        internal RoleAssignmentListResult() { }
        public int Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail> RoleAssignmentResponse { get { throw null; } }
        Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
