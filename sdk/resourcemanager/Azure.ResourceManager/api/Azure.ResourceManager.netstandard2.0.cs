namespace Azure.ResourceManager
{
    public partial class ArmClient
    {
        protected ArmClient() { }
        public ArmClient(Azure.Core.TokenCredential credential) { }
        public ArmClient(Azure.Core.TokenCredential credential, string defaultSubscriptionId) { }
        public ArmClient(Azure.Core.TokenCredential credential, string defaultSubscriptionId, Azure.ResourceManager.ArmClientOptions options) { }
        public virtual Azure.ResourceManager.Resources.DataPolicyManifestResource GetDataPolicyManifestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionResource GetDefaultSubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.SubscriptionResource> GetDefaultSubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.FeatureResource GetFeatureResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.GenericResource GetGenericResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.GenericResourceCollection GetGenericResources() { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource GetManagementGroupPolicyDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource GetManagementGroupPolicySetDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Management.ManagementGroupResource GetManagementGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Management.ManagementGroupCollection GetManagementGroups() { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementLockResource GetManagementLockResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.PolicyAssignmentResource GetPolicyAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.PolicyExemptionResource GetPolicyExemptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T GetResourceClient<T>(System.Func<T> resourceFactory) where T : Azure.ResourceManager.ArmResource { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceGroupResource GetResourceGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceLinkResource GetResourceLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceProviderResource GetResourceProviderResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource GetSubscriptionPolicyDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource GetSubscriptionPolicySetDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionResource GetSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionCollection GetSubscriptions() { throw null; }
        public virtual Azure.ResourceManager.Resources.TagResource GetTagResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantPolicyDefinitionResource GetTenantPolicyDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource GetTenantPolicySetDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ProviderInfo> GetTenantResourceProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ProviderInfo>> GetTenantResourceProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ProviderInfo> GetTenantResourceProviders(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ProviderInfo> GetTenantResourceProvidersAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantCollection GetTenants() { throw null; }
    }
    public sealed partial class ArmClientOptions : Azure.Core.ClientOptions
    {
        public ArmClientOptions() { }
        public Azure.ResourceManager.ArmEnvironment? Environment { get { throw null; } set { } }
        public void SetApiVersion(Azure.Core.ResourceType resourceType, string apiVersion) { }
    }
    public abstract partial class ArmCollection
    {
        protected ArmCollection() { }
        protected ArmCollection(Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { }
        protected internal virtual Azure.ResourceManager.ArmClient Client { get { throw null; } }
        protected internal Azure.Core.DiagnosticsOptions Diagnostics { get { throw null; } }
        protected internal System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected internal Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T GetCachedClient<T>(System.Func<Azure.ResourceManager.ArmClient, T> clientFactory) where T : class { throw null; }
        protected bool TryGetApiVersion(Azure.Core.ResourceType resourceType, out string apiVersion) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmEnvironment : System.IEquatable<Azure.ResourceManager.ArmEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly Azure.ResourceManager.ArmEnvironment AzureChina;
        public static readonly Azure.ResourceManager.ArmEnvironment AzureGermany;
        public static readonly Azure.ResourceManager.ArmEnvironment AzureGovernment;
        public static readonly Azure.ResourceManager.ArmEnvironment AzurePublicCloud;
        public ArmEnvironment(System.Uri endpoint, string audience) { throw null; }
        public string Audience { get { throw null; } }
        public string DefaultScope { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ArmEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ArmEnvironment left, Azure.ResourceManager.ArmEnvironment right) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ArmEnvironment left, Azure.ResourceManager.ArmEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ArmOperation : Azure.Operation
    {
        protected ArmOperation() { }
    }
    public abstract partial class ArmOperation<T> : Azure.Operation<T>
    {
        protected ArmOperation() { }
    }
    public abstract partial class ArmResource
    {
        protected ArmResource() { }
        protected internal ArmResource(Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { }
        protected internal virtual Azure.ResourceManager.ArmClient Client { get { throw null; } }
        protected internal Azure.Core.DiagnosticsOptions Diagnostics { get { throw null; } }
        protected internal System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected internal Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T GetCachedClient<T>(System.Func<Azure.ResourceManager.ArmClient, T> clientFactory) where T : class { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementLockResource> GetManagementLock(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementLockResource>> GetManagementLockAsync(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementLockCollection GetManagementLocks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource> GetPolicyAssignment(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource>> GetPolicyAssignmentAsync(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.PolicyAssignmentCollection GetPolicyAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PolicyExemptionResource> GetPolicyExemption(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PolicyExemptionResource>> GetPolicyExemptionAsync(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.PolicyExemptionCollection GetPolicyExemptions() { throw null; }
        public virtual Azure.ResourceManager.Resources.TagResource GetTagResource() { throw null; }
        protected virtual bool TryGetApiVersion(Azure.Core.ResourceType resourceType, out string apiVersion) { throw null; }
    }
}
namespace Azure.ResourceManager.Management
{
    public partial class ManagementGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Management.ManagementGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Management.ManagementGroupResource>, System.Collections.IEnumerable
    {
        protected ManagementGroupCollection() { }
        public virtual Azure.Response<Azure.ResourceManager.Management.Models.ManagementGroupNameAvailabilityResult> CheckManagementGroupNameAvailability(Azure.ResourceManager.Management.Models.ManagementGroupNameAvailabilityOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.Models.ManagementGroupNameAvailabilityResult>> CheckManagementGroupNameAvailabilityAsync(Azure.ResourceManager.Management.Models.ManagementGroupNameAvailabilityOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Management.ManagementGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupId, Azure.ResourceManager.Management.Models.CreateManagementGroupOptions options, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Management.ManagementGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupId, Azure.ResourceManager.Management.Models.CreateManagementGroupOptions options, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource> Get(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Management.ManagementGroupResource> GetAll(string cacheControl = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Management.ManagementGroupResource> GetAllAsync(string cacheControl = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource>> GetAsync(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource> GetIfExists(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource>> GetIfExistsAsync(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Management.ManagementGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Management.ManagementGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Management.ManagementGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Management.ManagementGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagementGroupData : Azure.ResourceManager.Models.ResourceData
    {
        internal ManagementGroupData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupChildInfo> Children { get { throw null; } }
        public Azure.ResourceManager.Management.Models.ManagementGroupInfo Details { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    public partial class ManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagementGroupResource() { }
        public virtual Azure.ResourceManager.Management.ManagementGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string groupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource> Get(Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource>> GetAsync(Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Management.Models.DescendantData> GetDescendants(string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Management.Models.DescendantData> GetDescendantsAsync(string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> GetManagementGroupPolicyDefinition(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>> GetManagementGroupPolicyDefinitionAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionCollection GetManagementGroupPolicyDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> GetManagementGroupPolicySetDefinition(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>> GetManagementGroupPolicySetDefinitionAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionCollection GetManagementGroupPolicySetDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource> Update(Azure.ResourceManager.Management.Models.PatchableManagementGroupData data, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource>> UpdateAsync(Azure.ResourceManager.Management.Models.PatchableManagementGroupData data, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Management.Models
{
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
        public string ResourceType { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    public partial class DescendantData : Azure.ResourceManager.Models.ResourceData
    {
        internal DescendantData() { }
        public string DisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ParentId { get { throw null; } }
    }
    public partial class DescendantParentGroupInfo
    {
        internal DescendantParentGroupInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
    }
    public partial class ManagementGroupChildInfo
    {
        internal ManagementGroupChildInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupChildInfo> Children { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Management.Models.ManagementGroupChildType? ManagementGroupChildType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ManagementGroupChildOptions
    {
        internal ManagementGroupChildOptions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupChildOptions> Children { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Management.Models.ManagementGroupChildType? ManagementGroupChildType { get { throw null; } }
        public string Name { get { throw null; } }
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
    public partial class ManagementGroupInfo
    {
        internal ManagementGroupInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupPathElement> ManagementGroupAncestorChain { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagementGroupAncestors { get { throw null; } }
        public Azure.ResourceManager.Management.Models.ParentManagementGroupInfo Parent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Management.Models.ManagementGroupPathElement> Path { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedTime { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class ManagementGroupNameAvailabilityOptions
    {
        public ManagementGroupNameAvailabilityOptions() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class ManagementGroupNameAvailabilityResult
    {
        internal ManagementGroupNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Management.Models.ManagementGroupNameUnavailableReason? Reason { get { throw null; } }
    }
    public enum ManagementGroupNameUnavailableReason
    {
        Invalid = 0,
        AlreadyExists = 1,
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
    public partial class ParentManagementGroupInfo
    {
        internal ParentManagementGroupInfo() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class PatchableManagementGroupData
    {
        public PatchableManagementGroupData() { }
        public string DisplayName { get { throw null; } set { } }
        public string ParentGroupId { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.Models
{
    public sealed partial class ArmPlan : System.IEquatable<Azure.ResourceManager.Models.ArmPlan>
    {
        public ArmPlan(string name, string publisher, string product) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public bool Equals(Azure.ResourceManager.Models.ArmPlan other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Models.ArmPlan left, Azure.ResourceManager.Models.ArmPlan right) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Models.ArmPlan left, Azure.ResourceManager.Models.ArmPlan right) { throw null; }
    }
    public sealed partial class ArmSku : System.IEquatable<Azure.ResourceManager.Models.ArmSku>
    {
        public ArmSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmSkuTier? Tier { get { throw null; } set { } }
        public bool Equals(Azure.ResourceManager.Models.ArmSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Models.ArmSku left, Azure.ResourceManager.Models.ArmSku right) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Models.ArmSku left, Azure.ResourceManager.Models.ArmSku right) { throw null; }
    }
    public enum ArmSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Models.CreatedByType left, Azure.ResourceManager.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Models.CreatedByType left, Azure.ResourceManager.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionProperties
    {
        public EncryptionProperties() { }
        public Azure.ResourceManager.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.EncryptionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionStatus : System.IEquatable<Azure.ResourceManager.Models.EncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Models.EncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Models.EncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Models.EncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Models.EncryptionStatus left, Azure.ResourceManager.Models.EncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Models.EncryptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Models.EncryptionStatus left, Azure.ResourceManager.Models.EncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ErrorAdditionalInfo
    {
        public ErrorAdditionalInfo() { }
        public string ErrorAdditionalInfoType { get { throw null; } }
        public System.BinaryData Info { get { throw null; } }
    }
    public partial class ErrorDetail
    {
        public ErrorDetail() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Models.ErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string Identity { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
    }
    public partial class ManagedServiceIdentity
    {
        public ManagedServiceIdentity(Azure.ResourceManager.Models.ManagedServiceIdentityType managedServiceIdentityType) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentityType ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<Azure.Core.ResourceIdentifier, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Models.ManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Models.ManagedServiceIdentityType left, Azure.ResourceManager.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ResourceData
    {
        protected ResourceData() { }
        protected ResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class SystemAssignedServiceIdentity
    {
        public SystemAssignedServiceIdentity(Azure.ResourceManager.Models.SystemAssignedServiceIdentityType systemAssignedServiceIdentityType) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentityType SystemAssignedServiceIdentityType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SystemAssignedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Models.SystemAssignedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SystemAssignedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Models.SystemAssignedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Models.SystemAssignedServiceIdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Models.SystemAssignedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Models.SystemAssignedServiceIdentityType left, Azure.ResourceManager.Models.SystemAssignedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Models.SystemAssignedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Models.SystemAssignedServiceIdentityType left, Azure.ResourceManager.Models.SystemAssignedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SystemData
    {
        public SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Models.CreatedByType? CreatedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.ResourceManager.Models.CreatedByType? LastModifiedByType { get { throw null; } }
    }
    public abstract partial class TrackedResourceData : Azure.ResourceManager.Models.ResourceData
    {
        protected TrackedResourceData(Azure.Core.AzureLocation location) { }
        protected TrackedResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location) { }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class UserAssignedIdentity
    {
        public UserAssignedIdentity() { }
        public System.Guid? ClientId { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
    }
}
namespace Azure.ResourceManager.Resources
{
    public partial class DataPolicyManifestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DataPolicyManifestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DataPolicyManifestResource>, System.Collections.IEnumerable
    {
        protected DataPolicyManifestCollection() { }
        public virtual Azure.Response<bool> Exists(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource> Get(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DataPolicyManifestResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DataPolicyManifestResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource>> GetAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource> GetIfExists(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource>> GetIfExistsAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DataPolicyManifestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DataPolicyManifestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DataPolicyManifestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DataPolicyManifestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataPolicyManifestData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataPolicyManifestData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition> Custom { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect> Effects { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FieldValues { get { throw null; } }
        public bool? IsBuiltInOnly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Namespaces { get { throw null; } }
        public string PolicyMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceTypeAliases> ResourceTypeAliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Standard { get { throw null; } }
    }
    public partial class DataPolicyManifestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataPolicyManifestResource() { }
        public virtual Azure.ResourceManager.Resources.DataPolicyManifestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string policyMode) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FeatureCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.FeatureResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.FeatureResource>, System.Collections.IEnumerable
    {
        protected FeatureCollection() { }
        public virtual Azure.Response<bool> Exists(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.FeatureResource> Get(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.FeatureResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.FeatureResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.FeatureResource>> GetAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.FeatureResource> GetIfExists(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.FeatureResource>> GetIfExistsAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.FeatureResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.FeatureResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.FeatureResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.FeatureResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FeatureData : Azure.ResourceManager.Models.ResourceData
    {
        internal FeatureData() { }
        public string FeatureState { get { throw null; } }
    }
    public partial class FeatureResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FeatureResource() { }
        public virtual Azure.ResourceManager.Resources.FeatureData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceProviderNamespace, string featureName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.FeatureResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.FeatureResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.FeatureResource> Register(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.FeatureResource>> RegisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.FeatureResource> Unregister(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.FeatureResource>> UnregisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GenericResource : Azure.ResourceManager.ArmResource
    {
        protected GenericResource() { }
        public virtual Azure.ResourceManager.Resources.GenericResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.GenericResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.GenericResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GenericResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected GenericResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.GenericResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.GenericResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.Resources.GenericResourceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> Get(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> GetAsync(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> GetIfExists(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> GetIfExistsAsync(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GenericResourceData : Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData
    {
        public GenericResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? ChangedTime { get { throw null; } }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourcesSku Sku { get { throw null; } set { } }
    }
    public partial class ManagementGroupPolicyDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>, System.Collections.IEnumerable
    {
        protected ManagementGroupPolicyDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyDefinitionName, Azure.ResourceManager.Resources.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyDefinitionName, Azure.ResourceManager.Resources.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> Get(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>> GetAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> GetIfExists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>> GetIfExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagementGroupPolicyDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagementGroupPolicyDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.PolicyDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string policyDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementGroupPolicySetDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>, System.Collections.IEnumerable
    {
        protected ManagementGroupPolicySetDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policySetDefinitionName, Azure.ResourceManager.Resources.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policySetDefinitionName, Azure.ResourceManager.Resources.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> Get(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>> GetAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> GetIfExists(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>> GetIfExistsAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagementGroupPolicySetDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagementGroupPolicySetDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.PolicySetDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string policySetDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementLockCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ManagementLockResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ManagementLockResource>, System.Collections.IEnumerable
    {
        protected ManagementLockCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementLockResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string lockName, Azure.ResourceManager.Resources.ManagementLockData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementLockResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string lockName, Azure.ResourceManager.Resources.ManagementLockData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementLockResource> Get(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ManagementLockResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ManagementLockResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementLockResource>> GetAsync(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementLockResource> GetIfExists(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementLockResource>> GetIfExistsAsync(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ManagementLockResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ManagementLockResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ManagementLockResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ManagementLockResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagementLockData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagementLockData(Azure.ResourceManager.Resources.Models.ManagementLockLevel level) { }
        public Azure.ResourceManager.Resources.Models.ManagementLockLevel Level { get { throw null; } set { } }
        public string Notes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ManagementLockOwner> Owners { get { throw null; } }
    }
    public partial class ManagementLockResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagementLockResource() { }
        public virtual Azure.ResourceManager.Resources.ManagementLockData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string lockName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementLockResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementLockResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.PolicyAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.PolicyAssignmentResource>, System.Collections.IEnumerable
    {
        protected PolicyAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.PolicyAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyAssignmentName, Azure.ResourceManager.Resources.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.PolicyAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyAssignmentName, Azure.ResourceManager.Resources.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource> Get(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.PolicyAssignmentResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.PolicyAssignmentResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource>> GetAsync(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource> GetIfExists(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource>> GetIfExistsAsync(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.PolicyAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.PolicyAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.PolicyAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.PolicyAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public PolicyAssignmentData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.EnforcementMode? EnforcementMode { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.NonComplianceMessage> NonComplianceMessages { get { throw null; } }
        public System.Collections.Generic.IList<string> NotScopes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue> Parameters { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } }
    }
    public partial class PolicyAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyAssignmentResource() { }
        public virtual Azure.ResourceManager.Resources.PolicyAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string policyAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.PolicyAssignmentResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.PolicyAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public PolicyDefinitionData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameter> Parameters { get { throw null; } }
        public System.BinaryData PolicyRule { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.PolicyType? PolicyType { get { throw null; } set { } }
    }
    public partial class PolicyExemptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.PolicyExemptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.PolicyExemptionResource>, System.Collections.IEnumerable
    {
        protected PolicyExemptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.PolicyExemptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyExemptionName, Azure.ResourceManager.Resources.PolicyExemptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.PolicyExemptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyExemptionName, Azure.ResourceManager.Resources.PolicyExemptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PolicyExemptionResource> Get(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.PolicyExemptionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.PolicyExemptionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PolicyExemptionResource>> GetAsync(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PolicyExemptionResource> GetIfExists(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PolicyExemptionResource>> GetIfExistsAsync(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.PolicyExemptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.PolicyExemptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.PolicyExemptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.PolicyExemptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyExemptionData : Azure.ResourceManager.Models.ResourceData
    {
        public PolicyExemptionData(string policyAssignmentId, Azure.ResourceManager.Resources.Models.ExemptionCategory exemptionCategory) { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExemptionCategory ExemptionCategory { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string PolicyAssignmentId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PolicyDefinitionReferenceIds { get { throw null; } }
    }
    public partial class PolicyExemptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyExemptionResource() { }
        public virtual Azure.ResourceManager.Resources.PolicyExemptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string policyExemptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PolicyExemptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PolicyExemptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicySetDefinitionData : Azure.ResourceManager.Models.ResourceData
    {
        public PolicySetDefinitionData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.PolicyType? PolicyType { get { throw null; } set { } }
    }
    public partial class ResourceGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ResourceGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceGroupResource>, System.Collections.IEnumerable
    {
        protected ResourceGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ResourceGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGroupName, Azure.ResourceManager.Resources.ResourceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ResourceGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGroupName, Azure.ResourceManager.Resources.ResourceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> Get(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ResourceGroupResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ResourceGroupResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> GetAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> GetIfExists(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> GetIfExistsAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ResourceGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ResourceGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ResourceGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ResourceGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ManagedBy { get { throw null; } set { } }
        public string ResourceGroupProvisioningState { get { throw null; } }
    }
    public partial class ResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupResource() { }
        public virtual Azure.ResourceManager.Resources.ResourceGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string forceDeletionTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string forceDeletionTypes = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult> ExportTemplate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>> ExportTemplateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ExportTemplateRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetGenericResources(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetGenericResourcesAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MoveResources(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MoveResourcesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> Update(Azure.ResourceManager.Resources.Models.PatchableResourceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.PatchableResourceGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ValidateMoveResources(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ValidateMoveResourcesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ResourcesMoveInfo parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceLinkCollection : Azure.ResourceManager.ArmCollection
    {
        protected ResourceLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ResourceLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.ResourceLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ResourceLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.ResourceLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ResourceLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ResourceLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceLinkResource> GetIfExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceLinkResource>> GetIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public ResourceLinkData() { }
        public Azure.ResourceManager.Resources.Models.ResourceLinkProperties Properties { get { throw null; } set { } }
    }
    public partial class ResourceLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceLinkResource() { }
        public virtual Azure.ResourceManager.Resources.ResourceLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string linkId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceProviderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ResourceProviderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceProviderResource>, System.Collections.IEnumerable
    {
        protected ResourceProviderCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ResourceProviderResource> GetAll(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ResourceProviderResource> GetAllAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> GetIfExists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> GetIfExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ResourceProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ResourceProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ResourceProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceProviderData
    {
        public ResourceProviderData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState? ProviderAuthorizationConsentState { get { throw null; } }
        public string RegistrationPolicy { get { throw null; } }
        public string RegistrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ResourceProviderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceProviderResource() { }
        public virtual Azure.ResourceManager.Resources.ResourceProviderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceProviderNamespace) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.FeatureResource> GetFeature(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.FeatureResource>> GetFeatureAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.FeatureCollection GetFeatures() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ProviderResourceType> GetProviderResourceTypes(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ProviderResourceType> GetProviderResourceTypesAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ProviderPermission> ProviderPermissions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ProviderPermission> ProviderPermissionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> Register(Azure.ResourceManager.Resources.Models.ResourceProviderRegistrationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> RegisterAsync(Azure.ResourceManager.Resources.Models.ResourceProviderRegistrationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> Unregister(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> UnregisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestApiCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Models.RestApi>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.RestApi>, System.Collections.IEnumerable
    {
        protected RestApiCollection() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.RestApi> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.RestApi> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Models.RestApi> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Models.RestApi>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Models.RestApi> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.RestApi>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.SubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.SubscriptionResource>, System.Collections.IEnumerable
    {
        protected SubscriptionCollection() { }
        public virtual Azure.Response<bool> Exists(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource> Get(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.SubscriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.SubscriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource>> GetAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource> GetIfExists(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource>> GetIfExistsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.SubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.SubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.SubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.SubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionData
    {
        internal SubscriptionData() { }
        public string AuthorizationSource { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public virtual Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ManagedByTenant> ManagedByTenants { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SubscriptionState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SubscriptionPolicies SubscriptionPolicies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    public partial class SubscriptionPolicyDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>, System.Collections.IEnumerable
    {
        protected SubscriptionPolicyDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyDefinitionName, Azure.ResourceManager.Resources.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyDefinitionName, Azure.ResourceManager.Resources.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> Get(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>> GetAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> GetIfExists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>> GetIfExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionPolicyDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionPolicyDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.PolicyDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string policyDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionPolicySetDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>, System.Collections.IEnumerable
    {
        protected SubscriptionPolicySetDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policySetDefinitionName, Azure.ResourceManager.Resources.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policySetDefinitionName, Azure.ResourceManager.Resources.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> Get(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>> GetAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> GetIfExists(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>> GetIfExistsAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionPolicySetDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionPolicySetDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.PolicySetDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string policySetDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionResource() { }
        public virtual Azure.ResourceManager.Resources.SubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PredefinedTag> CreateOrUpdatePredefinedTag(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PredefinedTag>> CreateOrUpdatePredefinedTagAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.PredefinedTagValue> CreateOrUpdatePredefinedTagValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.PredefinedTagValue>> CreateOrUpdatePredefinedTagValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.Response DeletePredefinedTag(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePredefinedTagAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeletePredefinedTagValue(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePredefinedTagValueAsync(string tagName, string tagValue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.PredefinedTag> GetAllPredefinedTags(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.PredefinedTag> GetAllPredefinedTagsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.FeatureResource> GetFeatures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.FeatureResource> GetFeaturesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetGenericResources(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetGenericResourcesAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.LocationExpanded> GetLocations(bool? includeExtendedLocations = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.LocationExpanded> GetLocationsAsync(bool? includeExtendedLocations = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> GetResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> GetResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceGroupCollection GetResourceGroups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ResourceLinkResource> GetResourceLinks(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ResourceLinkResource> GetResourceLinksAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> GetResourceProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> GetResourceProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceProviderCollection GetResourceProviders() { throw null; }
        public virtual Azure.ResourceManager.Resources.RestApiCollection GetRestApis(string azureNamespace) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> GetSubscriptionPolicyDefinition(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>> GetSubscriptionPolicyDefinitionAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionCollection GetSubscriptionPolicyDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> GetSubscriptionPolicySetDefinition(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>> GetSubscriptionPolicySetDefinitionAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionCollection GetSubscriptionPolicySetDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TagResource() { }
        public virtual Azure.ResourceManager.Resources.TagResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TagResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.TagResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TagResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.TagResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TagResource> Update(Azure.ResourceManager.Resources.Models.PatchableTagResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TagResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.PatchableTagResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public TagResourceData(Azure.ResourceManager.Resources.Models.Tag properties) { }
        public System.Collections.Generic.IDictionary<string, string> TagValues { get { throw null; } }
    }
    public partial class TenantCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantResource>, System.Collections.IEnumerable
    {
        protected TenantCollection() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TenantResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TenantResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TenantResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TenantResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantData
    {
        internal TenantData() { }
        public string Country { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string DefaultDomain { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Domains { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Uri TenantBrandingLogoUri { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TenantCategory? TenantCategory { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string TenantType { get { throw null; } }
    }
    public partial class TenantPolicyDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>, System.Collections.IEnumerable
    {
        protected TenantPolicyDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> Get(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>> GetAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> GetIfExists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>> GetIfExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantPolicyDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantPolicyDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.PolicyDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string policyDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantPolicySetDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>, System.Collections.IEnumerable
    {
        protected TenantPolicySetDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> Get(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>> GetAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> GetIfExists(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>> GetIfExistsAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantPolicySetDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantPolicySetDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.PolicySetDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string policySetDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantResource() { }
        public virtual Azure.ResourceManager.Resources.TenantData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource> GetDataPolicyManifest(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource>> GetDataPolicyManifestAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DataPolicyManifestCollection GetDataPolicyManifests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> GetGenericResource(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> GetGenericResourceAsync(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.GenericResourceCollection GetGenericResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource> GetManagementGroup(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Management.ManagementGroupResource>> GetManagementGroupAsync(string groupId, Azure.ResourceManager.Management.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.Management.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Management.ManagementGroupCollection GetManagementGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceLinkResource> GetResourceLink(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceLinkResource>> GetResourceLinkAsync(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceLinkCollection GetResourceLinks(string scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource> GetSubscription(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource>> GetSubscriptionAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionCollection GetSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> GetTenantPolicyDefinition(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>> GetTenantPolicyDefinitionAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantPolicyDefinitionCollection GetTenantPolicyDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> GetTenantPolicySetDefinition(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>> GetTenantPolicySetDefinitionAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantPolicySetDefinitionCollection GetTenantPolicySetDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ProviderInfo> GetTenantResourceProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ProviderInfo>> GetTenantResourceProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ProviderInfo> GetTenantResourceProviders(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ProviderInfo> GetTenantResourceProvidersAsync(int? top = default(int?), string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Models
{
    public partial class ApiProfile
    {
        internal ApiProfile() { }
        public string ApiVersion { get { throw null; } }
        public string ProfileVersion { get { throw null; } }
    }
    public partial class ArmPolicyParameter
    {
        public ArmPolicyParameter() { }
        public System.Collections.Generic.IList<System.BinaryData> AllowedValues { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmPolicyParameterType? ArmPolicyParameterType { get { throw null; } set { } }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata Metadata { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmPolicyParameterType : System.IEquatable<Azure.ResourceManager.Resources.Models.ArmPolicyParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArmPolicyParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmPolicyParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmPolicyParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmPolicyParameterType DateTime { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmPolicyParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmPolicyParameterType Integer { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmPolicyParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmPolicyParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ArmPolicyParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ArmPolicyParameterType left, Azure.ResourceManager.Resources.Models.ArmPolicyParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ArmPolicyParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ArmPolicyParameterType left, Azure.ResourceManager.Resources.Models.ArmPolicyParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmPolicyParameterValue
    {
        public ArmPolicyParameterValue() { }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class DataManifestCustomResourceFunctionDefinition
    {
        internal DataManifestCustomResourceFunctionDefinition() { }
        public bool? AllowCustomProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DefaultProperties { get { throw null; } }
        public string FullyQualifiedResourceType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class DataPolicyManifestEffect
    {
        internal DataPolicyManifestEffect() { }
        public System.BinaryData DetailsSchema { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnforcementMode : System.IEquatable<Azure.ResourceManager.Resources.Models.EnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnforcementMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.EnforcementMode Default { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.EnforcementMode DoNotEnforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.EnforcementMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.EnforcementMode left, Azure.ResourceManager.Resources.Models.EnforcementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.EnforcementMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.EnforcementMode left, Azure.ResourceManager.Resources.Models.EnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExemptionCategory : System.IEquatable<Azure.ResourceManager.Resources.Models.ExemptionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExemptionCategory(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ExemptionCategory Mitigated { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExemptionCategory Waiver { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ExemptionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ExemptionCategory left, Azure.ResourceManager.Resources.Models.ExemptionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ExemptionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ExemptionCategory left, Azure.ResourceManager.Resources.Models.ExemptionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportTemplateRequest
    {
        public ExportTemplateRequest() { }
        public string Options { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } }
    }
    public partial class ExtendedLocation
    {
        public ExtendedLocation() { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationType : System.IEquatable<Azure.ResourceManager.Resources.Models.ExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ExtendedLocationType EdgeZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ExtendedLocationType left, Azure.ResourceManager.Resources.Models.ExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ExtendedLocationType left, Azure.ResourceManager.Resources.Models.ExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FeatureProperties
    {
        internal FeatureProperties() { }
        public string State { get { throw null; } }
    }
    public partial class LocationExpanded
    {
        internal LocationExpanded() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.LocationType? LocationType { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.LocationMetadata Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string RegionalDisplayName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public static implicit operator Azure.Core.AzureLocation (Azure.ResourceManager.Resources.Models.LocationExpanded location) { throw null; }
    }
    public partial class LocationMetadata
    {
        internal LocationMetadata() { }
        public string GeographyGroup { get { throw null; } }
        public string HomeLocation { get { throw null; } }
        public string Latitude { get { throw null; } }
        public string Longitude { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PairedRegion> PairedRegion { get { throw null; } }
        public string PhysicalLocation { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RegionCategory? RegionCategory { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RegionType? RegionType { get { throw null; } }
    }
    public enum LocationType
    {
        Region = 0,
        EdgeZone = 1,
    }
    public partial class ManagedByTenant
    {
        internal ManagedByTenant() { }
        public System.Guid? TenantId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementLockLevel : System.IEquatable<Azure.ResourceManager.Resources.Models.ManagementLockLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementLockLevel(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ManagementLockLevel CanNotDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ManagementLockLevel NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ManagementLockLevel ReadOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ManagementLockLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ManagementLockLevel left, Azure.ResourceManager.Resources.Models.ManagementLockLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ManagementLockLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ManagementLockLevel left, Azure.ResourceManager.Resources.Models.ManagementLockLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementLockOwner
    {
        public ManagementLockOwner() { }
        public string ApplicationId { get { throw null; } set { } }
    }
    public partial class NonComplianceMessage
    {
        public NonComplianceMessage(string message) { }
        public string Message { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
    }
    public partial class PairedRegion
    {
        internal PairedRegion() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class ParameterDefinitionsValueMetadata
    {
        public ParameterDefinitionsValueMetadata() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? AssignPermissions { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string StrongType { get { throw null; } set { } }
    }
    public partial class PatchableResourceGroupData
    {
        public PatchableResourceGroupData() { }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroupProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PatchableTagResourceData
    {
        public PatchableTagResourceData() { }
        public Azure.ResourceManager.Resources.Models.TagsPatchOperation? Operation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TagValues { get { throw null; } }
    }
    public partial class Permission
    {
        internal Permission() { }
        public System.Collections.Generic.IReadOnlyList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotDataActions { get { throw null; } }
    }
    public partial class PolicyDefinitionGroup
    {
        public PolicyDefinitionGroup(string name) { }
        public string AdditionalMetadataId { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class PolicyDefinitionReference
    {
        public PolicyDefinitionReference(string policyDefinitionId) { }
        public System.Collections.Generic.IList<string> GroupNames { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue> Parameters { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyType : System.IEquatable<Azure.ResourceManager.Resources.Models.PolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.PolicyType BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.PolicyType Custom { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.PolicyType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.PolicyType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.PolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.PolicyType left, Azure.ResourceManager.Resources.Models.PolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.PolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.PolicyType left, Azure.ResourceManager.Resources.Models.PolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PredefinedTag
    {
        internal PredefinedTag() { }
        public Azure.ResourceManager.Resources.Models.PredefinedTagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PredefinedTagValue> Values { get { throw null; } }
    }
    public partial class PredefinedTagCount
    {
        internal PredefinedTagCount() { }
        public string PredefinedTagCountType { get { throw null; } }
        public int? Value { get { throw null; } }
    }
    public partial class PredefinedTagValue
    {
        internal PredefinedTagValue() { }
        public Azure.ResourceManager.Resources.Models.PredefinedTagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagValue { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderAuthorizationConsentState : System.IEquatable<Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderAuthorizationConsentState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState Consented { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState NotRequired { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState left, Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState left, Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderConsentDefinition
    {
        public ProviderConsentDefinition() { }
        public bool? ConsentToAuthorization { get { throw null; } set { } }
    }
    public partial class ProviderExtendedLocation
    {
        internal ProviderExtendedLocation() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public string Location { get { throw null; } }
        public string ProviderExtendedLocationType { get { throw null; } }
    }
    public partial class ProviderInfo
    {
        internal ProviderInfo() { }
        public string Namespace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ProviderPermission
    {
        internal ProviderPermission() { }
        public string ApplicationId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RoleDefinition ManagedByRoleDefinition { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState? ProviderAuthorizationConsentState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RoleDefinition RoleDefinition { get { throw null; } }
    }
    public partial class ProviderPermissionListResult
    {
        internal ProviderPermissionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderPermission> Value { get { throw null; } }
    }
    public partial class ProviderResourceType
    {
        internal ProviderResourceType() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceTypeAlias> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApiProfile> ApiProfiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public string Capabilities { get { throw null; } }
        public string DefaultApiVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderExtendedLocation> LocationMappings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class ProviderResourceTypeListResult
    {
        internal ProviderResourceTypeListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderResourceType> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionCategory : System.IEquatable<Azure.ResourceManager.Resources.Models.RegionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionCategory(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.RegionCategory Extended { get { throw null; } }
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
    public partial class ResourceGroupExportResult
    {
        internal ResourceGroupExportResult() { }
        public Azure.ResourceManager.Models.ErrorDetail Error { get { throw null; } }
        public System.BinaryData Template { get { throw null; } }
    }
    public partial class ResourceGroupProperties
    {
        public ResourceGroupProperties() { }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class ResourceLinkProperties
    {
        public ResourceLinkProperties(string targetId) { }
        public string Notes { get { throw null; } set { } }
        public string SourceId { get { throw null; } }
        public string TargetId { get { throw null; } set { } }
    }
    public partial class ResourceProviderRegistrationOptions
    {
        public ResourceProviderRegistrationOptions() { }
        public bool? ConsentToAuthorization { get { throw null; } set { } }
    }
    public partial class ResourcesMoveInfo
    {
        public ResourcesMoveInfo() { }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } }
        public string TargetResourceGroup { get { throw null; } set { } }
    }
    public partial class ResourcesSku
    {
        public ResourcesSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class ResourceTypeAlias
    {
        internal ResourceTypeAlias() { }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata DefaultMetadata { get { throw null; } }
        public string DefaultPath { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern DefaultPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath> Paths { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasType? ResourceTypeAliasType { get { throw null; } }
    }
    public partial class ResourceTypeAliases
    {
        internal ResourceTypeAliases() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceTypeAlias> Aliases { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class ResourceTypeAliasPath
    {
        internal ResourceTypeAliasPath() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata Metadata { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern Pattern { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeAliasPathAttributes : System.IEquatable<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeAliasPathAttributes(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes Modifiable { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes left, Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes left, Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeAliasPathMetadata
    {
        internal ResourceTypeAliasPathMetadata() { }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes? Attributes { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType? ResourceTypeAliasPathTokenType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeAliasPathTokenType : System.IEquatable<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeAliasPathTokenType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType Any { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType Integer { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType Number { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType left, Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType left, Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeAliasPattern
    {
        internal ResourceTypeAliasPattern() { }
        public string Phrase { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPatternType? ResourceTypeAliasPatternType { get { throw null; } }
        public string Variable { get { throw null; } }
    }
    public enum ResourceTypeAliasPatternType
    {
        NotSpecified = 0,
        Extract = 1,
    }
    public enum ResourceTypeAliasType
    {
        NotSpecified = 0,
        PlainText = 1,
        Mask = 2,
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
    public partial class RoleDefinition
    {
        internal RoleDefinition() { }
        public string Id { get { throw null; } }
        public bool? IsServiceRole { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Permission> Permissions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Scopes { get { throw null; } }
    }
    public enum SpendingLimit
    {
        On = 0,
        Off = 1,
        CurrentPeriodOff = 2,
    }
    public partial class SubResource
    {
        public SubResource() { }
        protected internal SubResource(Azure.Core.ResourceIdentifier id) { }
        public virtual Azure.Core.ResourceIdentifier Id { get { throw null; } }
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
    public partial class Tag
    {
        public Tag() { }
        public System.Collections.Generic.IDictionary<string, string> TagValues { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagsPatchOperation : System.IEquatable<Azure.ResourceManager.Resources.Models.TagsPatchOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagsPatchOperation(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TagsPatchOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.TagsPatchOperation Merge { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.TagsPatchOperation Replace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.TagsPatchOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.TagsPatchOperation left, Azure.ResourceManager.Resources.Models.TagsPatchOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.TagsPatchOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.TagsPatchOperation left, Azure.ResourceManager.Resources.Models.TagsPatchOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum TenantCategory
    {
        Home = 0,
        ProjectedBy = 1,
        ManagedBy = 2,
    }
    public partial class TrackedResourceExtendedData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public TrackedResourceExtendedData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
    }
    public partial class WritableSubResource
    {
        public WritableSubResource() { }
        protected internal WritableSubResource(Azure.Core.ResourceIdentifier id) { }
        public virtual Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
    }
}
