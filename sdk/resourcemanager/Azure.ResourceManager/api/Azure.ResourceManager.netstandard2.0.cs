namespace Azure.ResourceManager
{
    public partial class ApiVersions
    {
        internal ApiVersions() { }
        public void SetApiVersion(Azure.ResourceManager.ResourceType resourceType, string apiVersion) { }
        public string TryGetApiVersion(Azure.ResourceManager.ResourceType resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<string> TryGetApiVersionAsync(Azure.ResourceManager.ResourceType resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArmClient
    {
        protected ArmClient() { }
        public ArmClient(Azure.Core.TokenCredential credential) { }
        public ArmClient(Azure.Core.TokenCredential credential, Azure.ResourceManager.ArmClientOptions options) { }
        public ArmClient(string defaultSubscriptionId, Azure.Core.TokenCredential credential, Azure.ResourceManager.ArmClientOptions options = null) { }
        public ArmClient(string defaultSubscriptionId, System.Uri baseUri, Azure.Core.TokenCredential credential, Azure.ResourceManager.ArmClientOptions options = null) { }
        public ArmClient(System.Uri baseUri, Azure.Core.TokenCredential credential, Azure.ResourceManager.ArmClientOptions options = null) { }
        protected virtual System.Uri BaseUri { get { throw null; } }
        protected virtual Azure.ResourceManager.ArmClientOptions ClientOptions { get { throw null; } }
        protected virtual Azure.Core.TokenCredential Credential { get { throw null; } }
        public virtual Azure.ResourceManager.Resources.Subscription DefaultSubscription { get { throw null; } }
        protected virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.ResourceManager.Resources.FeatureOperations GetFeatureOperations(string id) { throw null; }
        public virtual System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.GenericResourceOperations> GetGenericResourceOperations(System.Collections.Generic.IEnumerable<string> ids) { throw null; }
        public virtual Azure.ResourceManager.Resources.GenericResourceOperations GetGenericResourceOperations(string id) { throw null; }
        public virtual System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.GenericResourceOperations> GetGenericResourceOperations(params string[] ids) { throw null; }
        public virtual Azure.ResourceManager.Management.ManagementGroupOperations GetManagementGroupOperations(string id) { throw null; }
        public virtual Azure.ResourceManager.Management.ManagementGroupContainer GetManagementGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ProviderInfo> GetProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ProviderInfo>> GetProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ProviderOperations GetProviderOperations(string id) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ProviderInfo> GetProviders(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ProviderInfo> GetProvidersAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceGroupOperations GetResourceGroupOperations(string id) { throw null; }
        public virtual Azure.ResourceManager.Resources.RestApiContainer GetRestApis(string azureNamespace) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionOperations GetSubscriptionOperations(string id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionContainer GetSubscriptions() { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantContainer GetTenants() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T UseClientContext<T>(System.Func<System.Uri, Azure.Core.TokenCredential, Azure.ResourceManager.ArmClientOptions, Azure.Core.Pipeline.HttpPipeline, T> func) { throw null; }
    }
    public sealed partial class ArmClientOptions : Azure.Core.ClientOptions
    {
        public ArmClientOptions() { }
        public Azure.ResourceManager.ApiVersions ApiVersions { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object GetOverrideObject<T>(System.Func<object> objectConstructor) { throw null; }
    }
    public abstract partial class GenericResourceFilter
    {
        protected GenericResourceFilter() { }
        public abstract string GetFilterString();
        public override string ToString() { throw null; }
    }
    public sealed partial class ResourceFilterCollection
    {
        public ResourceFilterCollection() { }
        public ResourceFilterCollection(Azure.ResourceManager.ResourceType type) { }
        public Azure.ResourceManager.ResourceTypeFilter ResourceTypeFilter { get { throw null; } }
        public Azure.ResourceManager.ResourceNameFilter SubstringFilter { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceTagFilter TagFilter { get { throw null; } set { } }
        public override string ToString() { throw null; }
    }
    public partial class ResourceIdentifier : System.IComparable<Azure.ResourceManager.ResourceIdentifier>, System.IEquatable<Azure.ResourceManager.ResourceIdentifier>
    {
        public static readonly Azure.ResourceManager.ResourceIdentifier RootResourceIdentifier;
        public ResourceIdentifier(string resourceId) { }
        public string Location { get { throw null; } protected set { } }
        public virtual string Name { get { throw null; } }
        public virtual Azure.ResourceManager.ResourceIdentifier Parent { get { throw null; } }
        public string Provider { get { throw null; } protected set { } }
        public string ResourceGroupName { get { throw null; } protected set { } }
        public virtual Azure.ResourceManager.ResourceType ResourceType { get { throw null; } }
        public string SubscriptionId { get { throw null; } protected set { } }
        public int CompareTo(Azure.ResourceManager.ResourceIdentifier other) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier Create(string resourceId) { throw null; }
        public bool Equals(Azure.ResourceManager.ResourceIdentifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceIdentifier id1, Azure.ResourceManager.ResourceIdentifier id2) { throw null; }
        public static bool operator >(Azure.ResourceManager.ResourceIdentifier left, Azure.ResourceManager.ResourceIdentifier right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.ResourceIdentifier left, Azure.ResourceManager.ResourceIdentifier right) { throw null; }
        public static implicit operator string (Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceIdentifier (string other) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceIdentifier id1, Azure.ResourceManager.ResourceIdentifier id2) { throw null; }
        public static bool operator <(Azure.ResourceManager.ResourceIdentifier left, Azure.ResourceManager.ResourceIdentifier right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.ResourceIdentifier left, Azure.ResourceManager.ResourceIdentifier right) { throw null; }
        public override string ToString() { throw null; }
        public virtual bool TryGetLocation(out Azure.ResourceManager.Resources.Models.Location location) { throw null; }
        public virtual bool TryGetParent(out Azure.ResourceManager.ResourceIdentifier resourceId) { throw null; }
        public virtual bool TryGetResourceGroupName(out string resourceGroupName) { throw null; }
        public virtual bool TryGetSubscriptionId(out string subscriptionId) { throw null; }
    }
    public partial class ResourceNameFilter : Azure.ResourceManager.GenericResourceFilter, System.IEquatable<Azure.ResourceManager.ResourceNameFilter>, System.IEquatable<string>
    {
        public ResourceNameFilter() { }
        public string Name { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public bool Equals(Azure.ResourceManager.ResourceNameFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public bool Equals(string other) { throw null; }
        public override string GetFilterString() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceNameFilter (string nameString) { throw null; }
    }
    public partial class ResourceTagFilter : Azure.ResourceManager.GenericResourceFilter, System.IEquatable<Azure.ResourceManager.ResourceTagFilter>
    {
        public ResourceTagFilter(string tagKey, string tagValue) { }
        public ResourceTagFilter(System.Tuple<string, string> tag) { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceTagFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public override string GetFilterString() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class ResourceType : System.IComparable<Azure.ResourceManager.ResourceType>, System.IEquatable<Azure.ResourceManager.ResourceType>
    {
        public ResourceType(string resourceIdOrType) { }
        public string Namespace { get { throw null; } }
        public static Azure.ResourceManager.ResourceType RootResourceType { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Types { get { throw null; } }
        public int CompareTo(Azure.ResourceManager.ResourceType other) { throw null; }
        public bool Equals(Azure.ResourceManager.ResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public bool IsParentOf(Azure.ResourceManager.ResourceType child) { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceType left, Azure.ResourceManager.ResourceType right) { throw null; }
        public static bool operator >(Azure.ResourceManager.ResourceType left, Azure.ResourceManager.ResourceType right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.ResourceType left, Azure.ResourceManager.ResourceType right) { throw null; }
        public static implicit operator string (Azure.ResourceManager.ResourceType other) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceType (string other) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceType left, Azure.ResourceManager.ResourceType right) { throw null; }
        public static bool operator <(Azure.ResourceManager.ResourceType left, Azure.ResourceManager.ResourceType right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.ResourceType left, Azure.ResourceManager.ResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeFilter : Azure.ResourceManager.GenericResourceFilter, System.IEquatable<Azure.ResourceManager.ResourceTypeFilter>, System.IEquatable<string>
    {
        public ResourceTypeFilter(Azure.ResourceManager.ResourceType resourceType) { }
        public Azure.ResourceManager.ResourceType ResourceType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceTypeFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public bool Equals(string other) { throw null; }
        public override string GetFilterString() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
}
namespace Azure.ResourceManager.Core
{
    public abstract partial class ResourceContainer : Azure.ResourceManager.Core.ResourceOperations
    {
        protected ResourceContainer() { }
        protected ResourceContainer(Azure.ResourceManager.ArmClientOptions options, Azure.Core.TokenCredential credential, System.Uri baseUri, Azure.Core.Pipeline.HttpPipeline pipeline) { }
        protected ResourceContainer(Azure.ResourceManager.Core.ResourceOperations parent) { }
        protected Azure.ResourceManager.Core.ResourceOperations Parent { get { throw null; } }
    }
    public static partial class ResourceListOperations
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResourceExpanded> GetAtContext(Azure.ResourceManager.Resources.ResourceGroupOperations resourceGroup, Azure.ResourceManager.ResourceFilterCollection resourceFilters = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResourceExpanded> GetAtContext(Azure.ResourceManager.Resources.SubscriptionOperations subscription, Azure.ResourceManager.ResourceFilterCollection resourceFilters = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResourceExpanded> GetAtContextAsync(Azure.ResourceManager.Resources.ResourceGroupOperations resourceGroup, Azure.ResourceManager.ResourceFilterCollection resourceFilters = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResourceExpanded> GetAtContextAsync(Azure.ResourceManager.Resources.SubscriptionOperations subscription, Azure.ResourceManager.ResourceFilterCollection resourceFilters = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourceManagerExtensions
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ResourceIdentifier AppendChildResource(this Azure.ResourceManager.ResourceIdentifier identifier, string childResourceType, string childResourceName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ResourceIdentifier AppendProviderResource(this Azure.ResourceManager.ResourceIdentifier identifier, string providerNamespace, string resourceType, string resourceName) { throw null; }
        public static string GetCorrelationId(this Azure.Response response) { throw null; }
        public static Azure.Response WaitForCompletion(this Azure.Operation operation, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response WaitForCompletion(this Azure.Operation operation, System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<T> WaitForCompletion<T>(this Azure.Operation<T> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<T> WaitForCompletion<T>(this Azure.Operation<T> operation, System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class ResourceOperations
    {
        protected ResourceOperations() { }
        protected ResourceOperations(Azure.ResourceManager.Core.ResourceOperations parentOperations, Azure.ResourceManager.ResourceIdentifier id) { }
        protected internal virtual System.Uri BaseUri { get { throw null; } }
        protected internal virtual Azure.ResourceManager.ArmClientOptions ClientOptions { get { throw null; } }
        protected internal virtual Azure.Core.TokenCredential Credential { get { throw null; } }
        public virtual Azure.ResourceManager.ResourceIdentifier Id { get { throw null; } }
        protected internal virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        protected internal Azure.ResourceManager.Resources.TagResourceContainer TagContainer { get { throw null; } }
        protected internal Azure.ResourceManager.Resources.TagResourceOperations TagResourceOperations { get { throw null; } }
        protected abstract Azure.ResourceManager.ResourceType ValidResourceType { get; }
        protected System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> ListAvailableLocations(Azure.ResourceManager.ResourceType resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> ListAvailableLocationsAsync(Azure.ResourceManager.ResourceType resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual void ValidateResourceType(Azure.ResourceManager.ResourceIdentifier identifier) { }
    }
    public abstract partial class SingletonOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        protected SingletonOperations() { }
        protected SingletonOperations(Azure.ResourceManager.Core.ResourceOperations parent) { }
        protected Azure.ResourceManager.Core.ResourceOperations Parent { get { throw null; } }
    }
}
namespace Azure.ResourceManager.Management
{
    public partial class ManagementGroup : Azure.ResourceManager.Management.ManagementGroupOperations
    {
        protected ManagementGroup() { }
        public virtual Azure.ResourceManager.Management.ManagementGroupData Data { get { throw null; } }
    }
    public partial class ManagementGroupContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected ManagementGroupContainer() { }
        protected new Azure.ResourceManager.Resources.TenantOperations Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.Models.CheckNameAvailabilityResult> CheckNameAvailability(Azure.ResourceManager.Management.Models.CheckNameAvailabilityOptions checkNameAvailabilityOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.ResourceManager.Management.Models.CheckNameAvailabilityOptions checkNameAvailabilityOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroup> CreateOrUpdate(string groupId, Azure.ResourceManager.Management.Models.CreateManagementGroupOptions createManagementGroupOptions, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroup>> CreateOrUpdateAsync(string groupId, Azure.ResourceManager.Management.Models.CreateManagementGroupOptions createManagementGroupOptions, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroup> Get(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Management.ManagementGroupInfo> GetAll(string cacheControl = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Management.ManagementGroupInfo> GetAllAsync(string cacheControl = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroup>> GetAsync(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroup> GetIfExists(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroup>> GetIfExistsAsync(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Management.Models.ManagementGroupsCreateOrUpdateOperation StartCreateOrUpdate(string groupId, Azure.ResourceManager.Management.Models.CreateManagementGroupOptions createManagementGroupOptions, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Management.Models.ManagementGroupsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string groupId, Azure.ResourceManager.Management.Models.CreateManagementGroupOptions createManagementGroupOptions, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementGroupData : Azure.ResourceManager.Resources.Models.Resource
    {
        internal ManagementGroupData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupChildInfo> Children { get { throw null; } }
        public Azure.ResourceManager.Management.Models.ManagementGroupDetails Details { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ManagementGroupInfo : Azure.ResourceManager.Management.ManagementGroupOperations
    {
        protected ManagementGroupInfo() { }
        public virtual Azure.ResourceManager.Management.ManagementGroupInfoData Data { get { throw null; } }
    }
    public partial class ManagementGroupInfoData : Azure.ResourceManager.Resources.Models.Resource
    {
        internal ManagementGroupInfoData() { }
        public string DisplayName { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ManagementGroupOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ManagementGroupOperations() { }
        protected internal ManagementGroupOperations(Azure.ResourceManager.Core.ResourceOperations options, Azure.ResourceManager.ResourceIdentifier id) { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response Delete(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroup> Get(Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroup>> GetAsync(Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Management.Models.DescendantInfo> GetDescendants(string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Management.Models.DescendantInfo> GetDescendantsAsync(string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Management.Models.ManagementGroupsDeleteOperation StartDelete(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Management.Models.ManagementGroupsDeleteOperation> StartDeleteAsync(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroup> Update(Azure.ResourceManager.Management.Models.PatchManagementGroupOptions patchGroupOptions, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroup>> UpdateAsync(Azure.ResourceManager.Management.Models.PatchManagementGroupOptions patchGroupOptions, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Management.Models
{
    public partial class CheckNameAvailabilityOptions
    {
        public CheckNameAvailabilityOptions() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Management.Models.Reason? Reason { get { throw null; } }
    }
    public partial class CreateManagementGroupDetails
    {
        public CreateManagementGroupDetails() { }
        public Azure.ResourceManager.Management.Models.ManagementGroupParentCreateOptions Parent { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedTime { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class CreateManagementGroupOptions
    {
        public CreateManagementGroupOptions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupChildOptions> Children { get { throw null; } }
        public Azure.ResourceManager.Management.Models.CreateManagementGroupDetails Details { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string TenantId { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class DescendantInfo
    {
        internal DescendantInfo() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Management.Models.DescendantParentGroupInfo Parent { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class DescendantParentGroupInfo
    {
        internal DescendantParentGroupInfo() { }
        public string Id { get { throw null; } }
    }
    public partial class ManagementGroupChildInfo
    {
        internal ManagementGroupChildInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupChildInfo> Children { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Management.Models.ManagementGroupChildType? Type { get { throw null; } }
    }
    public partial class ManagementGroupChildOptions
    {
        internal ManagementGroupChildOptions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupChildOptions> Children { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Management.Models.ManagementGroupChildType? Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementGroupChildType : System.IEquatable<Azure.ResourceManager.Management.Models.ManagementGroupChildType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementGroupChildType(string value) { throw null; }
        public static Azure.ResourceManager.Management.Models.ManagementGroupChildType MicrosoftManagementManagementGroups { get { throw null; } }
        public static Azure.ResourceManager.Management.Models.ManagementGroupChildType Subscriptions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Management.Models.ManagementGroupChildType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Management.Models.ManagementGroupChildType left, Azure.ResourceManager.Management.Models.ManagementGroupChildType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Management.Models.ManagementGroupChildType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Management.Models.ManagementGroupChildType left, Azure.ResourceManager.Management.Models.ManagementGroupChildType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementGroupDetails
    {
        internal ManagementGroupDetails() { }
        public System.Collections.Generic.IReadOnlyList<string> ManagementGroupAncestors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupPathElement> ManagementGroupAncestorsChain { get { throw null; } }
        public Azure.ResourceManager.Management.Models.ParentGroupInfo Parent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupPathElement> Path { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedTime { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementGroupExpandType : System.IEquatable<Azure.ResourceManager.Management.Models.ManagementGroupExpandType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementGroupExpandType(string value) { throw null; }
        public static Azure.ResourceManager.Management.Models.ManagementGroupExpandType Ancestors { get { throw null; } }
        public static Azure.ResourceManager.Management.Models.ManagementGroupExpandType Children { get { throw null; } }
        public static Azure.ResourceManager.Management.Models.ManagementGroupExpandType Path { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Management.Models.ManagementGroupExpandType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Management.Models.ManagementGroupExpandType left, Azure.ResourceManager.Management.Models.ManagementGroupExpandType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Management.Models.ManagementGroupExpandType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Management.Models.ManagementGroupExpandType left, Azure.ResourceManager.Management.Models.ManagementGroupExpandType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementGroupParentCreateOptions
    {
        public ManagementGroupParentCreateOptions() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
    }
    public partial class ManagementGroupPathElement
    {
        internal ManagementGroupPathElement() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ManagementGroupsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Management.ManagementGroup>
    {
        protected ManagementGroupsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Management.ManagementGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Management.ManagementGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Management.ManagementGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ParentGroupInfo
    {
        internal ParentGroupInfo() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class PatchManagementGroupOptions
    {
        public PatchManagementGroupOptions() { }
        public string DisplayName { get { throw null; } set { } }
        public string ParentGroupId { get { throw null; } set { } }
    }
    public enum Reason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
}
namespace Azure.ResourceManager.Resources
{
    public partial class Feature : Azure.ResourceManager.Resources.FeatureOperations
    {
        protected Feature() { }
        public virtual Azure.ResourceManager.Resources.FeatureData Data { get { throw null; } }
    }
    public partial class FeatureContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected FeatureContainer() { }
        protected new Azure.ResourceManager.Resources.ProviderOperations Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Feature> Get(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Feature> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Feature> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Feature>> GetAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Feature> GetIfExists(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Feature>> GetIfExistsAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FeatureData : Azure.ResourceManager.Resources.Models.Resource
    {
        internal FeatureData() { }
        public Azure.ResourceManager.Resources.Models.FeatureProperties Properties { get { throw null; } }
    }
    public partial class FeatureOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected FeatureOperations() { }
        protected FeatureOperations(Azure.ResourceManager.Core.ResourceOperations options, Azure.ResourceManager.ResourceIdentifier id) { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Feature> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Feature>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Feature> Register(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Feature>> RegisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Feature> Unregister(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Feature>> UnregisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override void ValidateResourceType(Azure.ResourceManager.ResourceIdentifier identifier) { }
    }
    public partial class GenericResource : Azure.ResourceManager.Resources.GenericResourceOperations
    {
        protected GenericResource() { }
        public virtual Azure.ResourceManager.Resources.GenericResourceData Data { get { throw null; } }
    }
    public partial class GenericResourceContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected GenericResourceContainer() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> CreateOrUpdate(string resourceId, Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> CreateOrUpdateAsync(string resourceId, Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.Resources.GenericResource> Get(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResourceExpanded> GetAll(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResourceExpanded> GetAllAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> GetAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResourceExpanded> GetByResourceGroup(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResourceExpanded> GetByResourceGroupAsync(string resourceGroupName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> GetIfExists(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> GetIfExistsAsync(string resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ResourcesCreateOrUpdateByIdOperation StartCreateOrUpdate(string resourceId, Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ResourcesCreateOrUpdateByIdOperation> StartCreateOrUpdateAsync(string resourceId, Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override void ValidateResourceType(Azure.ResourceManager.ResourceIdentifier identifier) { }
    }
    public partial class GenericResourceData : Azure.ResourceManager.Resources.Models.TrackedResource
    {
        public GenericResourceData() { }
        public Azure.ResourceManager.Resources.Models.ResourceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.Plan Plan { get { throw null; } set { } }
        public object Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.Sku Sku { get { throw null; } set { } }
    }
    public partial class GenericResourceExpanded : Azure.ResourceManager.Resources.GenericResourceOperations
    {
        protected GenericResourceExpanded() { }
        public virtual Azure.ResourceManager.Resources.GenericResourceExpandedData Data { get { throw null; } }
    }
    public partial class GenericResourceExpandedData : Azure.ResourceManager.Resources.GenericResourceData
    {
        public GenericResourceExpandedData() { }
        public System.DateTimeOffset? ChangedTime { get { throw null; } }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class GenericResourceOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        protected GenericResourceOperations() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ResourcesDeleteByIdOperation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ResourcesDeleteByIdOperation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ResourcesUpdateByIdOperation StartUpdate(Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ResourcesUpdateByIdOperation> StartUpdateAsync(Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> Update(Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> UpdateAsync(Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override void ValidateResourceType(Azure.ResourceManager.ResourceIdentifier identifier) { }
    }
    public partial class PredefinedTag : Azure.ResourceManager.Resources.PredefinedTagOperations
    {
        protected PredefinedTag() { }
        public virtual Azure.ResourceManager.Resources.PredefinedTagData Data { get { throw null; } }
    }
    public partial class PredefinedTagContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected PredefinedTagContainer() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PredefinedTag> CreateOrUpdate(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PredefinedTag>> CreateOrUpdateAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.PredefinedTag> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.PredefinedTag> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Resources.Models.PredefinedTagCreateOrUpdateOperation StartCreateOrUpdate(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.PredefinedTagCreateOrUpdateOperation> StartCreateOrUpdateAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PredefinedTagData : Azure.ResourceManager.Resources.Models.SubResource
    {
        internal PredefinedTagData() { }
        public Azure.ResourceManager.Resources.Models.PredefinedTagCount Count { get { throw null; } }
        public string TagName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PredefinedTagValue> Values { get { throw null; } }
    }
    public partial class PredefinedTagOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PredefinedTagOperations() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PredefinedTagValue> CreateOrUpdateValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PredefinedTagValue>> CreateOrUpdateValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.PredefinedTagDeleteOperation StartDelete(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.PredefinedTagDeleteOperation> StartDeleteAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override void ValidateResourceType(Azure.ResourceManager.ResourceIdentifier identifier) { }
    }
    public partial class Provider : Azure.ResourceManager.Resources.ProviderOperations
    {
        protected Provider() { }
        public virtual Azure.ResourceManager.Resources.ProviderData Data { get { throw null; } }
    }
    public partial class ProviderContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected ProviderContainer() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Provider> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Provider> GetAll(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Provider> GetAllAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Provider>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Provider> GetIfExists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Provider>> GetIfExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProviderData : Azure.ResourceManager.Resources.Models.SubResource
    {
        internal ProviderData() { }
        public string Namespace { get { throw null; } }
        public string RegistrationPolicy { get { throw null; } }
        public string RegistrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ProviderOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ProviderOperations() { }
        protected ProviderOperations(Azure.ResourceManager.Core.ResourceOperations operations, Azure.ResourceManager.ResourceIdentifier id) { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Provider> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Provider>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.FeatureContainer GetFeatures() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Provider> Register(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Provider>> RegisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Provider> Unregister(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Provider>> UnregisterAsync(string resourceProviderNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroup : Azure.ResourceManager.Resources.ResourceGroupOperations
    {
        protected ResourceGroup() { }
        public virtual Azure.ResourceManager.Resources.ResourceGroupData Data { get { throw null; } }
    }
    public partial class ResourceGroupContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected ResourceGroupContainer() { }
        protected new Azure.ResourceManager.Resources.SubscriptionOperations Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.Resources.ResourceGroup> CreateOrUpdate(string name, Azure.ResourceManager.Resources.ResourceGroupData resourceDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> CreateOrUpdateAsync(string name, Azure.ResourceManager.Resources.ResourceGroupData resourceDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.Resources.ResourceGroup> Get(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ResourceGroup> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ResourceGroup> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> GetAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroup> GetIfExists(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> GetIfExistsAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.Resources.Models.ResourceGroupCreateOrUpdateOperation StartCreateOrUpdate(string name, Azure.ResourceManager.Resources.ResourceGroupData resourceDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ResourceGroupCreateOrUpdateOperation> StartCreateOrUpdateAsync(string name, Azure.ResourceManager.Resources.ResourceGroupData resourceDetails, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupData : Azure.ResourceManager.Resources.Models.TrackedResource
    {
        public ResourceGroupData(string location) { }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ResourceGroupProperties Properties { get { throw null; } set { } }
    }
    public partial class ResourceGroupOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ResourceGroupOperations() { }
        protected ResourceGroupOperations(Azure.ResourceManager.Core.ResourceOperations options, Azure.ResourceManager.ResourceIdentifier id) { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroup> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response MoveResources(Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MoveResourcesAsync(Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroup> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroup> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ResourceGroupDeleteOperation StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ResourceGroupDeleteOperation> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ResourceGroupsExportTemplateOperation StartExportTemplate(Azure.ResourceManager.Resources.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ResourceGroupsExportTemplateOperation> StartExportTemplateAsync(Azure.ResourceManager.Resources.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ResourcesMoveResourcesOperation StartMoveResources(Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ResourcesMoveResourcesOperation> StartMoveResourcesAsync(Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ResourcesValidateMoveResourcesOperation StartValidateMoveResources(Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ResourcesValidateMoveResourcesOperation> StartValidateMoveResourcesAsync(Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroup> Update(Azure.ResourceManager.Resources.Models.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> UpdateAsync(Azure.ResourceManager.Resources.Models.ResourceGroupPatchable parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T UseClientContext<T>(System.Func<System.Uri, Azure.Core.TokenCredential, Azure.ResourceManager.ArmClientOptions, Azure.Core.Pipeline.HttpPipeline, T> func) { throw null; }
        public virtual Azure.Response ValidateMoveResources(Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateMoveResourcesAsync(Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestApiContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected RestApiContainer() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.RestApi> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.RestApi> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Subscription : Azure.ResourceManager.Resources.SubscriptionOperations
    {
        protected Subscription() { }
        public virtual Azure.ResourceManager.Resources.SubscriptionData Data { get { throw null; } }
    }
    public partial class SubscriptionContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected SubscriptionContainer() { }
        protected new Azure.ResourceManager.Resources.TenantOperations Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.Response<Azure.ResourceManager.Resources.Subscription> Get(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Subscription> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Subscription> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Subscription>> GetAsync(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Subscription> GetIfExists(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Subscription>> GetIfExistsAsync(string subscriptionGuid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionData : Azure.ResourceManager.Resources.Models.TrackedResource
    {
        internal SubscriptionData() { }
        public string AuthorizationSource { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ManagedByTenant> ManagedByTenants { get { throw null; } }
        public override string Name { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SubscriptionState? State { get { throw null; } }
        public string SubscriptionGuid { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SubscriptionPolicies SubscriptionPolicies { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class SubscriptionOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected SubscriptionOperations() { }
        protected SubscriptionOperations(Azure.ResourceManager.Core.ResourceOperations operations, Azure.ResourceManager.ResourceIdentifier id) { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Subscription> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Subscription>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Feature> GetFeatures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Feature> GetFeaturesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.GenericResourceContainer GetGenericResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.LocationExpanded> GetLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.LocationExpanded> GetLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.PredefinedTagOperations GetPreDefinedTagOperations() { throw null; }
        public virtual Azure.ResourceManager.Resources.PredefinedTagContainer GetPredefinedTags() { throw null; }
        public virtual Azure.ResourceManager.Resources.ProviderContainer GetProviders() { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceGroupContainer GetResourceGroups() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T UseClientContext<T>(System.Func<System.Uri, Azure.Core.TokenCredential, Azure.ResourceManager.ArmClientOptions, Azure.Core.Pipeline.HttpPipeline, T> func) { throw null; }
    }
    public partial class TagResource : Azure.ResourceManager.Resources.TagResourceOperations
    {
        internal TagResource() { }
        public Azure.ResourceManager.Resources.TagResourceData Data { get { throw null; } }
    }
    public partial class TagResourceContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected TagResourceContainer() { }
        public new Azure.ResourceManager.ResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TagResource> CreateOrUpdate(Azure.ResourceManager.Resources.TagResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TagResource>> CreateOrUpdateAsync(Azure.ResourceManager.Resources.TagResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.TagCreateOrUpdateOperation StartCreateOrUpdate(Azure.ResourceManager.Resources.TagResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.TagCreateOrUpdateOperation> StartCreateOrUpdateAsync(Azure.ResourceManager.Resources.TagResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagResourceData : Azure.ResourceManager.Resources.Models.Resource
    {
        public TagResourceData(Azure.ResourceManager.Resources.Models.Tag properties) { }
        public Azure.ResourceManager.Resources.Models.Tag Properties { get { throw null; } set { } }
    }
    public partial class TagResourceOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        protected TagResourceOperations() { }
        public new Azure.ResourceManager.ResourceIdentifier Id { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartDelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartDeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.TagCreateOrUpdateOperation StartUpdate(Azure.ResourceManager.Resources.Models.TagPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.TagCreateOrUpdateOperation> StartUpdateAsync(Azure.ResourceManager.Resources.Models.TagPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TagResource> Update(Azure.ResourceManager.Resources.Models.TagPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TagResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.TagPatchResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Tenant : Azure.ResourceManager.Resources.TenantOperations
    {
        protected Tenant() { }
        public virtual Azure.ResourceManager.Resources.TenantData Data { get { throw null; } }
    }
    public partial class TenantContainer : Azure.ResourceManager.Core.ResourceContainer
    {
        protected TenantContainer() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Tenant> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Tenant> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantData
    {
        internal TenantData() { }
        public string Country { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Domains { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TenantCategory? TenantCategory { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class TenantOperations : Azure.ResourceManager.Core.ResourceOperations
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected TenantOperations() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.Management.ManagementGroupContainer GetManagementGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ProviderInfo> GetProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ProviderInfo>> GetProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ProviderInfo> GetProviders(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ProviderInfo> GetProvidersAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionContainer GetSubscriptions() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T UseClientContext<T>(System.Func<System.Uri, Azure.Core.TokenCredential, Azure.ResourceManager.ArmClientOptions, Azure.Core.Pipeline.HttpPipeline, T> func) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Models
{
    public partial class Alias
    {
        internal Alias() { }
        public string DefaultPath { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AliasPattern DefaultPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.AliasPath> Paths { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AliasType? Type { get { throw null; } }
    }
    public partial class AliasPath
    {
        internal AliasPath() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AliasPattern Pattern { get { throw null; } }
    }
    public partial class AliasPattern
    {
        internal AliasPattern() { }
        public string Phrase { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AliasPatternType? Type { get { throw null; } }
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
    public partial class ErrorAdditionalInfo
    {
        internal ErrorAdditionalInfo() { }
        public object Info { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ErrorResponse> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ExportTemplateRequest
    {
        public ExportTemplateRequest() { }
        public string Options { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } }
    }
    public partial class FeatureProperties
    {
        internal FeatureProperties() { }
        public string State { get { throw null; } }
    }
    public partial class Location : System.IComparable<Azure.ResourceManager.Resources.Models.Location>, System.IEquatable<Azure.ResourceManager.Resources.Models.Location>
    {
        public static readonly Azure.ResourceManager.Resources.Models.Location AustraliaCentral;
        public static readonly Azure.ResourceManager.Resources.Models.Location AustraliaCentral2;
        public static readonly Azure.ResourceManager.Resources.Models.Location AustraliaEast;
        public static readonly Azure.ResourceManager.Resources.Models.Location AustraliaSoutheast;
        public static readonly Azure.ResourceManager.Resources.Models.Location BrazilSouth;
        public static readonly Azure.ResourceManager.Resources.Models.Location BrazilSoutheast;
        public static readonly Azure.ResourceManager.Resources.Models.Location CanadaCentral;
        public static readonly Azure.ResourceManager.Resources.Models.Location CanadaEast;
        public static readonly Azure.ResourceManager.Resources.Models.Location CentralIndia;
        public static readonly Azure.ResourceManager.Resources.Models.Location CentralUS;
        public static readonly Azure.ResourceManager.Resources.Models.Location EastAsia;
        public static readonly Azure.ResourceManager.Resources.Models.Location EastUS;
        public static readonly Azure.ResourceManager.Resources.Models.Location EastUS2;
        public static readonly Azure.ResourceManager.Resources.Models.Location FranceCentral;
        public static readonly Azure.ResourceManager.Resources.Models.Location FranceSouth;
        public static readonly Azure.ResourceManager.Resources.Models.Location GermanyNorth;
        public static readonly Azure.ResourceManager.Resources.Models.Location GermanyWestCentral;
        public static readonly Azure.ResourceManager.Resources.Models.Location JapanEast;
        public static readonly Azure.ResourceManager.Resources.Models.Location JapanWest;
        public static readonly Azure.ResourceManager.Resources.Models.Location KoreaCentral;
        public static readonly Azure.ResourceManager.Resources.Models.Location KoreaSouth;
        public static readonly Azure.ResourceManager.Resources.Models.Location NorthCentralUS;
        public static readonly Azure.ResourceManager.Resources.Models.Location NorthEurope;
        public static readonly Azure.ResourceManager.Resources.Models.Location NorwayWest;
        public static readonly Azure.ResourceManager.Resources.Models.Location SouthAfricaNorth;
        public static readonly Azure.ResourceManager.Resources.Models.Location SouthAfricaWest;
        public static readonly Azure.ResourceManager.Resources.Models.Location SouthCentralUS;
        public static readonly Azure.ResourceManager.Resources.Models.Location SoutheastAsia;
        public static readonly Azure.ResourceManager.Resources.Models.Location SouthIndia;
        public static readonly Azure.ResourceManager.Resources.Models.Location SwitzerlandNorth;
        public static readonly Azure.ResourceManager.Resources.Models.Location SwitzerlandWest;
        public static readonly Azure.ResourceManager.Resources.Models.Location UAECentral;
        public static readonly Azure.ResourceManager.Resources.Models.Location UAENorth;
        public static readonly Azure.ResourceManager.Resources.Models.Location UKSouth;
        public static readonly Azure.ResourceManager.Resources.Models.Location UKWest;
        public static readonly Azure.ResourceManager.Resources.Models.Location WestCentralUS;
        public static readonly Azure.ResourceManager.Resources.Models.Location WestEurope;
        public static readonly Azure.ResourceManager.Resources.Models.Location WestIndia;
        public static readonly Azure.ResourceManager.Resources.Models.Location WestUS;
        public static readonly Azure.ResourceManager.Resources.Models.Location WestUS2;
        protected Location() { }
        public string CanonicalName { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public string RegionalDisplayName { get { throw null; } }
        public int CompareTo(Azure.ResourceManager.Resources.Models.Location other) { throw null; }
        public bool Equals(Azure.ResourceManager.Resources.Models.Location other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.Location left, Azure.ResourceManager.Resources.Models.Location right) { throw null; }
        public static bool operator >(Azure.ResourceManager.Resources.Models.Location left, Azure.ResourceManager.Resources.Models.Location right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.Resources.Models.Location left, Azure.ResourceManager.Resources.Models.Location right) { throw null; }
        public static implicit operator string (Azure.ResourceManager.Resources.Models.Location other) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.Location (string other) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.Location left, Azure.ResourceManager.Resources.Models.Location right) { throw null; }
        public static bool operator <(Azure.ResourceManager.Resources.Models.Location left, Azure.ResourceManager.Resources.Models.Location right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.Resources.Models.Location left, Azure.ResourceManager.Resources.Models.Location right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocationExpanded : Azure.ResourceManager.Resources.Models.Location
    {
        protected LocationExpanded() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.LocationMetadata Metadata { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class LocationMetadata
    {
        internal LocationMetadata() { }
        public string GeographyGroup { get { throw null; } }
        public string Latitude { get { throw null; } }
        public string Longitude { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PairedRegion> PairedRegion { get { throw null; } }
        public string PhysicalLocation { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RegionCategory? RegionCategory { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RegionType? RegionType { get { throw null; } }
    }
    public partial class ManagedByTenant
    {
        internal ManagedByTenant() { }
        public string TenantId { get { throw null; } }
    }
    public partial class PairedRegion
    {
        internal PairedRegion() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public sealed partial class Plan : System.IComparable<Azure.ResourceManager.Resources.Models.Plan>, System.IEquatable<Azure.ResourceManager.Resources.Models.Plan>
    {
        public Plan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public int CompareTo(Azure.ResourceManager.Resources.Models.Plan other) { throw null; }
        public bool Equals(Azure.ResourceManager.Resources.Models.Plan other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.Plan left, Azure.ResourceManager.Resources.Models.Plan right) { throw null; }
        public static bool operator >(Azure.ResourceManager.Resources.Models.Plan left, Azure.ResourceManager.Resources.Models.Plan right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.Resources.Models.Plan left, Azure.ResourceManager.Resources.Models.Plan right) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.Plan left, Azure.ResourceManager.Resources.Models.Plan right) { throw null; }
        public static bool operator <(Azure.ResourceManager.Resources.Models.Plan left, Azure.ResourceManager.Resources.Models.Plan right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.Resources.Models.Plan left, Azure.ResourceManager.Resources.Models.Plan right) { throw null; }
    }
    public partial class PredefinedTagCount
    {
        internal PredefinedTagCount() { }
        public string Type { get { throw null; } }
        public int? Value { get { throw null; } }
    }
    public partial class PredefinedTagCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.PredefinedTag>
    {
        protected PredefinedTagCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.PredefinedTag Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.PredefinedTag>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.PredefinedTag>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PredefinedTagDeleteOperation : Azure.Operation
    {
        protected PredefinedTagDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PredefinedTagValue
    {
        internal PredefinedTagValue() { }
        public Azure.ResourceManager.Resources.Models.PredefinedTagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagValueValue { get { throw null; } }
    }
    public partial class ProviderInfo
    {
        internal ProviderInfo() { }
        public string Namespace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ProviderResourceType
    {
        internal ProviderResourceType() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Alias> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionCategory : System.IEquatable<Azure.ResourceManager.Resources.Models.RegionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionCategory(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.RegionCategory Other { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.RegionCategory Recommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.RegionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.RegionCategory left, Azure.ResourceManager.Resources.Models.RegionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.RegionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.RegionCategory left, Azure.ResourceManager.Resources.Models.RegionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionType : System.IEquatable<Azure.ResourceManager.Resources.Models.RegionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.RegionType Logical { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.RegionType Physical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.RegionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.RegionType left, Azure.ResourceManager.Resources.Models.RegionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.RegionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.RegionType left, Azure.ResourceManager.Resources.Models.RegionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class Resource
    {
        protected Resource() { }
        protected internal Resource(Azure.ResourceManager.ResourceIdentifier id, string name, Azure.ResourceManager.ResourceType type) { }
        public virtual Azure.ResourceManager.ResourceIdentifier Id { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual Azure.ResourceManager.ResourceType Type { get { throw null; } }
    }
    public partial class ResourceGroupCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.ResourceGroup>
    {
        protected ResourceGroupCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.ResourceGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.ResourceGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Resources.Models.ErrorResponse Error { get { throw null; } }
        public object Template { get { throw null; } }
    }
    public partial class ResourceGroupPatchable
    {
        public ResourceGroupPatchable() { }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ResourceGroupProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ResourceGroupProperties
    {
        public ResourceGroupProperties() { }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ResourceGroupsExportTemplateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>
    {
        protected ResourceGroupsExportTemplateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.ResourceGroupExportResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceIdentity : System.IEquatable<Azure.ResourceManager.Resources.Models.ResourceIdentity>
    {
        public ResourceIdentity() { }
        public ResourceIdentity(System.Collections.Generic.Dictionary<Azure.ResourceManager.ResourceIdentifier, Azure.ResourceManager.Resources.Models.UserAssignedIdentity> user, bool useSystemAssigned) { }
        public Azure.ResourceManager.Resources.Models.SystemAssignedIdentity SystemAssignedIdentity { get { throw null; } }
        public System.Collections.Generic.IDictionary<Azure.ResourceManager.ResourceIdentifier, Azure.ResourceManager.Resources.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ResourceIdentity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        None = 1,
        UserAssigned = 2,
        SystemAssignedUserAssigned = 3,
    }
    public partial class ResourcesCreateOrUpdateByIdOperation : Azure.Operation<Azure.ResourceManager.Resources.GenericResource>
    {
        protected ResourcesCreateOrUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ResourcesUpdateByIdOperation : Azure.Operation<Azure.ResourceManager.Resources.GenericResource>
    {
        protected ResourcesUpdateByIdOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.GenericResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public sealed partial class Sku : System.IComparable<Azure.ResourceManager.Resources.Models.Sku>, System.IEquatable<Azure.ResourceManager.Resources.Models.Sku>
    {
        public Sku() { }
        public long? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        public int CompareTo(Azure.ResourceManager.Resources.Models.Sku other) { throw null; }
        public bool Equals(Azure.ResourceManager.Resources.Models.Sku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.Sku left, Azure.ResourceManager.Resources.Models.Sku right) { throw null; }
        public static bool operator >(Azure.ResourceManager.Resources.Models.Sku left, Azure.ResourceManager.Resources.Models.Sku right) { throw null; }
        public static bool operator >=(Azure.ResourceManager.Resources.Models.Sku left, Azure.ResourceManager.Resources.Models.Sku right) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.Sku left, Azure.ResourceManager.Resources.Models.Sku right) { throw null; }
        public static bool operator <(Azure.ResourceManager.Resources.Models.Sku left, Azure.ResourceManager.Resources.Models.Sku right) { throw null; }
        public static bool operator <=(Azure.ResourceManager.Resources.Models.Sku left, Azure.ResourceManager.Resources.Models.Sku right) { throw null; }
    }
    public enum SpendingLimit
    {
        On = 0,
        Off = 1,
        CurrentPeriodOff = 2,
    }
    public partial class SubResource
    {
        protected SubResource() { }
        protected internal SubResource(string id) { }
        public virtual Azure.ResourceManager.ResourceIdentifier Id { get { throw null; } }
    }
    public partial class SubscriptionPolicies
    {
        internal SubscriptionPolicies() { }
        public string LocationPlacementId { get { throw null; } }
        public string QuotaId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SpendingLimit? SpendingLimit { get { throw null; } }
    }
    public enum SubscriptionState
    {
        Enabled = 0,
        Warned = 1,
        PastDue = 2,
        Disabled = 3,
        Deleted = 4,
    }
    public sealed partial class SystemAssignedIdentity : System.IEquatable<Azure.ResourceManager.Resources.Models.SystemAssignedIdentity>
    {
        public SystemAssignedIdentity() { }
        public SystemAssignedIdentity(System.Guid tenantId, System.Guid principalId) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public int CompareTo(Azure.ResourceManager.Resources.Models.SystemAssignedIdentity other) { throw null; }
        public bool Equals(Azure.ResourceManager.Resources.Models.SystemAssignedIdentity other) { throw null; }
        public static bool Equals(Azure.ResourceManager.Resources.Models.SystemAssignedIdentity original, Azure.ResourceManager.Resources.Models.SystemAssignedIdentity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
    public partial class Tag : Azure.ResourceManager.Resources.Models.Resource
    {
        public Tag() { }
        public System.Collections.Generic.IDictionary<string, string> TagsValue { get { throw null; } }
    }
    public partial class TagCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.TagResource>
    {
        protected TagCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.TagResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.TagResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.TagResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagPatchResource
    {
        public TagPatchResource() { }
        public Azure.ResourceManager.Resources.Models.TagPatchResourceOperation? Operation { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.Tag Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagPatchResourceOperation : System.IEquatable<Azure.ResourceManager.Resources.Models.TagPatchResourceOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagPatchResourceOperation(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TagPatchResourceOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.TagPatchResourceOperation Merge { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.TagPatchResourceOperation Replace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.TagPatchResourceOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.TagPatchResourceOperation left, Azure.ResourceManager.Resources.Models.TagPatchResourceOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.TagPatchResourceOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.TagPatchResourceOperation left, Azure.ResourceManager.Resources.Models.TagPatchResourceOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum TenantCategory
    {
        Home = 0,
        ProjectedBy = 1,
        ManagedBy = 2,
    }
    public abstract partial class TrackedResource : Azure.ResourceManager.Resources.Models.Resource
    {
        protected TrackedResource() { }
        protected internal TrackedResource(Azure.ResourceManager.ResourceIdentifier id, string name, Azure.ResourceManager.ResourceType type, Azure.ResourceManager.Resources.Models.Location location, System.Collections.Generic.IDictionary<string, string> tags) { }
        protected TrackedResource(Azure.ResourceManager.Resources.Models.Location location) { }
        public virtual Azure.ResourceManager.Resources.Models.Location Location { get { throw null; } set { } }
        public virtual System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public sealed partial class UserAssignedIdentity : System.IEquatable<Azure.ResourceManager.Resources.Models.UserAssignedIdentity>
    {
        public UserAssignedIdentity(System.Guid clientId, System.Guid principalId) { }
        public System.Guid ClientId { get { throw null; } }
        public System.Guid PrincipalId { get { throw null; } }
        public int CompareTo(Azure.ResourceManager.Resources.Models.UserAssignedIdentity other) { throw null; }
        public bool Equals(Azure.ResourceManager.Resources.Models.UserAssignedIdentity other) { throw null; }
        public static bool Equals(Azure.ResourceManager.Resources.Models.UserAssignedIdentity original, Azure.ResourceManager.Resources.Models.UserAssignedIdentity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
    public partial class WritableSubResource
    {
        public WritableSubResource() { }
        protected internal WritableSubResource(string id) { }
        public virtual Azure.ResourceManager.ResourceIdentifier Id { get { throw null; } set { } }
    }
}
