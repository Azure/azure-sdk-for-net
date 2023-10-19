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
    public partial class DataProductData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataProductData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<string> AvailableMinorVersions { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties ConsumptionEndpoints { get { throw null; } }
        public string CurrentMinorVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails CustomerEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ControlState? CustomerManagedKeyEncryptionEnabled { get { throw null; } set { } }
        public string Documentation { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } }
        public string MajorVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls Networkacls { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Owners { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ControlState? PrivateLinksEnabled { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ControlState? PublicNetworkAccess { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string PurviewAccount { get { throw null; } set { } }
        public string PurviewCollection { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ControlState? Redundancy { get { throw null; } set { } }
        public string ResourceGuid { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken> GenerateStorageAccountSasToken(Azure.ResourceManager.NetworkAnalytics.Models.AccountSas body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken>> GenerateStorageAccountSasTokenAsync(Azure.ResourceManager.NetworkAnalytics.Models.AccountSas body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkAnalytics.Models.DataType> GetDataTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkAnalytics.Models.DataType> GetDataTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.ListRoleAssignments> GetRolesAssignments(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.Models.ListRoleAssignments>> GetRolesAssignmentsAsync(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveUserRole(Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveUserRoleAsync(Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RotateKey(Azure.ResourceManager.NetworkAnalytics.Models.KeyVaultContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RotateKeyAsync(Azure.ResourceManager.NetworkAnalytics.Models.KeyVaultContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkAnalytics.DataProductResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkAnalytics.DataProductResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkAnalytics.Models.DataProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataProductsCatalogData : Azure.ResourceManager.Models.ResourceData
    {
        public DataProductsCatalogData() { }
        public Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation> Publishers { get { throw null; } }
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
namespace Azure.ResourceManager.NetworkAnalytics.Models
{
    public partial class AccountSas
    {
        public AccountSas(System.DateTimeOffset startTimeStamp, System.DateTimeOffset expiryTimeStamp, string ipAddress) { }
        public System.DateTimeOffset ExpiryTimeStamp { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public System.DateTimeOffset StartTimeStamp { get { throw null; } }
    }
    public partial class AccountSasToken
    {
        internal AccountSasToken() { }
        public string StorageAccountSasToken { get { throw null; } }
    }
    public static partial class ArmNetworkAnalyticsModelFactory
    {
        public static Azure.ResourceManager.NetworkAnalytics.Models.AccountSasToken AccountSasToken(string storageAccountSasToken = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties ConsumptionEndpointsProperties(System.Uri ingestionUri = null, Azure.Core.ResourceIdentifier ingestionResourceId = null, System.Uri fileAccessUri = null, Azure.Core.ResourceIdentifier fileAccessResourceId = null, System.Uri queryUri = null, Azure.Core.ResourceIdentifier queryResourceId = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.DataProductData DataProductData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string resourceGuid = null, Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState?), string publisher = null, string product = null, string majorVersion = null, System.Collections.Generic.IEnumerable<string> owners = null, Azure.ResourceManager.NetworkAnalytics.Models.ControlState? redundancy = default(Azure.ResourceManager.NetworkAnalytics.Models.ControlState?), string purviewAccount = null, string purviewCollection = null, Azure.ResourceManager.NetworkAnalytics.Models.ControlState? privateLinksEnabled = default(Azure.ResourceManager.NetworkAnalytics.Models.ControlState?), Azure.ResourceManager.NetworkAnalytics.Models.ControlState? publicNetworkAccess = default(Azure.ResourceManager.NetworkAnalytics.Models.ControlState?), Azure.ResourceManager.NetworkAnalytics.Models.ControlState? customerManagedKeyEncryptionEnabled = default(Azure.ResourceManager.NetworkAnalytics.Models.ControlState?), Azure.ResourceManager.NetworkAnalytics.Models.EncryptionKeyDetails customerEncryptionKey = null, Azure.ResourceManager.NetworkAnalytics.Models.DataProductNetworkAcls networkacls = null, Azure.ResourceManager.NetworkAnalytics.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, System.Collections.Generic.IEnumerable<string> availableMinorVersions = null, string currentMinorVersion = null, string documentation = null, Azure.ResourceManager.NetworkAnalytics.Models.ConsumptionEndpointsProperties consumptionEndpoints = null, System.Uri keyVaultUri = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.DataProductsCatalogData DataProductsCatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.PublisherInformation> publishers = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataType DataType(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState?), Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState? state = default(Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState?), string stateReason = null, int? storageOutputRetention = default(int?), int? databaseCacheRetention = default(int?), int? databaseRetention = default(int?), System.Uri visualizationUri = null) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ListRoleAssignments ListRoleAssignments(int count = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail> roleAssignmentResponse = null) { throw null; }
    }
    public partial class ConsumptionEndpointsProperties
    {
        internal ConsumptionEndpointsProperties() { }
        public Azure.Core.ResourceIdentifier FileAccessResourceId { get { throw null; } }
        public System.Uri FileAccessUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier IngestionResourceId { get { throw null; } }
        public System.Uri IngestionUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier QueryResourceId { get { throw null; } }
        public System.Uri QueryUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ControlState : System.IEquatable<Azure.ResourceManager.NetworkAnalytics.Models.ControlState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ControlState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ControlState Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ControlState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkAnalytics.Models.ControlState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkAnalytics.Models.ControlState left, Azure.ResourceManager.NetworkAnalytics.Models.ControlState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkAnalytics.Models.ControlState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkAnalytics.Models.ControlState left, Azure.ResourceManager.NetworkAnalytics.Models.ControlState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataProductInformation
    {
        public DataProductInformation(string dataProductName, string description, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion> dataProductVersions) { }
        public string DataProductName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.DataProductVersion> DataProductVersions { get { throw null; } }
        public string Description { get { throw null; } set { } }
    }
    public partial class DataProductNetworkAcls
    {
        public DataProductNetworkAcls(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.VirtualNetworkRule> virtualNetworkRule, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.IPRules> ipRules, System.Collections.Generic.IEnumerable<string> allowedQueryIPRangeList, Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction defaultAction) { }
        public System.Collections.Generic.IList<string> AllowedQueryIPRangeList { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.IPRules> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.VirtualNetworkRule> VirtualNetworkRule { get { throw null; } }
    }
    public partial class DataProductPatch
    {
        public DataProductPatch() { }
        public string CurrentMinorVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Owners { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ControlState? PrivateLinksEnabled { get { throw null; } set { } }
        public string PurviewAccount { get { throw null; } set { } }
        public string PurviewCollection { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class DataProductVersion
    {
        public DataProductVersion(string version) { }
        public string Version { get { throw null; } set { } }
    }
    public partial class DataType : Azure.ResourceManager.Models.ResourceData
    {
        public DataType() { }
        public int? DatabaseCacheRetention { get { throw null; } set { } }
        public int? DatabaseRetention { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState? State { get { throw null; } set { } }
        public string StateReason { get { throw null; } }
        public int? StorageOutputRetention { get { throw null; } set { } }
        public System.Uri VisualizationUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataTypeState : System.IEquatable<Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataTypeState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState Running { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState left, Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState left, Azure.ResourceManager.NetworkAnalytics.Models.DataTypeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultAction : System.IEquatable<Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction left, Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction left, Azure.ResourceManager.NetworkAnalytics.Models.DefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionKeyDetails
    {
        public EncryptionKeyDetails(System.Uri keyVaultUri, string keyName, string keyVersion) { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    public partial class IPRules
    {
        public IPRules(string action) { }
        public string Action { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class KeyVaultContent
    {
        public KeyVaultContent(System.Uri keyVaultUri) { }
        public System.Uri KeyVaultUri { get { throw null; } }
    }
    public partial class ListRoleAssignments
    {
        internal ListRoleAssignments() { }
        public int Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkAnalytics.Models.RoleAssignmentDetail> RoleAssignmentResponse { get { throw null; } }
    }
    public partial class ManagedResourceGroupConfiguration
    {
        public ManagedResourceGroupConfiguration(string name, Azure.Core.AzureLocation location) { }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState left, Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState left, Azure.ResourceManager.NetworkAnalytics.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PublisherInformation
    {
        public PublisherInformation(string publisherName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation> dataProducts) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkAnalytics.Models.DataProductInformation> DataProducts { get { throw null; } }
        public string PublisherName { get { throw null; } set { } }
    }
    public partial class RoleAssignmentCommonProperties
    {
        public RoleAssignmentCommonProperties(string roleId, string principalId, string userName, System.Collections.Generic.IEnumerable<string> dataTypeScope, string principalType, Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole role) { }
        public System.Collections.Generic.IList<string> DataTypeScope { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string PrincipalType { get { throw null; } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole Role { get { throw null; } }
        public string RoleId { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class RoleAssignmentDetail
    {
        public RoleAssignmentDetail(string roleId, string principalId, string userName, System.Collections.Generic.IEnumerable<string> dataTypeScope, string principalType, Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole role, string roleAssignmentId) { }
        public System.Collections.Generic.IList<string> DataTypeScope { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkAnalytics.Models.DataProductUserRole Role { get { throw null; } set { } }
        public string RoleAssignmentId { get { throw null; } set { } }
        public string RoleId { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class VirtualNetworkRule
    {
        public VirtualNetworkRule(string id) { }
        public string Action { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
}
