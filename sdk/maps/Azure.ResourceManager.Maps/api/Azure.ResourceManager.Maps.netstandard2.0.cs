namespace Azure.ResourceManager.Maps
{
    public partial class CreatorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.CreatorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.CreatorResource>, System.Collections.IEnumerable
    {
        protected CreatorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.CreatorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string creatorName, Azure.ResourceManager.Maps.CreatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.CreatorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string creatorName, Azure.ResourceManager.Maps.CreatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.CreatorResource> Get(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maps.CreatorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maps.CreatorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.CreatorResource>> GetAsync(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maps.CreatorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.CreatorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maps.CreatorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.CreatorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CreatorData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CreatorData(Azure.Core.AzureLocation location, Azure.ResourceManager.Maps.Models.CreatorProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Maps.Models.CreatorProperties Properties { get { throw null; } set { } }
    }
    public partial class CreatorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CreatorResource() { }
        public virtual Azure.ResourceManager.Maps.CreatorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Maps.CreatorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.CreatorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string creatorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.CreatorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.CreatorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.CreatorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.CreatorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.CreatorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.CreatorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.CreatorResource> Update(Azure.ResourceManager.Maps.Models.CreatorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.CreatorResource>> UpdateAsync(Azure.ResourceManager.Maps.Models.CreatorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.MapsAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.MapsAccountResource>, System.Collections.IEnumerable
    {
        protected MapsAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.MapsAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Maps.MapsAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.MapsAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Maps.MapsAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maps.MapsAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maps.MapsAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maps.MapsAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.MapsAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maps.MapsAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.MapsAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MapsAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MapsAccountData(Azure.Core.AzureLocation location, Azure.ResourceManager.Maps.Models.MapsSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsAccountProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsSku Sku { get { throw null; } set { } }
    }
    public partial class MapsAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MapsAccountResource() { }
        public virtual Azure.ResourceManager.Maps.MapsAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.CreatorResource> GetCreator(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.CreatorResource>> GetCreatorAsync(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Maps.CreatorCollection GetCreators() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountSasToken> GetSas(Azure.ResourceManager.Maps.Models.AccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountSasToken>> GetSasAsync(Azure.ResourceManager.Maps.Models.AccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountKeys> RegenerateKeys(Azure.ResourceManager.Maps.Models.MapsKeySpecification keySpecification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountKeys>> RegenerateKeysAsync(Azure.ResourceManager.Maps.Models.MapsKeySpecification keySpecification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> Update(Azure.ResourceManager.Maps.Models.MapsAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> UpdateAsync(Azure.ResourceManager.Maps.Models.MapsAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MapsExtensions
    {
        public static Azure.ResourceManager.Maps.CreatorResource GetCreatorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> GetMapsAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> GetMapsAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maps.MapsAccountResource GetMapsAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maps.MapsAccountCollection GetMapsAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maps.MapsAccountResource> GetMapsAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maps.MapsAccountResource> GetMapsAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maps.Models.OperationDetail> GetOperationsMaps(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maps.Models.OperationDetail> GetOperationsMapsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maps.Models.OperationDetail> GetSubscriptionOperationsMaps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maps.Models.OperationDetail> GetSubscriptionOperationsMapsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Maps.Models
{
    public partial class AccountSasContent
    {
        public AccountSasContent(Azure.ResourceManager.Maps.Models.SigningKey signingKey, string principalId, int maxRatePerSecond, string start, string expiry) { }
        public string Expiry { get { throw null; } }
        public int MaxRatePerSecond { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public System.Collections.Generic.IList<string> Regions { get { throw null; } }
        public Azure.ResourceManager.Maps.Models.SigningKey SigningKey { get { throw null; } }
        public string Start { get { throw null; } }
    }
    public partial class CorsRule
    {
        public CorsRule(System.Collections.Generic.IEnumerable<string> allowedOrigins) { }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
    }
    public partial class CreatorPatch
    {
        public CreatorPatch() { }
        public string ProvisioningState { get { throw null; } }
        public int? StorageUnits { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CreatorProperties
    {
        public CreatorProperties(int storageUnits) { }
        public string ProvisioningState { get { throw null; } }
        public int StorageUnits { get { throw null; } set { } }
    }
    public partial class Dimension
    {
        internal Dimension() { }
        public string DisplayName { get { throw null; } }
        public string InternalMetricName { get { throw null; } }
        public string InternalName { get { throw null; } }
        public string Name { get { throw null; } }
        public string SourceMdmNamespace { get { throw null; } }
        public bool? ToBeExportedToShoebox { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.Maps.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.KeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.KeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.KeyType left, Azure.ResourceManager.Maps.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.KeyType left, Azure.ResourceManager.Maps.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkedResource
    {
        public LinkedResource(string uniqueName, string id) { }
        public string Id { get { throw null; } set { } }
        public string UniqueName { get { throw null; } set { } }
    }
    public partial class MapsAccountKeys
    {
        internal MapsAccountKeys() { }
        public string PrimaryKey { get { throw null; } }
        public string PrimaryKeyLastUpdated { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        public string SecondaryKeyLastUpdated { get { throw null; } }
    }
    public partial class MapsAccountPatch
    {
        public MapsAccountPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.CorsRule> CorsRulesValue { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.LinkedResource> LinkedResources { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Maps.Models.MapsSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string UniqueId { get { throw null; } }
    }
    public partial class MapsAccountProperties
    {
        public MapsAccountProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.CorsRule> CorsRulesValue { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.LinkedResource> LinkedResources { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string UniqueId { get { throw null; } }
    }
    public partial class MapsAccountSasToken
    {
        internal MapsAccountSasToken() { }
        public string AccountSasToken { get { throw null; } }
    }
    public partial class MapsKeySpecification
    {
        public MapsKeySpecification(Azure.ResourceManager.Maps.Models.KeyType keyType) { }
        public Azure.ResourceManager.Maps.Models.KeyType KeyType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsKind : System.IEquatable<Azure.ResourceManager.Maps.Models.MapsKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsKind(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsKind Gen1 { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsKind Gen2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.MapsKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.MapsKind left, Azure.ResourceManager.Maps.Models.MapsKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.MapsKind left, Azure.ResourceManager.Maps.Models.MapsKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsSku
    {
        public MapsSku(Azure.ResourceManager.Maps.Models.Name name) { }
        public Azure.ResourceManager.Maps.Models.Name Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
    }
    public partial class MetricSpecification
    {
        internal MetricSpecification() { }
        public string AggregationType { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Maps.Models.Dimension> Dimensions { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? FillGapWithZero { get { throw null; } }
        public string InternalMetricName { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceIdDimensionNameOverride { get { throw null; } }
        public string SourceMdmAccount { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Name : System.IEquatable<Azure.ResourceManager.Maps.Models.Name>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Name(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.Name G2 { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.Name S0 { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.Name S1 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.Name other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.Name left, Azure.ResourceManager.Maps.Models.Name right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.Name (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.Name left, Azure.ResourceManager.Maps.Models.Name right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationDetail
    {
        internal OperationDetail() { }
        public Azure.ResourceManager.Maps.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Maps.Models.MetricSpecification> MetricSpecifications { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
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
    public readonly partial struct SigningKey : System.IEquatable<Azure.ResourceManager.Maps.Models.SigningKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SigningKey(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.SigningKey PrimaryKey { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.SigningKey SecondaryKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.SigningKey other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.SigningKey left, Azure.ResourceManager.Maps.Models.SigningKey right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.SigningKey (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.SigningKey left, Azure.ResourceManager.Maps.Models.SigningKey right) { throw null; }
        public override string ToString() { throw null; }
    }
}
