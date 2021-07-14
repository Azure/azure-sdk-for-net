namespace Azure.ResourceManager.Core
{
    public partial class Alias
    {
        internal Alias() { }
        public string DefaultPath { get { throw null; } }
        public Azure.ResourceManager.Core.AliasPattern DefaultPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.AliasPath> Paths { get { throw null; } }
        public Azure.ResourceManager.Core.AliasType? Type { get { throw null; } }
    }
    public partial class AliasPath
    {
        internal AliasPath() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Core.AliasPattern Pattern { get { throw null; } }
    }
    public partial class AliasPattern
    {
        internal AliasPattern() { }
        public string Phrase { get { throw null; } }
        public Azure.ResourceManager.Core.AliasPatternType? Type { get { throw null; } }
        public string Variable { get { throw null; } }
    }
    public enum AliasPatternType
    {
        NotSpecified = 0,
        Extract = 1,
    }
    public enum AliasType
    {
        NotSpecified = 0,
        PlainText = 1,
        Mask = 2,
    }
    public partial class ApiVersions
    {
        internal ApiVersions() { }
        public void SetApiVersion(Azure.ResourceManager.Core.ResourceType resourceType, string apiVersion) { }
        public string TryGetApiVersion(Azure.ResourceManager.Core.ResourceType resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<string> TryGetApiVersionAsync(Azure.ResourceManager.Core.ResourceType resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionsBase : System.IComparable<string>, System.IEquatable<string>
    {
        protected ApiVersionsBase(string value) { }
        public virtual Azure.ResourceManager.Core.ResourceType ResourceType { get { throw null; } }
        public int CompareTo(string other) { throw null; }
        public override bool Equals(object other) { throw null; }
        public bool Equals(string other) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.ApiVersionsBase left, string right) { throw null; }
        public static bool operator >(Azure.ResourceManager.Core.ApiVersionsBase left, Azure.ResourceManager.Core.ApiVersionsBase right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.Core.ApiVersionsBase left, Azure.ResourceManager.Core.ApiVersionsBase right) { throw null; }
        public static implicit operator string (Azure.ResourceManager.Core.ApiVersionsBase version) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.ApiVersionsBase left, string right) { throw null; }
        public static bool operator <(Azure.ResourceManager.Core.ApiVersionsBase left, Azure.ResourceManager.Core.ApiVersionsBase right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.Core.ApiVersionsBase left, Azure.ResourceManager.Core.ApiVersionsBase right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmClient
    {
        protected ArmClient() { }
        public ArmClient(Azure.Core.TokenCredential credential, Azure.ResourceManager.Core.ArmClientOptions options = null) { }
        public ArmClient(string defaultSubscriptionId, Azure.Core.TokenCredential credential, Azure.ResourceManager.Core.ArmClientOptions options = null) { }
        public ArmClient(string defaultSubscriptionId, System.Uri baseUri, Azure.Core.TokenCredential credential, Azure.ResourceManager.Core.ArmClientOptions options = null) { }
        public ArmClient(System.Uri baseUri, Azure.Core.TokenCredential credential, Azure.ResourceManager.Core.ArmClientOptions options = null) { }
        protected virtual System.Uri BaseUri { get { throw null; } }
        protected virtual Azure.ResourceManager.Core.ArmClientOptions ClientOptions { get { throw null; } }
        protected virtual Azure.Core.TokenCredential Credential { get { throw null; } }
        public virtual Azure.ResourceManager.Core.Subscription DefaultSubscription { get { throw null; } }
        protected virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public T GetContainer<T>(System.Func<Azure.ResourceManager.Core.ArmClientOptions, Azure.Core.TokenCredential, System.Uri, Azure.Core.Pipeline.HttpPipeline, T> func) { throw null; }
        public virtual System.Collections.Generic.IList<Azure.ResourceManager.Core.GenericResourceOperations> GetGenericResourceOperations(System.Collections.Generic.IEnumerable<string> ids) { throw null; }
        public virtual Azure.ResourceManager.Core.GenericResourceOperations GetGenericResourceOperations(string id) { throw null; }
        public virtual Azure.ResourceManager.Core.ManagementGroupOperations GetManagementGroupOperations(string id) { throw null; }
        public virtual Azure.ResourceManager.Core.ManagementGroupContainer GetManagementGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.ProviderInfo> GetProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ProviderInfo>> GetProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ResourceGroupOperations GetResourceGroupOperations(Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Core.RestApiContainer GetRestApis(string nameSpace) { throw null; }
        public virtual Azure.ResourceManager.Core.SubscriptionContainer GetSubscriptions() { throw null; }
        public virtual Azure.ResourceManager.Core.TenantContainer GetTenants() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.ProviderInfo> ListProviders(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.ProviderInfo> ListProvidersAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public sealed partial class ArmClientOptions : Azure.Core.ClientOptions
    {
        public ArmClientOptions() { }
        public Azure.ResourceManager.Core.ApiVersions ApiVersions { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object GetOverrideObject<T>(System.Func<object> objectConstructor) { throw null; }
    }
    public partial class CheckNameAvailabilityRequest
    {
        public CheckNameAvailabilityRequest() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Core.Reason? Reason { get { throw null; } }
    }
    public abstract partial class ContainerBase : Azure.ResourceManager.Core.OperationsBase
    {
        protected ContainerBase() { }
        protected ContainerBase(Azure.ResourceManager.Core.ArmClientOptions options, Azure.Core.TokenCredential credential, System.Uri baseUri, Azure.Core.Pipeline.HttpPipeline pipeline) { }
        protected ContainerBase(Azure.ResourceManager.Core.OperationsBase parent) { }
        protected Azure.ResourceManager.Core.OperationsBase Parent { get { throw null; } }
    }
    public partial class CreateManagementGroupChildInfo
    {
        internal CreateManagementGroupChildInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.CreateManagementGroupChildInfo> Children { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Core.ManagementGroupChildType? Type { get { throw null; } }
    }
    public partial class CreateManagementGroupDetails
    {
        public CreateManagementGroupDetails() { }
        public Azure.ResourceManager.Core.CreateParentGroupInfo Parent { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedTime { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class CreateManagementGroupRequest
    {
        public CreateManagementGroupRequest() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.CreateManagementGroupChildInfo> Children { get { throw null; } }
        public Azure.ResourceManager.Core.CreateManagementGroupDetails Details { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string TenantId { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class CreateParentGroupInfo
    {
        public CreateParentGroupInfo() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
    }
    public partial class DescendantInfo
    {
        internal DescendantInfo() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Core.DescendantParentGroupInfo Parent { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class DescendantParentGroupInfo
    {
        internal DescendantParentGroupInfo() { }
        public string Id { get { throw null; } }
    }
    public partial class ErrorAdditionalInfo
    {
        internal ErrorAdditionalInfo() { }
        public object Info { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.ErrorResponse> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ExportTemplateRequest
    {
        public ExportTemplateRequest() { }
        public string Options { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } }
    }
    public partial class Feature : Azure.ResourceManager.Core.FeatureOperations
    {
        protected Feature() { }
        public virtual Azure.ResourceManager.Core.FeatureData Data { get { throw null; } }
    }
    public partial class FeatureContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.SubscriptionProviderIdentifier, Azure.ResourceManager.Core.Feature, Azure.ResourceManager.Core.FeatureData>
    {
        protected FeatureContainer() { }
        public new Azure.ResourceManager.Core.SubscriptionProviderIdentifier Id { get { throw null; } }
        protected new Azure.ResourceManager.Core.ProviderOperations Parent { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual bool DoesExist(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<bool> DoesExistAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.Feature> Get(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Feature>> GetAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.Feature> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.Feature> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.Feature TryGet(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.Feature> TryGetAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FeatureData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.SubscriptionProviderIdentifier>
    {
        internal FeatureData() { }
        public Azure.ResourceManager.Core.FeatureProperties Properties { get { throw null; } }
    }
    public partial class FeatureOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.SubscriptionProviderIdentifier, Azure.ResourceManager.Core.Feature>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected FeatureOperations() { }
        protected FeatureOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.SubscriptionProviderIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public override Azure.Response<Azure.ResourceManager.Core.Feature> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Feature>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.Feature> Register(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Feature>> RegisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.Feature> Unregister(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Feature>> UnregisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override void Validate(Azure.ResourceManager.Core.ResourceIdentifier identifier) { }
    }
    public partial class FeatureProperties
    {
        internal FeatureProperties() { }
        public string State { get { throw null; } }
    }
    public partial class GenericResource : Azure.ResourceManager.Core.GenericResourceOperations
    {
        protected GenericResource() { }
        public virtual Azure.ResourceManager.Core.GenericResourceData Data { get { throw null; } }
    }
    public partial class GenericResourceContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.TenantResourceIdentifier, Azure.ResourceManager.Core.GenericResource, Azure.ResourceManager.Core.GenericResourceData>
    {
        protected GenericResourceContainer() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Core.GenericResource> CreateOrUpdate(string resourceId, Azure.ResourceManager.Core.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.GenericResource>> CreateOrUpdateAsync(string resourceId, Azure.ResourceManager.Core.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual bool DoesExist(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<bool> DoesExistAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.Core.GenericResource> Get(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.GenericResource>> GetAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> List(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListByResourceGroup(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListByResourceGroupAsync(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ResourcesCreateOrUpdateByIdOperation StartCreateOrUpdate(string resourceId, Azure.ResourceManager.Core.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ResourcesCreateOrUpdateByIdOperation> StartCreateOrUpdateAsync(string resourceId, Azure.ResourceManager.Core.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.GenericResource TryGet(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.GenericResource> TryGetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override void Validate(Azure.ResourceManager.Core.ResourceIdentifier identifier) { }
    }
    public partial class GenericResourceData : Azure.ResourceManager.Core.TrackedResource<Azure.ResourceManager.Core.TenantResourceIdentifier>
    {
        public GenericResourceData() { }
        public Azure.ResourceManager.Core.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Core.Plan Plan { get { throw null; } set { } }
        public object Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Core.Sku Sku { get { throw null; } set { } }
    }
    public partial class GenericResourceExpanded : Azure.ResourceManager.Core.GenericResourceOperations
    {
        protected GenericResourceExpanded() { }
        public virtual Azure.ResourceManager.Core.GenericResourceExpandedData Data { get { throw null; } }
    }
    public partial class GenericResourceExpandedData : Azure.ResourceManager.Core.GenericResourceData
    {
        public GenericResourceExpandedData() { }
        public System.DateTimeOffset? ChangedTime { get { throw null; } }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public abstract partial class GenericResourceFilter
    {
        protected GenericResourceFilter() { }
        public abstract string GetFilterString();
        public override string ToString() { throw null; }
    }
    public partial class GenericResourceOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.TenantResourceIdentifier, Azure.ResourceManager.Core.GenericResource>
    {
        protected GenericResourceOperations() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Core.GenericResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.GenericResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.Core.GenericResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.GenericResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.GenericResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.GenericResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.GenericResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.GenericResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ResourcesDeleteByIdOperation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ResourcesDeleteByIdOperation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ResourcesUpdateByIdOperation StartUpdate(Azure.ResourceManager.Core.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ResourcesUpdateByIdOperation> StartUpdateAsync(Azure.ResourceManager.Core.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.GenericResource> Update(Azure.ResourceManager.Core.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.GenericResource>> UpdateAsync(Azure.ResourceManager.Core.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override void Validate(Azure.ResourceManager.Core.ResourceIdentifier identifier) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Constructor)]
    public partial class InitializationConstructorAttribute : System.Attribute
    {
        public InitializationConstructorAttribute() { }
    }
    public partial class Location : System.IComparable<Azure.ResourceManager.Core.Location>, System.IEquatable<Azure.ResourceManager.Core.Location>
    {
        public static readonly Azure.ResourceManager.Core.Location AustraliaCentral;
        public static readonly Azure.ResourceManager.Core.Location AustraliaCentral2;
        public static readonly Azure.ResourceManager.Core.Location AustraliaEast;
        public static readonly Azure.ResourceManager.Core.Location AustraliaSoutheast;
        public static readonly Azure.ResourceManager.Core.Location BrazilSouth;
        public static readonly Azure.ResourceManager.Core.Location BrazilSoutheast;
        public static readonly Azure.ResourceManager.Core.Location CanadaCentral;
        public static readonly Azure.ResourceManager.Core.Location CanadaEast;
        public static readonly Azure.ResourceManager.Core.Location CentralIndia;
        public static readonly Azure.ResourceManager.Core.Location CentralUS;
        public static readonly Azure.ResourceManager.Core.Location EastAsia;
        public static readonly Azure.ResourceManager.Core.Location EastUS;
        public static readonly Azure.ResourceManager.Core.Location EastUS2;
        public static readonly Azure.ResourceManager.Core.Location FranceCentral;
        public static readonly Azure.ResourceManager.Core.Location FranceSouth;
        public static readonly Azure.ResourceManager.Core.Location GermanyNorth;
        public static readonly Azure.ResourceManager.Core.Location GermanyWestCentral;
        public static readonly Azure.ResourceManager.Core.Location JapanEast;
        public static readonly Azure.ResourceManager.Core.Location JapanWest;
        public static readonly Azure.ResourceManager.Core.Location KoreaCentral;
        public static readonly Azure.ResourceManager.Core.Location KoreaSouth;
        public static readonly Azure.ResourceManager.Core.Location NorthCentralUS;
        public static readonly Azure.ResourceManager.Core.Location NorthEurope;
        public static readonly Azure.ResourceManager.Core.Location NorwayWest;
        public static readonly Azure.ResourceManager.Core.Location SouthAfricaNorth;
        public static readonly Azure.ResourceManager.Core.Location SouthAfricaWest;
        public static readonly Azure.ResourceManager.Core.Location SouthCentralUS;
        public static readonly Azure.ResourceManager.Core.Location SoutheastAsia;
        public static readonly Azure.ResourceManager.Core.Location SouthIndia;
        public static readonly Azure.ResourceManager.Core.Location SwitzerlandNorth;
        public static readonly Azure.ResourceManager.Core.Location SwitzerlandWest;
        public static readonly Azure.ResourceManager.Core.Location UAECentral;
        public static readonly Azure.ResourceManager.Core.Location UAENorth;
        public static readonly Azure.ResourceManager.Core.Location UKSouth;
        public static readonly Azure.ResourceManager.Core.Location UKWest;
        public static readonly Azure.ResourceManager.Core.Location WestCentralUS;
        public static readonly Azure.ResourceManager.Core.Location WestEurope;
        public static readonly Azure.ResourceManager.Core.Location WestIndia;
        public static readonly Azure.ResourceManager.Core.Location WestUS;
        public static readonly Azure.ResourceManager.Core.Location WestUS2;
        protected Location() { }
        public string CanonicalName { get { throw null; } }
        public static ref readonly Azure.ResourceManager.Core.Location Default { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public string RegionalDisplayName { get { throw null; } }
        public int CompareTo(Azure.ResourceManager.Core.Location other) { throw null; }
        public bool Equals(Azure.ResourceManager.Core.Location other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.Location left, Azure.ResourceManager.Core.Location right) { throw null; }
        public static bool operator >(Azure.ResourceManager.Core.Location left, Azure.ResourceManager.Core.Location right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.Core.Location left, Azure.ResourceManager.Core.Location right) { throw null; }
        public static implicit operator string (Azure.ResourceManager.Core.Location other) { throw null; }
        public static implicit operator Azure.ResourceManager.Core.Location (string other) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.Location left, Azure.ResourceManager.Core.Location right) { throw null; }
        public static bool operator <(Azure.ResourceManager.Core.Location left, Azure.ResourceManager.Core.Location right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.Core.Location left, Azure.ResourceManager.Core.Location right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocationExpanded : Azure.ResourceManager.Core.Location
    {
        protected LocationExpanded() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Core.LocationMetadata Metadata { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class LocationMetadata
    {
        internal LocationMetadata() { }
        public string GeographyGroup { get { throw null; } }
        public string Latitude { get { throw null; } }
        public string Longitude { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.PairedRegion> PairedRegion { get { throw null; } }
        public string PhysicalLocation { get { throw null; } }
        public Azure.ResourceManager.Core.RegionCategory? RegionCategory { get { throw null; } }
        public Azure.ResourceManager.Core.RegionType? RegionType { get { throw null; } }
    }
    public sealed partial class LocationResourceIdentifier : Azure.ResourceManager.Core.SubscriptionResourceIdentifier
    {
        public LocationResourceIdentifier(string resourceId) : base (default(string)) { }
        public Azure.ResourceManager.Core.Location Location { get { throw null; } }
        public static new implicit operator Azure.ResourceManager.Core.LocationResourceIdentifier (string other) { throw null; }
        public override bool TryGetLocation(out Azure.ResourceManager.Core.Location location) { throw null; }
        public override bool TryGetSubscriptionId(out string subscriptionId) { throw null; }
    }
    public partial class ManagedByTenant
    {
        internal ManagedByTenant() { }
        public string TenantId { get { throw null; } }
    }
    public partial class ManagementGroup : Azure.ResourceManager.Core.ManagementGroupOperations
    {
        protected ManagementGroup() { }
        public virtual Azure.ResourceManager.Core.ManagementGroupData Data { get { throw null; } }
    }
    public partial class ManagementGroupChildInfo
    {
        internal ManagementGroupChildInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.ManagementGroupChildInfo> Children { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Core.ManagementGroupChildType? Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementGroupChildType : System.IEquatable<Azure.ResourceManager.Core.ManagementGroupChildType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementGroupChildType(string value) { throw null; }
        public static Azure.ResourceManager.Core.ManagementGroupChildType MicrosoftManagementManagementGroups { get { throw null; } }
        public static Azure.ResourceManager.Core.ManagementGroupChildType Subscriptions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Core.ManagementGroupChildType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.ManagementGroupChildType left, Azure.ResourceManager.Core.ManagementGroupChildType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Core.ManagementGroupChildType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.ManagementGroupChildType left, Azure.ResourceManager.Core.ManagementGroupChildType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementGroupContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.TenantResourceIdentifier, Azure.ResourceManager.Core.ManagementGroup, Azure.ResourceManager.Core.ManagementGroupData>
    {
        protected ManagementGroupContainer() { }
        protected new Azure.ResourceManager.Core.TenantOperations Parent { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Core.CheckNameAvailabilityResult> CheckNameAvailability(Azure.ResourceManager.Core.CheckNameAvailabilityRequest checkNameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.ResourceManager.Core.CheckNameAvailabilityRequest checkNameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.ManagementGroup> CreateOrUpdate(string groupId, Azure.ResourceManager.Core.CreateManagementGroupRequest createManagementGroupRequest, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ManagementGroup>> CreateOrUpdateAsync(string groupId, Azure.ResourceManager.Core.CreateManagementGroupRequest createManagementGroupRequest, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual bool DoesExist(string groupId, Azure.ResourceManager.Core.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Core.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<bool> DoesExistAsync(string groupId, Azure.ResourceManager.Core.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Core.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.ManagementGroup> Get(string groupId, Azure.ResourceManager.Core.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Core.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ManagementGroup>> GetAsync(string groupId, Azure.ResourceManager.Core.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Core.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.ManagementGroupInfo> List(string cacheControl = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.ManagementGroupInfo> ListAsync(string cacheControl = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ManagementGroupsCreateOrUpdateOperation StartCreateOrUpdate(string groupId, Azure.ResourceManager.Core.CreateManagementGroupRequest createManagementGroupRequest, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ManagementGroupsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string groupId, Azure.ResourceManager.Core.CreateManagementGroupRequest createManagementGroupRequest, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ManagementGroup TryGet(string groupId, Azure.ResourceManager.Core.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Core.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ManagementGroup> TryGetAsync(string groupId, Azure.ResourceManager.Core.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Core.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementGroupData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.TenantResourceIdentifier>
    {
        internal ManagementGroupData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.ManagementGroupChildInfo> Children { get { throw null; } }
        public Azure.ResourceManager.Core.ManagementGroupDetails Details { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ManagementGroupDetails
    {
        internal ManagementGroupDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> ManagementGroupAncestors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.ManagementGroupPathElement> ManagementGroupAncestorsChain { get { throw null; } }
        public Azure.ResourceManager.Core.ParentGroupInfo Parent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.ManagementGroupPathElement> Path { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedTime { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementGroupExpandType : System.IEquatable<Azure.ResourceManager.Core.ManagementGroupExpandType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementGroupExpandType(string value) { throw null; }
        public static Azure.ResourceManager.Core.ManagementGroupExpandType Ancestors { get { throw null; } }
        public static Azure.ResourceManager.Core.ManagementGroupExpandType Children { get { throw null; } }
        public static Azure.ResourceManager.Core.ManagementGroupExpandType Path { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Core.ManagementGroupExpandType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.ManagementGroupExpandType left, Azure.ResourceManager.Core.ManagementGroupExpandType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Core.ManagementGroupExpandType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.ManagementGroupExpandType left, Azure.ResourceManager.Core.ManagementGroupExpandType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementGroupInfo : Azure.ResourceManager.Core.ManagementGroupOperations
    {
        protected ManagementGroupInfo() { }
        public virtual Azure.ResourceManager.Core.ManagementGroupInfoData Data { get { throw null; } }
    }
    public partial class ManagementGroupInfoData
    {
        internal ManagementGroupInfoData() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ManagementGroupOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.TenantResourceIdentifier, Azure.ResourceManager.Core.ManagementGroup>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected ManagementGroupOperations() { }
        protected internal ManagementGroupOperations(Azure.ResourceManager.Core.OperationsBase options, Azure.ResourceManager.Core.TenantResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response Delete(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.ManagementGroup> Get(Azure.ResourceManager.Core.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Core.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.Core.ManagementGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ManagementGroup>> GetAsync(Azure.ResourceManager.Core.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Core.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ManagementGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.DescendantInfo> ListDescendants(string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.DescendantInfo> ListDescendantsAsync(string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ManagementGroupsDeleteOperation StartDelete(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ManagementGroupsDeleteOperation> StartDeleteAsync(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.ManagementGroup> Update(Azure.ResourceManager.Core.PatchManagementGroupRequest patchGroupRequest, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ManagementGroup>> UpdateAsync(Azure.ResourceManager.Core.PatchManagementGroupRequest patchGroupRequest, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementGroupPathElement
    {
        internal ManagementGroupPathElement() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ManagementGroupsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Core.ManagementGroup>
    {
        protected ManagementGroupsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Core.ManagementGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.ManagementGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.ManagementGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementGroupsDeleteOperation : Azure.Operation
    {
        protected ManagementGroupsDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class OperationExtensions
    {
        public static Azure.Response WaitForCompletion(this Azure.Operation operation, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response WaitForCompletion(this Azure.Operation operation, System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<T> WaitForCompletion<T>(this Azure.Operation<T> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<T> WaitForCompletion<T>(this Azure.Operation<T> operation, System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class OperationsBase
    {
        protected OperationsBase() { }
        protected OperationsBase(Azure.ResourceManager.Core.OperationsBase parentOperations, Azure.ResourceManager.Core.ResourceIdentifier id) { }
        protected internal virtual System.Uri BaseUri { get { throw null; } }
        protected internal virtual Azure.ResourceManager.Core.ArmClientOptions ClientOptions { get { throw null; } }
        protected internal virtual Azure.Core.TokenCredential Credential { get { throw null; } }
        public virtual Azure.ResourceManager.Core.ResourceIdentifier Id { get { throw null; } }
        protected internal virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        protected internal Azure.ResourceManager.Core.TagResourceContainer TagContainer { get { throw null; } }
        protected internal Azure.ResourceManager.Core.TagResourceOperations TagResourceOperations { get { throw null; } }
        public Azure.ResourceManager.Core.TenantOperations Tenant { get { throw null; } }
        protected abstract Azure.ResourceManager.Core.ResourceType ValidResourceType { get; }
        protected virtual void Validate(Azure.ResourceManager.Core.ResourceIdentifier identifier) { }
    }
    public partial class PairedRegion
    {
        internal PairedRegion() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class ParentGroupInfo
    {
        internal ParentGroupInfo() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class PatchManagementGroupRequest
    {
        public PatchManagementGroupRequest() { }
        public string DisplayName { get { throw null; } set { } }
        public string ParentGroupId { get { throw null; } set { } }
    }
    public sealed partial class Plan : System.IComparable<Azure.ResourceManager.Core.Plan>, System.IEquatable<Azure.ResourceManager.Core.Plan>
    {
        public Plan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public int CompareTo(Azure.ResourceManager.Core.Plan other) { throw null; }
        public bool Equals(Azure.ResourceManager.Core.Plan other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.Plan left, Azure.ResourceManager.Core.Plan right) { throw null; }
        public static bool operator >(Azure.ResourceManager.Core.Plan left, Azure.ResourceManager.Core.Plan right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.Core.Plan left, Azure.ResourceManager.Core.Plan right) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.Plan left, Azure.ResourceManager.Core.Plan right) { throw null; }
        public static bool operator <(Azure.ResourceManager.Core.Plan left, Azure.ResourceManager.Core.Plan right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.Core.Plan left, Azure.ResourceManager.Core.Plan right) { throw null; }
    }
    public partial class PreDefinedTag : Azure.ResourceManager.Core.PreDefinedTagOperations
    {
        protected PreDefinedTag() { }
        public virtual Azure.ResourceManager.Core.PreDefinedTagData Data { get { throw null; } }
    }
    public partial class PreDefinedTagContainer : Azure.ResourceManager.Core.ContainerBase
    {
        protected PreDefinedTagContainer() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Core.PreDefinedTag> CreateOrUpdate(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.PreDefinedTag>> CreateOrUpdateAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.PreDefinedTag> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.PreDefinedTag> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Core.PreDefinedTagCreateOrUpdateOperation StartCreateOrUpdate(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.PreDefinedTagCreateOrUpdateOperation> StartCreateOrUpdateAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PreDefinedTagCount
    {
        internal PreDefinedTagCount() { }
        public string Type { get { throw null; } }
        public int? Value { get { throw null; } }
    }
    public partial class PreDefinedTagCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Core.PreDefinedTag>
    {
        protected PreDefinedTagCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Core.PreDefinedTag Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.PreDefinedTag>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.PreDefinedTag>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PreDefinedTagData : Azure.ResourceManager.Core.SubResource
    {
        internal PreDefinedTagData() { }
        public Azure.ResourceManager.Core.PreDefinedTagCount Count { get { throw null; } }
        public string TagName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.PreDefinedTagValue> Values { get { throw null; } }
    }
    public partial class PreDefinedTagDeleteOperation : Azure.Operation
    {
        protected PreDefinedTagDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PreDefinedTagOperations : Azure.ResourceManager.Core.ResourceOperationsBase
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected PreDefinedTagOperations() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Core.PreDefinedTagValue> CreateOrUpdateValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.PreDefinedTagValue>> CreateOrUpdateValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.PreDefinedTagDeleteOperation StartDelete(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.PreDefinedTagDeleteOperation> StartDeleteAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override void Validate(Azure.ResourceManager.Core.ResourceIdentifier identifier) { }
    }
    public partial class PreDefinedTagValue
    {
        internal PreDefinedTagValue() { }
        public Azure.ResourceManager.Core.PreDefinedTagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagValueValue { get { throw null; } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
    public partial class PropertyReferenceTypeAttribute : System.Attribute
    {
        public PropertyReferenceTypeAttribute() { }
        public PropertyReferenceTypeAttribute(System.Type[] skipTypes) { }
        public System.Type[] SkipTypes { get { throw null; } }
    }
    public partial class Provider : Azure.ResourceManager.Core.ProviderOperations
    {
        protected Provider() { }
        public virtual Azure.ResourceManager.Core.ProviderData Data { get { throw null; } }
    }
    public partial class ProviderContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.SubscriptionProviderIdentifier, Azure.ResourceManager.Core.Provider, Azure.ResourceManager.Core.ProviderData>
    {
        protected ProviderContainer() { }
        public new Azure.ResourceManager.Core.SubscriptionResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Core.Provider> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Provider>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.Provider> List(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.Provider> ListAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProviderData : Azure.ResourceManager.Core.SubResource<Azure.ResourceManager.Core.SubscriptionProviderIdentifier>
    {
        internal ProviderData() { }
        public string Namespace { get { throw null; } }
        public string RegistrationPolicy { get { throw null; } }
        public string RegistrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ProviderInfo
    {
        internal ProviderInfo() { }
        public string Namespace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ProviderOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.SubscriptionProviderIdentifier, Azure.ResourceManager.Core.Provider>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected ProviderOperations() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public override Azure.Response<Azure.ResourceManager.Core.Provider> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Provider>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.FeatureContainer GetFeatures() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.Provider> Register(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Provider>> RegisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.Provider> Unregister(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Provider>> UnregisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProviderResourceType
    {
        internal ProviderResourceType() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.Alias> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public enum Reason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
    public partial class ReferenceTypeAttribute : System.Attribute
    {
        public ReferenceTypeAttribute() { }
        public ReferenceTypeAttribute(System.Type genericType) { }
        public System.Type GenericType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionCategory : System.IEquatable<Azure.ResourceManager.Core.RegionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionCategory(string value) { throw null; }
        public static Azure.ResourceManager.Core.RegionCategory Other { get { throw null; } }
        public static Azure.ResourceManager.Core.RegionCategory Recommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Core.RegionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.RegionCategory left, Azure.ResourceManager.Core.RegionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Core.RegionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.RegionCategory left, Azure.ResourceManager.Core.RegionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionType : System.IEquatable<Azure.ResourceManager.Core.RegionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionType(string value) { throw null; }
        public static Azure.ResourceManager.Core.RegionType Logical { get { throw null; } }
        public static Azure.ResourceManager.Core.RegionType Physical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Core.RegionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.RegionType left, Azure.ResourceManager.Core.RegionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Core.RegionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.RegionType left, Azure.ResourceManager.Core.RegionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ResourceContainerBase<TIdentifier, TOperations, TResource> : Azure.ResourceManager.Core.ContainerBase where TIdentifier : Azure.ResourceManager.Core.ResourceIdentifier where TOperations : Azure.ResourceManager.Core.ResourceOperationsBase<TIdentifier, TOperations> where TResource : class
    {
        protected ResourceContainerBase() { }
        protected ResourceContainerBase(Azure.ResourceManager.Core.OperationsBase parent) { }
        protected TParent GetParentResource<TParent, TParentId, TParentOperations>() where TParent : TParentOperations where TParentId : Azure.ResourceManager.Core.ResourceIdentifier where TParentOperations : Azure.ResourceManager.Core.ResourceOperationsBase<TParentId, TParent> { throw null; }
        protected override void Validate(Azure.ResourceManager.Core.ResourceIdentifier identifier) { }
    }
    public sealed partial class ResourceFilterCollection
    {
        public ResourceFilterCollection() { }
        public ResourceFilterCollection(Azure.ResourceManager.Core.ResourceType type) { }
        public Azure.ResourceManager.Core.ResourceTypeFilter ResourceTypeFilter { get { throw null; } }
        public Azure.ResourceManager.Core.ResourceNameFilter SubstringFilter { get { throw null; } set { } }
        public Azure.ResourceManager.Core.ResourceTagFilter TagFilter { get { throw null; } set { } }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGroup : Azure.ResourceManager.Core.ResourceGroupOperations
    {
        protected ResourceGroup() { }
        public virtual Azure.ResourceManager.Core.ResourceGroupData Data { get { throw null; } }
    }
    public partial class ResourceGroupBuilder
    {
        public ResourceGroupBuilder(Azure.ResourceManager.Core.ResourceGroupContainer container, Azure.ResourceManager.Core.ResourceGroupData resource) { }
        protected Azure.ResourceManager.Core.ResourceGroupContainer Container { get { throw null; } }
        protected Azure.ResourceManager.Core.ResourceGroupData Resource { get { throw null; } }
        protected string ResourceName { get { throw null; } }
        public Azure.ResourceManager.Core.ResourceGroupData Build() { throw null; }
        public Azure.Response<Azure.ResourceManager.Core.ResourceGroup> CreateOrUpdate(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> CreateOrUpdateAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual bool IsValid(out string message) { throw null; }
        protected virtual void OnAfterBuild() { }
        protected virtual void OnBeforeBuild() { }
        public Azure.Operation<Azure.ResourceManager.Core.ResourceGroup> StartCreateOrUpdate(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Operation<Azure.ResourceManager.Core.ResourceGroup>> StartCreateOrUpdateAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.Core.ResourceGroup, Azure.ResourceManager.Core.ResourceGroupData>
    {
        protected ResourceGroupContainer() { }
        protected new Azure.ResourceManager.Core.SubscriptionOperations Parent { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public Azure.ResourceManager.Core.ResourceGroupBuilder Construct(Azure.ResourceManager.Core.Location location, System.Collections.Generic.IDictionary<string, string> tags = null, string managedBy = null) { throw null; }
        public Azure.Response<Azure.ResourceManager.Core.ResourceGroup> CreateOrUpdate(string name, Azure.ResourceManager.Core.ResourceGroupData resourceDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> CreateOrUpdateAsync(string name, Azure.ResourceManager.Core.ResourceGroupData resourceDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual bool DoesExist(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<bool> DoesExistAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.Core.ResourceGroup> Get(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> GetAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.ResourceGroup> List(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.ResourceGroup> ListAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Core.ResourceGroupCreateOrUpdateOperation StartCreateOrUpdate(string name, Azure.ResourceManager.Core.ResourceGroupData resourceDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ResourceGroupCreateOrUpdateOperation> StartCreateOrUpdateAsync(string name, Azure.ResourceManager.Core.ResourceGroupData resourceDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ResourceGroup TryGet(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ResourceGroup> TryGetAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Core.ResourceGroup>
    {
        protected ResourceGroupCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Core.ResourceGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupData : Azure.ResourceManager.Core.TrackedResource<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier>
    {
        public ResourceGroupData(string location) { }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Core.ResourceGroupProperties Properties { get { throw null; } set { } }
    }
    public partial class ResourceGroupDeleteOperation : Azure.Operation
    {
        protected ResourceGroupDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupExportResult
    {
        internal ResourceGroupExportResult() { }
        public Azure.ResourceManager.Core.ErrorResponse Error { get { throw null; } }
        public object Template { get { throw null; } }
    }
    public partial class ResourceGroupOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.Core.ResourceGroup>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected ResourceGroupOperations() { }
        protected ResourceGroupOperations(Azure.ResourceManager.Core.ResourceOperationsBase options, Azure.ResourceManager.Core.ResourceGroupResourceIdentifier id) { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Core.ResourceGroup> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<TOperations>> CreateResourceAsync<TContainer, TIdentifier, TOperations, TResource>(string name, TResource model, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where TContainer : Azure.ResourceManager.Core.ResourceContainerBase<TIdentifier, TOperations, TResource> where TIdentifier : Azure.ResourceManager.Core.SubscriptionResourceIdentifier where TOperations : Azure.ResourceManager.Core.ResourceOperationsBase<TIdentifier, TOperations> where TResource : Azure.ResourceManager.Core.TrackedResource<TIdentifier> { throw null; }
        public virtual Azure.Response<TOperations> CreateResource<TContainer, TOperations, TIdentifier, TResource>(string name, TResource model) where TContainer : Azure.ResourceManager.Core.ResourceContainerBase<TIdentifier, TOperations, TResource> where TOperations : Azure.ResourceManager.Core.ResourceOperationsBase<TIdentifier, TOperations> where TIdentifier : Azure.ResourceManager.Core.SubscriptionResourceIdentifier where TResource : Azure.ResourceManager.Core.TrackedResource<TIdentifier> { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.ResourceManager.Core.ResourceGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.Location> ListAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.Location>> ListAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response MoveResources(Azure.ResourceManager.Core.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MoveResourcesAsync(Azure.ResourceManager.Core.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.ResourceGroup> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.ResourceGroup> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ResourceGroupDeleteOperation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ResourceGroupDeleteOperation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ResourceGroupsExportTemplateOperation StartExportTemplate(Azure.ResourceManager.Core.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ResourceGroupsExportTemplateOperation> StartExportTemplateAsync(Azure.ResourceManager.Core.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ResourcesMoveResourcesOperation StartMoveResources(Azure.ResourceManager.Core.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ResourcesMoveResourcesOperation> StartMoveResourcesAsync(Azure.ResourceManager.Core.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.ResourcesValidateMoveResourcesOperation StartValidateMoveResources(Azure.ResourceManager.Core.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.ResourcesValidateMoveResourcesOperation> StartValidateMoveResourcesAsync(Azure.ResourceManager.Core.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.ResourceGroup> Update(Azure.ResourceManager.Core.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ResourceGroup>> UpdateAsync(Azure.ResourceManager.Core.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T UseClientContext<T>(System.Func<System.Uri, Azure.Core.TokenCredential, Azure.ResourceManager.Core.ArmClientOptions, Azure.Core.Pipeline.HttpPipeline, T> func) { throw null; }
        public virtual Azure.Response ValidateMoveResources(Azure.ResourceManager.Core.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateMoveResourcesAsync(Azure.ResourceManager.Core.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupPatchable
    {
        public ResourceGroupPatchable() { }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Core.ResourceGroupProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ResourceGroupProperties
    {
        public ResourceGroupProperties() { }
        public string ProvisioningState { get { throw null; } }
    }
    public sealed partial class ResourceGroupResourceIdentifier : Azure.ResourceManager.Core.SubscriptionResourceIdentifier
    {
        public ResourceGroupResourceIdentifier(string resourceId) : base (default(string)) { }
        public string ResourceGroupName { get { throw null; } }
        public static new implicit operator Azure.ResourceManager.Core.ResourceGroupResourceIdentifier (string other) { throw null; }
        public override bool TryGetResourceGroupName(out string resourceGroupName) { throw null; }
    }
    public partial class ResourceGroupsExportTemplateOperation : Azure.Operation<Azure.ResourceManager.Core.ResourceGroupExportResult>
    {
        protected ResourceGroupsExportTemplateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Core.ResourceGroupExportResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.ResourceGroupExportResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.ResourceGroupExportResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class ResourceIdentifier : System.IComparable<Azure.ResourceManager.Core.ResourceIdentifier>, System.IEquatable<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        internal ResourceIdentifier() { }
        public virtual string Name { get { throw null; } }
        public virtual Azure.ResourceManager.Core.ResourceIdentifier Parent { get { throw null; } }
        public virtual Azure.ResourceManager.Core.ResourceType ResourceType { get { throw null; } }
        public static Azure.ResourceManager.Core.ResourceIdentifier RootResourceIdentifier { get { throw null; } }
        public int CompareTo(Azure.ResourceManager.Core.ResourceIdentifier other) { throw null; }
        public static Azure.ResourceManager.Core.ResourceIdentifier Create(string resourceId) { throw null; }
        public bool Equals(Azure.ResourceManager.Core.ResourceIdentifier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.ResourceIdentifier id1, Azure.ResourceManager.Core.ResourceIdentifier id2) { throw null; }
        public static bool operator >(Azure.ResourceManager.Core.ResourceIdentifier left, Azure.ResourceManager.Core.ResourceIdentifier right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.Core.ResourceIdentifier left, Azure.ResourceManager.Core.ResourceIdentifier right) { throw null; }
        public static implicit operator string (Azure.ResourceManager.Core.ResourceIdentifier id) { throw null; }
        public static implicit operator Azure.ResourceManager.Core.ResourceIdentifier (string other) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.ResourceIdentifier id1, Azure.ResourceManager.Core.ResourceIdentifier id2) { throw null; }
        public static bool operator <(Azure.ResourceManager.Core.ResourceIdentifier left, Azure.ResourceManager.Core.ResourceIdentifier right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.Core.ResourceIdentifier left, Azure.ResourceManager.Core.ResourceIdentifier right) { throw null; }
        public override string ToString() { throw null; }
        public virtual bool TryGetLocation(out Azure.ResourceManager.Core.Location location) { throw null; }
        public virtual bool TryGetParent(out Azure.ResourceManager.Core.ResourceIdentifier containerId) { throw null; }
        public virtual bool TryGetResourceGroupName(out string resourceGroupName) { throw null; }
        public virtual bool TryGetSubscriptionId(out string subscriptionId) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public static partial class ResourceIdentifierExtensions
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.LocationResourceIdentifier AppendChildResource(this Azure.ResourceManager.Core.LocationResourceIdentifier identifier, string childResourceType, string childResourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.ResourceGroupResourceIdentifier AppendChildResource(this Azure.ResourceManager.Core.ResourceGroupResourceIdentifier identifier, string childResourceType, string childResourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.SubscriptionProviderIdentifier AppendChildResource(this Azure.ResourceManager.Core.SubscriptionProviderIdentifier identifier, string childResourceType, string childResourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.SubscriptionResourceIdentifier AppendChildResource(this Azure.ResourceManager.Core.SubscriptionResourceIdentifier identifier, string childResourceType, string childResourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.TenantResourceIdentifier AppendChildResource(this Azure.ResourceManager.Core.TenantResourceIdentifier identifier, string childResourceType, string childResourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.LocationResourceIdentifier AppendProviderResource(this Azure.ResourceManager.Core.LocationResourceIdentifier identifier, string providerNamespace, string resourceType, string resourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.ResourceGroupResourceIdentifier AppendProviderResource(this Azure.ResourceManager.Core.ResourceGroupResourceIdentifier identifier, string providerNamespace, string resourceType, string resourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.SubscriptionProviderIdentifier AppendProviderResource(this Azure.ResourceManager.Core.SubscriptionProviderIdentifier identifier, string providerNamespace, string resourceType, string resourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.SubscriptionResourceIdentifier AppendProviderResource(this Azure.ResourceManager.Core.SubscriptionResourceIdentifier identifier, string providerNamespace, string resourceType, string resourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Core.TenantResourceIdentifier AppendProviderResource(this Azure.ResourceManager.Core.TenantResourceIdentifier identifier, string providerNamespace, string resourceType, string resourceName) { throw null; }
    }
    [Azure.ResourceManager.Core.PropertyReferenceTypeAttribute(new System.Type[]{ typeof(Azure.ResourceManager.Core.ResourceIdentityType)})]
    public partial class ResourceIdentity : System.IEquatable<Azure.ResourceManager.Core.ResourceIdentity>
    {
        [Azure.ResourceManager.Core.InitializationConstructorAttribute]
        public ResourceIdentity() { }
        public ResourceIdentity(System.Collections.Generic.Dictionary<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.Core.UserAssignedIdentity> user, bool useSystemAssigned) { }
        public Azure.ResourceManager.Core.SystemAssignedIdentity SystemAssignedIdentity { get { throw null; } }
        public System.Collections.Generic.IDictionary<Azure.ResourceManager.Core.ResourceGroupResourceIdentifier, Azure.ResourceManager.Core.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Core.ResourceIdentity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        None = 1,
        UserAssigned = 2,
        SystemAssignedUserAssigned = 3,
    }
    public static partial class ResourceListOperations
    {
        public static Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAtContext(Azure.ResourceManager.Core.ResourceGroupOperations resourceGroup, Azure.ResourceManager.Core.ResourceFilterCollection resourceFilters = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAtContext(Azure.ResourceManager.Core.SubscriptionOperations subscription, Azure.ResourceManager.Core.ResourceFilterCollection resourceFilters = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAtContextAsync(Azure.ResourceManager.Core.ResourceGroupOperations resourceGroup, Azure.ResourceManager.Core.ResourceFilterCollection resourceFilters = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Core.GenericResourceExpanded> ListAtContextAsync(Azure.ResourceManager.Core.SubscriptionOperations subscription, Azure.ResourceManager.Core.ResourceFilterCollection resourceFilters = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceNameFilter : Azure.ResourceManager.Core.GenericResourceFilter, System.IEquatable<Azure.ResourceManager.Core.ResourceNameFilter>, System.IEquatable<string>
    {
        public ResourceNameFilter() { }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public bool Equals(Azure.ResourceManager.Core.ResourceNameFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public bool Equals(string other) { throw null; }
        public override string GetFilterString() { throw null; }
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.ResourceManager.Core.ResourceNameFilter (string nameString) { throw null; }
    }
    public abstract partial class ResourceOperationsBase : Azure.ResourceManager.Core.OperationsBase
    {
        protected ResourceOperationsBase() { }
    }
    public abstract partial class ResourceOperationsBase<TIdentifier, TOperations> : Azure.ResourceManager.Core.ResourceOperationsBase where TIdentifier : Azure.ResourceManager.Core.ResourceIdentifier where TOperations : Azure.ResourceManager.Core.ResourceOperationsBase<TIdentifier, TOperations>
    {
        protected ResourceOperationsBase() { }
        protected ResourceOperationsBase(Azure.ResourceManager.Core.OperationsBase parentOperations, Azure.ResourceManager.Core.ResourceIdentifier id) { }
        public virtual new TIdentifier Id { get { throw null; } }
        public abstract Azure.Response<TOperations> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<Azure.Response<TOperations>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        protected System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.Location> ListAvailableLocations(Azure.ResourceManager.Core.ResourceType resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Core.Location>> ListAvailableLocationsAsync(Azure.ResourceManager.Core.ResourceType resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesCreateOrUpdateByIdOperation : Azure.Operation<Azure.ResourceManager.Core.GenericResource>
    {
        protected ResourcesCreateOrUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Core.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesDeleteByIdOperation : Azure.Operation
    {
        protected ResourcesDeleteByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesDeleteOperation : Azure.Operation
    {
        protected ResourcesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesMoveInfo
    {
        public ResourcesMoveInfo() { }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } }
        public string TargetResourceGroup { get { throw null; } set { } }
    }
    public partial class ResourcesMoveResourcesOperation : Azure.Operation
    {
        protected ResourcesMoveResourcesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesUpdateByIdOperation : Azure.Operation<Azure.ResourceManager.Core.GenericResource>
    {
        protected ResourcesUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Core.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourcesValidateMoveResourcesOperation : Azure.Operation
    {
        protected ResourcesValidateMoveResourcesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceTagFilter : Azure.ResourceManager.Core.GenericResourceFilter, System.IEquatable<Azure.ResourceManager.Core.ResourceTagFilter>
    {
        public ResourceTagFilter(string tagKey, string tagValue) { }
        public ResourceTagFilter(System.Tuple<string, string> tag) { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Core.ResourceTagFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override string GetFilterString() { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class ResourceType : System.IComparable<Azure.ResourceManager.Core.ResourceType>, System.IEquatable<Azure.ResourceManager.Core.ResourceType>
    {
        public ResourceType(string resourceIdOrType) { }
        public string Namespace { get { throw null; } }
        public static Azure.ResourceManager.Core.ResourceType RootResourceType { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Types { get { throw null; } }
        public int CompareTo(Azure.ResourceManager.Core.ResourceType other) { throw null; }
        public bool Equals(Azure.ResourceManager.Core.ResourceType other) { throw null; }
        public override bool Equals(object other) { throw null; }
        public override int GetHashCode() { throw null; }
        public bool IsParentOf(Azure.ResourceManager.Core.ResourceType child) { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.ResourceType left, Azure.ResourceManager.Core.ResourceType right) { throw null; }
        public static bool operator >(Azure.ResourceManager.Core.ResourceType left, Azure.ResourceManager.Core.ResourceType right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.Core.ResourceType left, Azure.ResourceManager.Core.ResourceType right) { throw null; }
        public static implicit operator string (Azure.ResourceManager.Core.ResourceType other) { throw null; }
        public static implicit operator Azure.ResourceManager.Core.ResourceType (string other) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.ResourceType left, Azure.ResourceManager.Core.ResourceType right) { throw null; }
        public static bool operator <(Azure.ResourceManager.Core.ResourceType left, Azure.ResourceManager.Core.ResourceType right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.Core.ResourceType left, Azure.ResourceManager.Core.ResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeFilter : Azure.ResourceManager.Core.GenericResourceFilter, System.IEquatable<Azure.ResourceManager.Core.ResourceTypeFilter>, System.IEquatable<string>
    {
        public ResourceTypeFilter(Azure.ResourceManager.Core.ResourceType resourceType) { }
        public Azure.ResourceManager.Core.ResourceType ResourceType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Core.ResourceTypeFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public bool Equals(string other) { throw null; }
        public override string GetFilterString() { throw null; }
        public override int GetHashCode() { throw null; }
    }
    [Azure.ResourceManager.Core.ReferenceTypeAttribute(typeof(Azure.ResourceManager.Core.TenantResourceIdentifier))]
    public abstract partial class Resource<TIdentifier> where TIdentifier : Azure.ResourceManager.Core.TenantResourceIdentifier
    {
        [Azure.ResourceManager.Core.InitializationConstructorAttribute]
        protected Resource() { }
        [Azure.ResourceManager.Core.SerializationConstructorAttribute]
        protected internal Resource(TIdentifier id, string name, Azure.ResourceManager.Core.ResourceType type) { }
        public virtual TIdentifier Id { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual Azure.ResourceManager.Core.ResourceType Type { get { throw null; } }
    }
    public static partial class ResponseExtensions
    {
        public static string GetCorrelationId(this Azure.Response response) { throw null; }
    }
    public partial class RestApi
    {
        internal RestApi() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Origin { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class RestApiContainer : Azure.ResourceManager.Core.ContainerBase
    {
        protected RestApiContainer() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.RestApi> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.RestApi> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public sealed partial class RootResourceIdentifier : Azure.ResourceManager.Core.ResourceIdentifier
    {
        internal RootResourceIdentifier() { }
        public override bool TryGetParent(out Azure.ResourceManager.Core.ResourceIdentifier containerId) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Constructor)]
    public partial class SerializationConstructorAttribute : System.Attribute
    {
        public SerializationConstructorAttribute() { }
    }
    public abstract partial class SingletonOperationsBase : Azure.ResourceManager.Core.OperationsBase
    {
        protected SingletonOperationsBase() { }
        protected Azure.ResourceManager.Core.OperationsBase Parent { get { throw null; } }
        public Azure.ResourceManager.Core.ResourceIdentifier ParentId { get { throw null; } }
    }
    public abstract partial class SingletonOperationsBase<TIdentifier, TOperations> : Azure.ResourceManager.Core.SingletonOperationsBase where TIdentifier : Azure.ResourceManager.Core.ResourceIdentifier where TOperations : Azure.ResourceManager.Core.SingletonOperationsBase<TIdentifier, TOperations>
    {
        protected SingletonOperationsBase() { }
        protected SingletonOperationsBase(Azure.ResourceManager.Core.OperationsBase parent) { }
        protected new TIdentifier ParentId { get { throw null; } }
    }
    public sealed partial class Sku : System.IComparable<Azure.ResourceManager.Core.Sku>, System.IEquatable<Azure.ResourceManager.Core.Sku>
    {
        public Sku() { }
        public long? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        public int CompareTo(Azure.ResourceManager.Core.Sku other) { throw null; }
        public bool Equals(Azure.ResourceManager.Core.Sku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.Sku left, Azure.ResourceManager.Core.Sku right) { throw null; }
        public static bool operator >(Azure.ResourceManager.Core.Sku left, Azure.ResourceManager.Core.Sku right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.Core.Sku left, Azure.ResourceManager.Core.Sku right) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.Sku left, Azure.ResourceManager.Core.Sku right) { throw null; }
        public static bool operator <(Azure.ResourceManager.Core.Sku left, Azure.ResourceManager.Core.Sku right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.Core.Sku left, Azure.ResourceManager.Core.Sku right) { throw null; }
    }
    public enum SpendingLimit
    {
        On = 0,
        Off = 1,
        CurrentPeriodOff = 2,
    }
    [Azure.ResourceManager.Core.ReferenceTypeAttribute]
    public partial class SubResource : Azure.ResourceManager.Core.SubResource<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        [Azure.ResourceManager.Core.InitializationConstructorAttribute]
        protected SubResource() { }
        [Azure.ResourceManager.Core.SerializationConstructorAttribute]
        protected internal SubResource(string id) { }
    }
    [Azure.ResourceManager.Core.ReferenceTypeAttribute(typeof(Azure.ResourceManager.Core.ResourceIdentifier))]
    public partial class SubResource<TIdentifier> where TIdentifier : Azure.ResourceManager.Core.ResourceIdentifier
    {
        [Azure.ResourceManager.Core.InitializationConstructorAttribute]
        protected SubResource() { }
        [Azure.ResourceManager.Core.SerializationConstructorAttribute]
        protected internal SubResource(string id) { }
        public virtual TIdentifier Id { get { throw null; } }
    }
    public partial class Subscription : Azure.ResourceManager.Core.SubscriptionOperations
    {
        protected Subscription() { }
        public virtual Azure.ResourceManager.Core.SubscriptionData Data { get { throw null; } }
    }
    public partial class SubscriptionContainer : Azure.ResourceManager.Core.ResourceContainerBase<Azure.ResourceManager.Core.SubscriptionResourceIdentifier, Azure.ResourceManager.Core.Subscription, Azure.ResourceManager.Core.SubscriptionData>
    {
        protected SubscriptionContainer() { }
        protected new Azure.ResourceManager.Core.TenantOperations Parent { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual bool DoesExist(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<bool> DoesExistAsync(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.Core.Subscription> Get(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Subscription>> GetAsync(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.Subscription> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.Subscription> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.Subscription TryGet(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.Subscription> TryGetAsync(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionData : Azure.ResourceManager.Core.TrackedResource<Azure.ResourceManager.Core.SubscriptionResourceIdentifier>
    {
        internal SubscriptionData() { }
        public string AuthorizationSource { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Core.ManagedByTenant> ManagedByTenants { get { throw null; } }
        public override string Name { get { throw null; } }
        public Azure.ResourceManager.Core.SubscriptionState? State { get { throw null; } }
        public string SubscriptionGuid { get { throw null; } }
        public Azure.ResourceManager.Core.SubscriptionPolicies SubscriptionPolicies { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class SubscriptionOperations : Azure.ResourceManager.Core.ResourceOperationsBase<Azure.ResourceManager.Core.SubscriptionResourceIdentifier, Azure.ResourceManager.Core.Subscription>
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected SubscriptionOperations() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public override Azure.Response<Azure.ResourceManager.Core.Subscription> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.Subscription>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.GenericResourceContainer GetGenericResources() { throw null; }
        public virtual Azure.ResourceManager.Core.PreDefinedTagOperations GetPreDefinedTagOperations() { throw null; }
        public virtual Azure.ResourceManager.Core.PreDefinedTagContainer GetPredefinedTags() { throw null; }
        public virtual Azure.ResourceManager.Core.ProviderContainer GetProviders() { throw null; }
        public virtual Azure.ResourceManager.Core.ResourceGroupContainer GetResourceGroups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.Feature> ListFeatures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.Feature> ListFeaturesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.LocationExpanded> ListLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.LocationExpanded> ListLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T UseClientContext<T>(System.Func<System.Uri, Azure.Core.TokenCredential, Azure.ResourceManager.Core.ArmClientOptions, Azure.Core.Pipeline.HttpPipeline, T> func) { throw null; }
    }
    public partial class SubscriptionPolicies
    {
        internal SubscriptionPolicies() { }
        public string LocationPlacementId { get { throw null; } }
        public string QuotaId { get { throw null; } }
        public Azure.ResourceManager.Core.SpendingLimit? SpendingLimit { get { throw null; } }
    }
    public partial class SubscriptionProviderIdentifier : Azure.ResourceManager.Core.SubscriptionResourceIdentifier
    {
        internal SubscriptionProviderIdentifier() : base (default(string)) { }
        public string Provider { get { throw null; } }
        public static new implicit operator Azure.ResourceManager.Core.SubscriptionProviderIdentifier (string other) { throw null; }
        public override bool TryGetProvider(out string providerId) { throw null; }
    }
    public partial class SubscriptionResourceIdentifier : Azure.ResourceManager.Core.TenantResourceIdentifier
    {
        public SubscriptionResourceIdentifier(string resourceIdOrSubscriptionId) : base (default(string)) { }
        public string SubscriptionId { get { throw null; } }
        public static new implicit operator Azure.ResourceManager.Core.SubscriptionResourceIdentifier (string other) { throw null; }
        public override bool TryGetSubscriptionId(out string subscriptionId) { throw null; }
    }
    public enum SubscriptionState
    {
        Enabled = 0,
        Warned = 1,
        PastDue = 2,
        Disabled = 3,
        Deleted = 4,
    }
    public sealed partial class SystemAssignedIdentity : System.IEquatable<Azure.ResourceManager.Core.SystemAssignedIdentity>
    {
        public SystemAssignedIdentity() { }
        public SystemAssignedIdentity(System.Guid tenantId, System.Guid principalId) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public int CompareTo(Azure.ResourceManager.Core.SystemAssignedIdentity other) { throw null; }
        public bool Equals(Azure.ResourceManager.Core.SystemAssignedIdentity other) { throw null; }
        public static bool Equals(Azure.ResourceManager.Core.SystemAssignedIdentity original, Azure.ResourceManager.Core.SystemAssignedIdentity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class Tag : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.TenantResourceIdentifier>
    {
        public Tag() { }
        public System.Collections.Generic.IDictionary<string, string> TagsValue { get { throw null; } }
    }
    public partial class TagCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Core.TagResource>
    {
        protected TagCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Core.TagResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.TagResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Core.TagResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagPatchResource
    {
        public TagPatchResource() { }
        public Azure.ResourceManager.Core.TagPatchResourceOperation? Operation { get { throw null; } set { } }
        public Azure.ResourceManager.Core.Tag Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagPatchResourceOperation : System.IEquatable<Azure.ResourceManager.Core.TagPatchResourceOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagPatchResourceOperation(string value) { throw null; }
        public static Azure.ResourceManager.Core.TagPatchResourceOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.Core.TagPatchResourceOperation Merge { get { throw null; } }
        public static Azure.ResourceManager.Core.TagPatchResourceOperation Replace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Core.TagPatchResourceOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Core.TagPatchResourceOperation left, Azure.ResourceManager.Core.TagPatchResourceOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Core.TagPatchResourceOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Core.TagPatchResourceOperation left, Azure.ResourceManager.Core.TagPatchResourceOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagResource : Azure.ResourceManager.Core.TagResourceOperations
    {
        internal TagResource() { }
        public Azure.ResourceManager.Core.TagResourceData Data { get { throw null; } }
    }
    public partial class TagResourceContainer : Azure.ResourceManager.Core.ContainerBase
    {
        protected TagResourceContainer() { }
        public new Azure.ResourceManager.Core.ResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Core.TagResource> CreateOrUpdate(Azure.ResourceManager.Core.TagResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.TagResource>> CreateOrUpdateAsync(Azure.ResourceManager.Core.TagResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.TagCreateOrUpdateOperation StartCreateOrUpdate(Azure.ResourceManager.Core.TagResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.TagCreateOrUpdateOperation> StartCreateOrUpdateAsync(Azure.ResourceManager.Core.TagResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagResourceData : Azure.ResourceManager.Core.Resource<Azure.ResourceManager.Core.TenantResourceIdentifier>
    {
        public TagResourceData(Azure.ResourceManager.Core.Tag properties) { }
        public Azure.ResourceManager.Core.Tag Properties { get { throw null; } set { } }
    }
    public partial class TagResourceOperations : Azure.ResourceManager.Core.OperationsBase
    {
        protected TagResourceOperations() { }
        public new Azure.ResourceManager.Core.ResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.TagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.TagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.TagCreateOrUpdateOperation StartUpdate(Azure.ResourceManager.Core.TagPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Core.TagCreateOrUpdateOperation> StartUpdateAsync(Azure.ResourceManager.Core.TagPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.TagResource> Update(Azure.ResourceManager.Core.TagPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.TagResource>> UpdateAsync(Azure.ResourceManager.Core.TagPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Tenant : Azure.ResourceManager.Core.TenantOperations
    {
        protected Tenant() { }
        public virtual Azure.ResourceManager.Core.TenantData Data { get { throw null; } }
    }
    public enum TenantCategory
    {
        Home = 0,
        ProjectedBy = 1,
        ManagedBy = 2,
    }
    public partial class TenantContainer : Azure.ResourceManager.Core.ContainerBase
    {
        protected TenantContainer() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.Tenant> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.Tenant> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantData
    {
        internal TenantData() { }
        public string Country { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Domains { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Core.TenantCategory? TenantCategory { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class TenantOperations : Azure.ResourceManager.Core.OperationsBase
    {
        public static readonly Azure.ResourceManager.Core.ResourceType ResourceType;
        protected TenantOperations() { }
        protected override Azure.ResourceManager.Core.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Core.ManagementGroupContainer GetManagementGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Core.ProviderInfo> GetProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Core.ProviderInfo>> GetProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Core.SubscriptionContainer GetSubscriptions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Core.ProviderInfo> ListProviders(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Core.ProviderInfo> ListProvidersAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<T> ListResourcesAsync<T>(System.Func<System.Uri, Azure.Core.TokenCredential, Azure.ResourceManager.Core.ArmClientOptions, Azure.Core.Pipeline.HttpPipeline, Azure.AsyncPageable<T>> func) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<T> ListResources<T>(System.Func<System.Uri, Azure.Core.TokenCredential, Azure.ResourceManager.Core.ArmClientOptions, Azure.Core.Pipeline.HttpPipeline, Azure.Pageable<T>> func) { throw null; }
    }
    public partial class TenantProviderIdentifier : Azure.ResourceManager.Core.TenantResourceIdentifier
    {
        internal TenantProviderIdentifier() : base (default(string)) { }
        public string Provider { get { throw null; } }
        public static new implicit operator Azure.ResourceManager.Core.TenantProviderIdentifier (string other) { throw null; }
        public override bool TryGetProvider(out string providerId) { throw null; }
    }
    public partial class TenantResourceIdentifier : Azure.ResourceManager.Core.ResourceIdentifier
    {
        public TenantResourceIdentifier(string resourceId) { }
        public static new implicit operator Azure.ResourceManager.Core.TenantResourceIdentifier (string other) { throw null; }
        public virtual bool TryGetProvider(out string providerId) { throw null; }
    }
    [Azure.ResourceManager.Core.ReferenceTypeAttribute(typeof(Azure.ResourceManager.Core.TenantResourceIdentifier))]
    public abstract partial class TrackedResource<TIdentifier> : Azure.ResourceManager.Core.Resource<TIdentifier> where TIdentifier : Azure.ResourceManager.Core.TenantResourceIdentifier
    {
        protected TrackedResource() { }
        [Azure.ResourceManager.Core.InitializationConstructorAttribute]
        protected TrackedResource(Azure.ResourceManager.Core.Location location) { }
        [Azure.ResourceManager.Core.SerializationConstructorAttribute]
        protected internal TrackedResource(TIdentifier id, string name, Azure.ResourceManager.Core.ResourceType type, Azure.ResourceManager.Core.Location location, System.Collections.Generic.IDictionary<string, string> tags) { }
        public virtual Azure.ResourceManager.Core.Location Location { get { throw null; } set { } }
        public virtual System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public sealed partial class UserAssignedIdentity : System.IEquatable<Azure.ResourceManager.Core.UserAssignedIdentity>
    {
        public UserAssignedIdentity(System.Guid clientId, System.Guid principalId) { }
        public System.Guid ClientId { get { throw null; } }
        public System.Guid PrincipalId { get { throw null; } }
        public int CompareTo(Azure.ResourceManager.Core.UserAssignedIdentity other) { throw null; }
        public bool Equals(Azure.ResourceManager.Core.UserAssignedIdentity other) { throw null; }
        public static bool Equals(Azure.ResourceManager.Core.UserAssignedIdentity original, Azure.ResourceManager.Core.UserAssignedIdentity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public static partial class UtilityExtensions
    {
        public static System.Collections.Generic.IDictionary<string, string> ReplaceWith(this System.Collections.Generic.IDictionary<string, string> dest, System.Collections.Generic.IDictionary<string, string> src) { throw null; }
    }
    [Azure.ResourceManager.Core.ReferenceTypeAttribute]
    public partial class WritableSubResource : Azure.ResourceManager.Core.WritableSubResource<Azure.ResourceManager.Core.ResourceIdentifier>
    {
        [Azure.ResourceManager.Core.InitializationConstructorAttribute]
        public WritableSubResource() { }
        [Azure.ResourceManager.Core.SerializationConstructorAttribute]
        protected internal WritableSubResource(string id) { }
    }
    [Azure.ResourceManager.Core.ReferenceTypeAttribute(typeof(Azure.ResourceManager.Core.ResourceIdentifier))]
    public partial class WritableSubResource<TIdentifier> where TIdentifier : Azure.ResourceManager.Core.ResourceIdentifier
    {
        [Azure.ResourceManager.Core.InitializationConstructorAttribute]
        public WritableSubResource() { }
        [Azure.ResourceManager.Core.SerializationConstructorAttribute]
        protected internal WritableSubResource(string id) { }
        public virtual TIdentifier Id { get { throw null; } set { } }
    }
}
