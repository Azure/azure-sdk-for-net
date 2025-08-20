namespace Azure.ResourceManager
{
    public partial class ArmClient
    {
        protected ArmClient() { }
        public ArmClient(Azure.Core.TokenCredential credential) { }
        public ArmClient(Azure.Core.TokenCredential credential, string defaultSubscriptionId) { }
        public ArmClient(Azure.Core.TokenCredential credential, string defaultSubscriptionId, Azure.ResourceManager.ArmClientOptions options) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T GetCachedClient<T>(System.Func<Azure.ResourceManager.ArmClient, T> clientFactory) where T : class { throw null; }
        public virtual Azure.ResourceManager.Resources.DataPolicyManifestResource GetDataPolicyManifestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionResource GetDefaultSubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.SubscriptionResource> GetDefaultSubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.FeatureResource GetFeatureResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.GenericResource GetGenericResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.GenericResourceCollection GetGenericResources() { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource GetManagementGroupPolicyDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource GetManagementGroupPolicySetDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagementGroups.ManagementGroupResource GetManagementGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagementGroups.ManagementGroupCollection GetManagementGroups() { throw null; }
        public virtual Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource GetManagementGroupSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementLockResource GetManagementLockResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.PolicyAssignmentResource GetPolicyAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual T GetResourceClient<T>(System.Func<T> resourceFactory) where T : Azure.ResourceManager.ArmResource { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceGroupResource GetResourceGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceProviderResource GetResourceProviderResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource GetSubscriptionPolicyDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource GetSubscriptionPolicySetDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionResource GetSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionCollection GetSubscriptions() { throw null; }
        public virtual Azure.ResourceManager.Resources.TagResource GetTagResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantPolicyDefinitionResource GetTenantPolicyDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource GetTenantPolicySetDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TenantResourceProvider>> GetTenantResourceProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProviders(int? top, string expand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProviders(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProvidersAsync(int? top, string expand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProvidersAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantCollection GetTenants() { throw null; }
    }
    public sealed partial class ArmClientOptions : Azure.Core.ClientOptions
    {
        public ArmClientOptions() { }
        public Azure.ResourceManager.ArmEnvironment? Environment { get { throw null; } set { } }
        public void SetApiVersion(Azure.Core.ResourceType resourceType, string apiVersion) { }
        public void SetApiVersionsFromProfile(Azure.ResourceManager.AzureStackProfile profile) { }
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
        public static Azure.ResourceManager.ArmOperation Rehydrate(Azure.ResourceManager.ArmClient client, Azure.Core.RehydrationToken rehydrationToken, Azure.ResourceManager.ArmClientOptions options = null) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RehydrateAsync(Azure.ResourceManager.ArmClient client, Azure.Core.RehydrationToken rehydrationToken, Azure.ResourceManager.ArmClientOptions options = null) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<T>> RehydrateAsync<T>(Azure.ResourceManager.ArmClient client, Azure.Core.RehydrationToken rehydrationToken, Azure.ResourceManager.ArmClientOptions options = null) where T : notnull { throw null; }
        public static Azure.ResourceManager.ArmOperation<T> Rehydrate<T>(Azure.ResourceManager.ArmClient client, Azure.Core.RehydrationToken rehydrationToken, Azure.ResourceManager.ArmClientOptions options = null) where T : notnull { throw null; }
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
        protected virtual bool CanUseTagResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual System.Threading.Tasks.Task<bool> CanUseTagResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.Resources.TagResource GetTagResource() { throw null; }
        protected virtual bool TryGetApiVersion(Azure.Core.ResourceType resourceType, out string apiVersion) { throw null; }
    }
    public partial class AzureResourceManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContext() { }
        public static Azure.ResourceManager.AzureResourceManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public enum AzureStackProfile
    {
        Profile20200901Hybrid = 0,
    }
    public partial class BicepModelReaderWriterOptions : System.ClientModel.Primitives.ModelReaderWriterOptions
    {
        public BicepModelReaderWriterOptions() : base (default(string)) { }
        public System.Collections.Generic.IDictionary<object, System.Collections.Generic.IDictionary<string, string>> PropertyOverrides { get { throw null; } }
    }
}
namespace Azure.ResourceManager.ManagementGroups
{
    public partial class ManagementGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>, System.Collections.IEnumerable
    {
        protected ManagementGroupCollection() { }
        public virtual Azure.Response<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult> CheckNameAvailability(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent content, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent content, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> Get(string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> GetAll(string cacheControl = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> GetAllAsync(string cacheControl = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>> GetAsync(string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagementGroups.Models.EntityData> GetEntities(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCollectionGetEntitiesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagementGroups.Models.EntityData> GetEntitiesAsync(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCollectionGetEntitiesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> GetIfExists(string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>> GetIfExistsAsync(string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagementGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>
    {
        internal ManagementGroupData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo> Children { get { throw null; } }
        public Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo Details { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.ManagementGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.ManagementGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagementGroupResource() { }
        public virtual Azure.ResourceManager.ManagementGroups.ManagementGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string groupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> Get(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>> GetAsync(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagementGroups.Models.DescendantData> GetDescendants(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagementGroups.Models.DescendantData> GetDescendantsAsync(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> GetManagementGroupPolicyDefinition(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>> GetManagementGroupPolicyDefinitionAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionCollection GetManagementGroupPolicyDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> GetManagementGroupPolicySetDefinition(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>> GetManagementGroupPolicySetDefinitionAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionCollection GetManagementGroupPolicySetDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> GetManagementGroupSubscription(string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>> GetManagementGroupSubscriptionAsync(string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionCollection GetManagementGroupSubscriptions() { throw null; }
        Azure.ResourceManager.ManagementGroups.ManagementGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.ManagementGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> Update(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch patch, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>> UpdateAsync(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch patch, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementGroupSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ManagementGroupSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> Get(string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>> GetAsync(string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> GetIfExists(string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>> GetIfExistsAsync(string subscriptionId, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagementGroupSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>
    {
        internal ManagementGroupSubscriptionData() { }
        public string DisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ParentId { get { throw null; } }
        public string State { get { throw null; } }
        public string Tenant { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementGroupSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagementGroupSubscriptionResource() { }
        public virtual Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string groupId, string subscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> Get(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>> GetAsync(string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource> Update(Azure.WaitUntil waitUntil, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagementGroups.Models
{
    public partial class CreateManagementGroupDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails>
    {
        public CreateManagementGroupDetails() { }
        public Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions Parent { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public int? Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DescendantData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.DescendantData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.DescendantData>
    {
        internal DescendantData() { }
        public string DisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ParentId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.DescendantData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.DescendantData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.DescendantData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.DescendantData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.DescendantData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.DescendantData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.DescendantData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.EntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.EntityData>
    {
        internal EntityData() { }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.ManagementGroups.Models.EntityPermission? InheritedPermissions { get { throw null; } }
        public int? NumberOfChildGroups { get { throw null; } }
        public int? NumberOfChildren { get { throw null; } }
        public int? NumberOfDescendants { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ParentDisplayNameChain { get { throw null; } }
        public Azure.Core.ResourceIdentifier ParentId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ParentNameChain { get { throw null; } }
        public Azure.ResourceManager.ManagementGroups.Models.EntityPermission? Permissions { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.EntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.EntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.EntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.EntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.EntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.EntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.EntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum EntityPermission
    {
        NoAccess = 0,
        View = 1,
        Edit = 2,
        Delete = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntitySearchOption : System.IEquatable<Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntitySearchOption(string value) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption AllowedChildren { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption AllowedParents { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption ChildrenOnly { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption ParentAndFirstLevelChildren { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption ParentOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption left, Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption left, Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityViewOption : System.IEquatable<Azure.ResourceManager.ManagementGroups.Models.EntityViewOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityViewOption(string value) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.EntityViewOption Audit { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.EntityViewOption FullHierarchy { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.EntityViewOption GroupsOnly { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.EntityViewOption SubscriptionsOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagementGroups.Models.EntityViewOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagementGroups.Models.EntityViewOption left, Azure.ResourceManager.ManagementGroups.Models.EntityViewOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagementGroups.Models.EntityViewOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagementGroups.Models.EntityViewOption left, Azure.ResourceManager.ManagementGroups.Models.EntityViewOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementGroupChildInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo>
    {
        internal ManagementGroupChildInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo> Children { get { throw null; } }
        public Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType? ChildType { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementGroupChildOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions>
    {
        internal ManagementGroupChildOptions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions> Children { get { throw null; } }
        public Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType? ChildType { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementGroupChildType : System.IEquatable<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementGroupChildType(string value) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType MicrosoftManagementManagementGroups { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType Subscriptions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType left, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType left, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementGroupCollectionGetEntitiesOptions
    {
        public ManagementGroupCollectionGetEntitiesOptions() { }
        public string CacheControl { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string GroupName { get { throw null; } set { } }
        public Azure.ResourceManager.ManagementGroups.Models.EntitySearchOption? Search { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        public Azure.ResourceManager.ManagementGroups.Models.EntityViewOption? View { get { throw null; } set { } }
    }
    public partial class ManagementGroupCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent>
    {
        public ManagementGroupCreateOrUpdateContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions> Children { get { throw null; } }
        public Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails Details { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementGroupExpandType : System.IEquatable<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementGroupExpandType(string value) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType Ancestors { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType Children { get { throw null; } }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType Path { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType left, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType left, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementGroupInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo>
    {
        internal ManagementGroupInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement> ManagementGroupAncestorChain { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagementGroupAncestors { get { throw null; } }
        public Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo Parent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement> Path { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public int? Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementGroupNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent>
    {
        public ManagementGroupNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementGroupNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult>
    {
        internal ManagementGroupNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ManagementGroupNameUnavailableReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    public partial class ManagementGroupParentCreateOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions>
    {
        public ManagementGroupParentCreateOptions() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch>
    {
        public ManagementGroupPatch() { }
        public string DisplayName { get { throw null; } set { } }
        public string ParentGroupId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementGroupPathElement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement>
    {
        internal ManagementGroupPathElement() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParentManagementGroupInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo>
    {
        internal ParentManagementGroupInfo() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Models
{
    public sealed partial class ArmPlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.ArmPlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ArmPlan>, System.IEquatable<Azure.ResourceManager.Models.ArmPlan>
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
        Azure.ResourceManager.Models.ArmPlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.ArmPlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.ArmPlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.ArmPlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ArmPlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ArmPlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ArmPlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public sealed partial class ArmSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.ArmSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ArmSku>, System.IEquatable<Azure.ResourceManager.Models.ArmSku>
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
        Azure.ResourceManager.Models.ArmSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.ArmSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.ArmSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.ArmSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ArmSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ArmSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ArmSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future release.", false)]
    public partial class EncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.EncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.EncryptionProperties>
    {
        public EncryptionProperties() { }
        public Azure.ResourceManager.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.EncryptionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.EncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.EncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.EncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.EncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.EncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.EncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.EncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future release.", false)]
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future release.", false)]
    public partial class KeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.KeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.KeyVaultProperties>
    {
        public KeyVaultProperties() { }
        public string Identity { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.KeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.KeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.KeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.KeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.KeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.KeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.KeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.ManagedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ManagedServiceIdentity>
    {
        public ManagedServiceIdentity(Azure.ResourceManager.Models.ManagedServiceIdentityType managedServiceIdentityType) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentityType ManagedServiceIdentityType { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<Azure.Core.ResourceIdentifier, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        Azure.ResourceManager.Models.ManagedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.ManagedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.ManagedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.ManagedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ManagedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ManagedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.ManagedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.OperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.OperationStatusResult>
    {
        protected OperationStatusResult() { }
        protected OperationStatusResult(Azure.Core.ResourceIdentifier id, string name, string status, float? percentComplete, System.DateTimeOffset? startOn, System.DateTimeOffset? endOn, System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Models.OperationStatusResult> operations, Azure.ResponseError error) { }
        public OperationStatusResult(string status) { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Models.OperationStatusResult> Operations { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.OperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.OperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.OperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.OperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.OperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.OperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.OperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResourceData
    {
        protected ResourceData() { }
        protected ResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
    }
    public static partial class ResourceManagerModelFactory
    {
        public static Azure.ResourceManager.Resources.Models.ApiProfile ApiProfile(string profileVersion = null, string apiVersion = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings AvailabilityZoneMappings(string logicalZone = null, string physicalZone = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.AzureRoleDefinition AzureRoleDefinition(string id = null, string name = null, bool? isServiceRole = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Permission> permissions = null, System.Collections.Generic.IEnumerable<string> scopes = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails CreateManagementGroupDetails(int? version = default(int?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string updatedBy = null, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions parent = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition DataManifestCustomResourceFunctionDefinition(string name = null, Azure.Core.ResourceType? fullyQualifiedResourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IEnumerable<string> defaultProperties = null, bool? allowCustomProperties = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Resources.DataPolicyManifestData DataPolicyManifestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> namespaces = null, string policyMode = null, bool? isBuiltInOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ResourceTypeAliases> resourceTypeAliases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect> effects = null, System.Collections.Generic.IEnumerable<string> fieldValues = null, System.Collections.Generic.IEnumerable<string> standard = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition> customDefinitions = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect DataPolicyManifestEffect(string name = null, System.BinaryData detailsSchema = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.DescendantData DescendantData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.Core.ResourceIdentifier parentId = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.EntityData EntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? tenantId = default(System.Guid?), string displayName = null, Azure.Core.ResourceIdentifier parentId = null, Azure.ResourceManager.ManagementGroups.Models.EntityPermission? permissions = default(Azure.ResourceManager.ManagementGroups.Models.EntityPermission?), Azure.ResourceManager.ManagementGroups.Models.EntityPermission? inheritedPermissions = default(Azure.ResourceManager.ManagementGroups.Models.EntityPermission?), int? numberOfDescendants = default(int?), int? numberOfChildren = default(int?), int? numberOfChildGroups = default(int?), System.Collections.Generic.IEnumerable<string> parentDisplayNameChain = null, System.Collections.Generic.IEnumerable<string> parentNameChain = null) { throw null; }
        public static Azure.ResourceManager.Resources.FeatureData FeatureData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string featureState = null) { throw null; }
        public static Azure.ResourceManager.Resources.GenericResourceData GenericResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ArmPlan plan = null, System.BinaryData properties = null, string kind = null, string managedBy = null, Azure.ResourceManager.Resources.Models.ResourcesSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.LocationExpanded LocationExpanded(string id, string subscriptionId, string name, Azure.ResourceManager.Resources.Models.LocationType? locationType, string displayName, string regionalDisplayName, Azure.ResourceManager.Resources.Models.LocationMetadata metadata) { throw null; }
        public static Azure.ResourceManager.Resources.Models.LocationExpanded LocationExpanded(string id = null, string subscriptionId = null, string name = null, Azure.ResourceManager.Resources.Models.LocationType? locationType = default(Azure.ResourceManager.Resources.Models.LocationType?), string displayName = null, string regionalDisplayName = null, Azure.ResourceManager.Resources.Models.LocationMetadata metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings> availabilityZoneMappings = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.LocationMetadata LocationMetadata(Azure.ResourceManager.Resources.Models.RegionType? regionType = default(Azure.ResourceManager.Resources.Models.RegionType?), Azure.ResourceManager.Resources.Models.RegionCategory? regionCategory = default(Azure.ResourceManager.Resources.Models.RegionCategory?), string geography = null, string geographyGroup = null, double? longitude = default(double?), double? latitude = default(double?), string physicalLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.PairedRegion> pairedRegions = null, string homeLocation = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ManagedByTenant ManagedByTenant(System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Models.ManagedServiceIdentity ManagedServiceIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Models.ManagedServiceIdentityType managedServiceIdentityType = default(Azure.ResourceManager.Models.ManagedServiceIdentityType), System.Collections.Generic.IDictionary<Azure.Core.ResourceIdentifier, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo ManagementGroupChildInfo(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType? childType = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType?), string id = null, string name = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo> children = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions ManagementGroupChildOptions(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType? childType = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildType?), string id = null, string name = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions> children = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupCreateOrUpdateContent ManagementGroupCreateOrUpdateContent(string id = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string name = null, System.Guid? tenantId = default(System.Guid?), string displayName = null, Azure.ResourceManager.ManagementGroups.Models.CreateManagementGroupDetails details = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildOptions> children = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.ManagementGroupData ManagementGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? tenantId = default(System.Guid?), string displayName = null, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo details = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupChildInfo> children = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupInfo ManagementGroupInfo(int? version = default(int?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string updatedBy = null, Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo parent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement> path = null, System.Collections.Generic.IEnumerable<string> managementGroupAncestors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement> managementGroupAncestorChain = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameAvailabilityResult ManagementGroupNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameUnavailableReason? reason = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupParentCreateOptions ManagementGroupParentCreateOptions(string id = null, string name = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ManagementGroupPathElement ManagementGroupPathElement(string name = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.ManagementGroupSubscriptionData ManagementGroupSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string tenant = null, string displayName = null, Azure.Core.ResourceIdentifier parentId = null, string state = null) { throw null; }
        public static Azure.ResourceManager.Resources.ManagementLockData ManagementLockData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.ManagementLockLevel level = default(Azure.ResourceManager.Resources.Models.ManagementLockLevel), string notes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ManagementLockOwner> owners = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.PairedRegion PairedRegion(string name = null, string id = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.ManagementGroups.Models.ParentManagementGroupInfo ParentManagementGroupInfo(string id = null, string name = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.Permission Permission(System.Collections.Generic.IEnumerable<string> allowedActions = null, System.Collections.Generic.IEnumerable<string> deniedActions = null, System.Collections.Generic.IEnumerable<string> allowedDataActions = null, System.Collections.Generic.IEnumerable<string> deniedDataActions = null) { throw null; }
        public static Azure.ResourceManager.Resources.PolicyAssignmentData PolicyAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Models.ManagedServiceIdentity managedIdentity = null, string displayName = null, string policyDefinitionId = null, string scope = null, System.Collections.Generic.IEnumerable<string> excludedScopes = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue> parameters = null, string description = null, System.BinaryData metadata = null, Azure.ResourceManager.Resources.Models.EnforcementMode? enforcementMode = default(Azure.ResourceManager.Resources.Models.EnforcementMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.NonComplianceMessage> nonComplianceMessages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ResourceSelector> resourceSelectors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.PolicyOverride> overrides = null) { throw null; }
        public static Azure.ResourceManager.Resources.PolicyDefinitionData PolicyDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Models.PolicyType?), string mode = null, string displayName = null, string description = null, System.BinaryData policyRule = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameter> parameters = null) { throw null; }
        public static Azure.ResourceManager.Resources.PolicySetDefinitionData PolicySetDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Models.PolicyType?), string displayName = null, string description = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameter> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference> policyDefinitions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup> policyDefinitionGroups = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.PredefinedTag PredefinedTag(string id = null, string tagName = null, Azure.ResourceManager.Resources.Models.PredefinedTagCount count = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.PredefinedTagValue> values = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.PredefinedTagCount PredefinedTagCount(string predefinedTagCountType = null, int? value = default(int?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.PredefinedTagValue PredefinedTagValue(string id = null, string tagValue = null, Azure.ResourceManager.Resources.Models.PredefinedTagCount count = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ProviderExtendedLocation ProviderExtendedLocation(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string providerExtendedLocationType = null, System.Collections.Generic.IEnumerable<string> extendedLocations = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ProviderPermission ProviderPermission(string applicationId = null, Azure.ResourceManager.Resources.Models.AzureRoleDefinition roleDefinition = null, Azure.ResourceManager.Resources.Models.AzureRoleDefinition managedByRoleDefinition = null, Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState? providerAuthorizationConsentState = default(Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ProviderResourceType ProviderResourceType(string resourceType = null, System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ProviderExtendedLocation> locationMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ResourceTypeAlias> aliases = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, string defaultApiVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ZoneMapping> zoneMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ApiProfile> apiProfiles = null, string capabilities = null, System.Collections.Generic.IReadOnlyDictionary<string, string> properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.ResourceGroupData ResourceGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string resourceGroupProvisioningState = null, string managedBy = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceGroupExportResult ResourceGroupExportResult(System.BinaryData template = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceNameValidationResult ResourceNameValidationResult(string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus? status = default(Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.Resources.ResourceProviderData ResourceProviderData(Azure.Core.ResourceIdentifier id = null, string @namespace = null, string registrationState = null, string registrationPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ProviderResourceType> resourceTypes = null, Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState? providerAuthorizationConsentState = default(Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAlias ResourceTypeAlias(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath> paths = null, Azure.ResourceManager.Resources.Models.ResourceTypeAliasType? aliasType = default(Azure.ResourceManager.Resources.Models.ResourceTypeAliasType?), string defaultPath = null, Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern defaultPattern = null, Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata defaultMetadata = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliases ResourceTypeAliases(string resourceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ResourceTypeAlias> aliases = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath ResourceTypeAliasPath(string path = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern pattern = null, Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata metadata = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata ResourceTypeAliasPathMetadata(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType? tokenType = default(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType?), Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes? attributes = default(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern ResourceTypeAliasPattern(string phrase = null, string variable = null, Azure.ResourceManager.Resources.Models.ResourceTypeAliasPatternType? patternType = default(Azure.ResourceManager.Resources.Models.ResourceTypeAliasPatternType?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.SubResource SubResource(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Resources.SubscriptionData SubscriptionData(Azure.Core.ResourceIdentifier id = null, string subscriptionId = null, string displayName = null, System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Resources.Models.SubscriptionState? state = default(Azure.ResourceManager.Resources.Models.SubscriptionState?), Azure.ResourceManager.Resources.Models.SubscriptionPolicies subscriptionPolicies = null, string authorizationSource = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ManagedByTenant> managedByTenants = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.SubscriptionPolicies SubscriptionPolicies(string locationPlacementId = null, string quotaId = null, Azure.ResourceManager.Resources.Models.SpendingLimit? spendingLimit = default(Azure.ResourceManager.Resources.Models.SpendingLimit?)) { throw null; }
        public static Azure.ResourceManager.Resources.TagResourceData TagResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tagValues = null) { throw null; }
        public static Azure.ResourceManager.Resources.TenantData TenantData(string id = null, System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Resources.Models.TenantCategory? tenantCategory = default(Azure.ResourceManager.Resources.Models.TenantCategory?), string country = null, string countryCode = null, string displayName = null, System.Collections.Generic.IEnumerable<string> domains = null, string defaultDomain = null, string tenantType = null, System.Uri tenantBrandingLogoUri = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TenantResourceProvider TenantResourceProvider(string @namespace = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ProviderResourceType> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData TrackedResourceExtendedData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.WritableSubResource WritableSubResource(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ZoneMapping ZoneMapping(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future release.", false)]
    public partial class SystemAssignedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.SystemAssignedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.SystemAssignedServiceIdentity>
    {
        public SystemAssignedServiceIdentity(Azure.ResourceManager.Models.SystemAssignedServiceIdentityType systemAssignedServiceIdentityType) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentityType SystemAssignedServiceIdentityType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.SystemAssignedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.SystemAssignedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.SystemAssignedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.SystemAssignedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.SystemAssignedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.SystemAssignedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.SystemAssignedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This type is obsolete and will be removed in a future release.", false)]
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
    public partial class SystemData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.SystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.SystemData>
    {
        public SystemData() { }
        public string CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Models.CreatedByType? CreatedByType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.ResourceManager.Models.CreatedByType? LastModifiedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.SystemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.SystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.SystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.SystemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.SystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.SystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.SystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TrackedResourceData : Azure.ResourceManager.Models.ResourceData
    {
        protected TrackedResourceData() { }
        protected TrackedResourceData(Azure.Core.AzureLocation location) { }
        protected TrackedResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location) { }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
    }
    public partial class UserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.UserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.UserAssignedIdentity>
    {
        public UserAssignedIdentity() { }
        public System.Guid? ClientId { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.UserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.UserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Models.UserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Models.UserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.UserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.UserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Models.UserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources
{
    public partial class ArmRestApiCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Models.ArmRestApi>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmRestApi>, System.Collections.IEnumerable
    {
        protected ArmRestApiCollection() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ArmRestApi> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ArmRestApi> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Models.ArmRestApi> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Models.ArmRestApi>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Models.ArmRestApi> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmRestApi>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataPolicyManifestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DataPolicyManifestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DataPolicyManifestResource>, System.Collections.IEnumerable
    {
        protected DataPolicyManifestCollection() { }
        public virtual Azure.Response<bool> Exists(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource> Get(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DataPolicyManifestResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DataPolicyManifestResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource>> GetAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.DataPolicyManifestResource> GetIfExists(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.DataPolicyManifestResource>> GetIfExistsAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DataPolicyManifestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DataPolicyManifestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DataPolicyManifestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DataPolicyManifestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataPolicyManifestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataPolicyManifestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataPolicyManifestData>
    {
        internal DataPolicyManifestData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition> CustomDefinitions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect> Effects { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FieldValues { get { throw null; } }
        public bool? IsBuiltInOnly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Namespaces { get { throw null; } }
        public string PolicyMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceTypeAliases> ResourceTypeAliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Standard { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DataPolicyManifestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DataPolicyManifestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataPolicyManifestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataPolicyManifestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataPolicyManifestData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataPolicyManifestResource() { }
        public virtual Azure.ResourceManager.Resources.DataPolicyManifestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string policyMode) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataPolicyManifestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.DataPolicyManifestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DataPolicyManifestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataPolicyManifestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.FeatureResource> GetIfExists(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.FeatureResource>> GetIfExistsAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.FeatureResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.FeatureResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.FeatureResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.FeatureResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FeatureData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.FeatureData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.FeatureData>
    {
        internal FeatureData() { }
        public string FeatureState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.FeatureData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.FeatureData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.FeatureData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.FeatureData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.FeatureData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.FeatureData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.FeatureData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FeatureResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.FeatureData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.FeatureData>
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
        Azure.ResourceManager.Resources.FeatureData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.FeatureData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.FeatureData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.FeatureData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.FeatureData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.FeatureData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.FeatureData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.GenericResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.GenericResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.GenericResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.GenericResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GenericResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected GenericResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.GenericResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.Resources.GenericResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.GenericResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.Resources.GenericResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.GenericResource> Get(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.GenericResource>> GetAsync(Azure.Core.ResourceIdentifier resourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GenericResourceData : Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.GenericResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.GenericResourceData>
    {
        public GenericResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourcesSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.GenericResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.GenericResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.GenericResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.GenericResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.GenericResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.GenericResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.GenericResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> GetIfExists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>> GetIfExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagementGroupPolicyDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>
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
        Azure.ResourceManager.Resources.PolicyDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicyDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementGroupPolicyDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> GetIfExists(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>> GetIfExistsAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagementGroupPolicySetDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>
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
        Azure.ResourceManager.Resources.PolicySetDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicySetDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementGroupPolicySetDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ManagementLockResource> GetIfExists(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ManagementLockResource>> GetIfExistsAsync(string lockName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ManagementLockResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ManagementLockResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ManagementLockResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ManagementLockResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagementLockData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ManagementLockData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ManagementLockData>
    {
        public ManagementLockData(Azure.ResourceManager.Resources.Models.ManagementLockLevel level) { }
        public Azure.ResourceManager.Resources.Models.ManagementLockLevel Level { get { throw null; } set { } }
        public string Notes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ManagementLockOwner> Owners { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ManagementLockData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ManagementLockData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ManagementLockData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ManagementLockData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ManagementLockData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ManagementLockData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ManagementLockData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementLockResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ManagementLockData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ManagementLockData>
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
        Azure.ResourceManager.Resources.ManagementLockData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ManagementLockData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ManagementLockData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ManagementLockData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ManagementLockData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ManagementLockData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ManagementLockData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementLockResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.ManagementLockData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ManagementLockResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.ManagementLockData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.PolicyAssignmentResource> GetIfExists(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.PolicyAssignmentResource>> GetIfExistsAsync(string policyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.PolicyAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.PolicyAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.PolicyAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.PolicyAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyAssignmentData>
    {
        public PolicyAssignmentData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.EnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedScopes { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use ManagedIdentity.", false)]
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity ManagedIdentity { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.NonComplianceMessage> NonComplianceMessages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.PolicyOverride> Overrides { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue> Parameters { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ResourceSelector> ResourceSelectors { get { throw null; } }
        public string Scope { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyAssignmentData>
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
        Azure.ResourceManager.Resources.PolicyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource> Update(Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.PolicyAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.PolicyAssignmentResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.PolicyAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>
    {
        public PolicyDefinitionData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameter> Parameters { get { throw null; } }
        public System.BinaryData PolicyRule { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.PolicyType? PolicyType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicyDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicyDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicySetDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>
    {
        public PolicySetDefinitionData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.PolicyType? PolicyType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicySetDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicySetDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ResourceGroupResource> GetIfExists(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ResourceGroupResource>> GetIfExistsAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ResourceGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ResourceGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ResourceGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceGroupData>
    {
        public ResourceGroupData(Azure.Core.AzureLocation location) { }
        public string ManagedBy { get { throw null; } set { } }
        public string ResourceGroupProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ResourceGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ResourceGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceGroupData>
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult> ExportTemplate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ExportTemplate exportTemplate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>> ExportTemplateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ExportTemplate exportTemplate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetGenericResources(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetGenericResourcesAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MoveResources(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ResourcesMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MoveResourcesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ResourcesMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.ResourceGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ResourceGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource> Update(Azure.ResourceManager.Resources.Models.ResourceGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceGroupResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.ResourceGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ValidateMoveResources(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ResourcesMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ValidateMoveResourcesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ResourcesMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceProviderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ResourceProviderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceProviderResource>, System.Collections.IEnumerable
    {
        protected ResourceProviderCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ResourceProviderResource> GetAll(int? top, string expand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ResourceProviderResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ResourceProviderResource> GetAllAsync(int? top, string expand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ResourceProviderResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ResourceProviderResource> GetIfExists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ResourceProviderResource>> GetIfExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ResourceProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ResourceProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ResourceProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceProviderData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceProviderData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceProviderData>
    {
        public ResourceProviderData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState? ProviderAuthorizationConsentState { get { throw null; } }
        public string RegistrationPolicy { get { throw null; } }
        public string RegistrationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ResourceProviderData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceProviderData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceProviderData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ResourceProviderData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceProviderData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceProviderData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceProviderData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceProviderData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceProviderData>
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
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> Register(Azure.ResourceManager.Resources.Models.ProviderRegistrationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> RegisterAsync(Azure.ResourceManager.Resources.Models.ProviderRegistrationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.ResourceProviderData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceProviderData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ResourceProviderData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ResourceProviderData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceProviderData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceProviderData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ResourceProviderData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> Unregister(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> UnregisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.SubscriptionResource> GetIfExists(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.SubscriptionResource>> GetIfExistsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.SubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.SubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.SubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.SubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.SubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.SubscriptionData>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.SubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.SubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.SubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.SubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.SubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.SubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.SubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> GetIfExists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>> GetIfExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionPolicyDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>
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
        Azure.ResourceManager.Resources.PolicyDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicyDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> GetIfExists(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>> GetIfExistsAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionPolicySetDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>
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
        Azure.ResourceManager.Resources.PolicySetDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicySetDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.SubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.SubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionResource() { }
        public virtual Azure.ResourceManager.Resources.SubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
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
        public virtual Azure.ResourceManager.Resources.ArmRestApiCollection GetArmRestApis(string azureNamespace) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource> GetResourceProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ResourceProviderResource>> GetResourceProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ResourceProviderCollection GetResourceProviders() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource> GetSubscriptionPolicyDefinition(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource>> GetSubscriptionPolicyDefinitionAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionCollection GetSubscriptionPolicyDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource> GetSubscriptionPolicySetDefinition(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource>> GetSubscriptionPolicySetDefinitionAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionCollection GetSubscriptionPolicySetDefinitions() { throw null; }
        Azure.ResourceManager.Resources.SubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.SubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.SubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.SubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.SubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.SubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.SubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TagResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TagResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TagResourceData>
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
        Azure.ResourceManager.Resources.TagResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TagResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TagResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TagResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TagResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TagResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TagResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", false)]
        public virtual Azure.Response<Azure.ResourceManager.Resources.TagResource> Update(Azure.ResourceManager.Resources.Models.TagResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TagResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.TagResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TagResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.TagResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TagResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.TagResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TagResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TagResourceData>
    {
        public TagResourceData(Azure.ResourceManager.Resources.Models.Tag properties) { }
        public System.Collections.Generic.IDictionary<string, string> TagValues { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TagResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TagResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TagResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TagResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TagResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TagResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TagResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantResource>, System.Collections.IEnumerable
    {
        protected TenantCollection() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ResourceNameValidationResult> CheckResourceName(Azure.ResourceManager.Resources.Models.ResourceNameValidationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ResourceNameValidationResult>> CheckResourceNameAsync(Azure.ResourceManager.Resources.Models.ResourceNameValidationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TenantResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TenantResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TenantResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TenantResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TenantData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TenantData>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TenantData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TenantData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TenantData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TenantData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TenantData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TenantData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TenantData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> GetIfExists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>> GetIfExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantPolicyDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantPolicyDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.PolicyDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string policyDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.PolicyDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicyDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicyDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> GetIfExists(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>> GetIfExistsAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantPolicySetDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantPolicySetDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.PolicySetDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string policySetDefinitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.PolicySetDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.PolicySetDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.PolicySetDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TenantData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TenantData>
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
        public virtual Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupResource> GetManagementGroup(string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementGroups.ManagementGroupResource>> GetManagementGroupAsync(string groupId, Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType? expand = default(Azure.ResourceManager.ManagementGroups.Models.ManagementGroupExpandType?), bool? recurse = default(bool?), string filter = null, string cacheControl = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagementGroups.ManagementGroupCollection GetManagementGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource> GetSubscription(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.SubscriptionResource>> GetSubscriptionAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.SubscriptionCollection GetSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource> GetTenantPolicyDefinition(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicyDefinitionResource>> GetTenantPolicyDefinitionAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantPolicyDefinitionCollection GetTenantPolicyDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource> GetTenantPolicySetDefinition(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantPolicySetDefinitionResource>> GetTenantPolicySetDefinitionAsync(string policySetDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantPolicySetDefinitionCollection GetTenantPolicySetDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProvider(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TenantResourceProvider>> GetTenantResourceProviderAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProviders(int? top, string expand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProviders(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as the `top` parameter is not supported by service and will be removed in a future release.", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProvidersAsync(int? top, string expand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.TenantResourceProvider> GetTenantResourceProvidersAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.TenantData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TenantData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TenantData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TenantData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TenantData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TenantData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TenantData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Models
{
    public partial class ApiProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ApiProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ApiProfile>
    {
        internal ApiProfile() { }
        public string ApiVersion { get { throw null; } }
        public string ProfileVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ApiProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ApiProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ApiProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ApiProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ApiProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ApiProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ApiProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmPolicyParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameter>
    {
        public ArmPolicyParameter() { }
        public System.Collections.Generic.IList<System.BinaryData> AllowedValues { get { throw null; } }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmPolicyParameterType? ParameterType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmPolicyParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmPolicyParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ArmPolicyParameterValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue>
    {
        public ArmPolicyParameterValue() { }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmRestApi : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmRestApi>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmRestApi>
    {
        internal ArmRestApi() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Origin { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        Azure.ResourceManager.Resources.Models.ArmRestApi System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmRestApi>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmRestApi>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmRestApi System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmRestApi>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmRestApi>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmRestApi>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilityZoneMappings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings>
    {
        internal AvailabilityZoneMappings() { }
        public string LogicalZone { get { throw null; } }
        public string PhysicalZone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureRoleDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AzureRoleDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzureRoleDefinition>
    {
        internal AzureRoleDefinition() { }
        public string Id { get { throw null; } }
        public bool? IsServiceRole { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Permission> Permissions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Scopes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.AzureRoleDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AzureRoleDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AzureRoleDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.AzureRoleDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzureRoleDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzureRoleDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzureRoleDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataManifestCustomResourceFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition>
    {
        internal DataManifestCustomResourceFunctionDefinition() { }
        public bool? AllowCustomProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DefaultProperties { get { throw null; } }
        public Azure.Core.ResourceType? FullyQualifiedResourceType { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataManifestCustomResourceFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataPolicyManifestEffect : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect>
    {
        internal DataPolicyManifestEffect() { }
        public System.BinaryData DetailsSchema { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataPolicyManifestEffect>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnforcementMode : System.IEquatable<Azure.ResourceManager.Resources.Models.EnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnforcementMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.EnforcementMode Default { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.EnforcementMode DoNotEnforce { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Resources.Models.EnforcementMode Enforced { get { throw null; } }
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
    public partial class ExportTemplate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ExportTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ExportTemplate>
    {
        public ExportTemplate() { }
        public string Options { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ExportTemplate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ExportTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ExportTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ExportTemplate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ExportTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ExportTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ExportTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>
    {
        public ExtendedLocation() { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LocationExpanded : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.LocationExpanded>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LocationExpanded>
    {
        internal LocationExpanded() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.AvailabilityZoneMappings> AvailabilityZoneMappings { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.LocationType? LocationType { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.LocationMetadata Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string RegionalDisplayName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.AzureLocation (Azure.ResourceManager.Resources.Models.LocationExpanded location) { throw null; }
        Azure.ResourceManager.Resources.Models.LocationExpanded System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.LocationExpanded>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.LocationExpanded>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.LocationExpanded System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LocationExpanded>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LocationExpanded>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LocationExpanded>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocationMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.LocationMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LocationMetadata>
    {
        internal LocationMetadata() { }
        public string Geography { get { throw null; } }
        public string GeographyGroup { get { throw null; } }
        public string HomeLocation { get { throw null; } }
        public double? Latitude { get { throw null; } }
        public double? Longitude { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PairedRegion> PairedRegions { get { throw null; } }
        public string PhysicalLocation { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RegionCategory? RegionCategory { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.RegionType? RegionType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.LocationMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.LocationMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.LocationMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.LocationMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LocationMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LocationMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LocationMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LocationType
    {
        Region = 0,
        EdgeZone = 1,
    }
    public partial class ManagedByTenant : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagedByTenant>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedByTenant>
    {
        internal ManagedByTenant() { }
        public System.Guid? TenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ManagedByTenant System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagedByTenant>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagedByTenant>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ManagedByTenant System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedByTenant>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedByTenant>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedByTenant>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ManagementLockOwner : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagementLockOwner>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagementLockOwner>
    {
        public ManagementLockOwner() { }
        public string ApplicationId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ManagementLockOwner System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagementLockOwner>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagementLockOwner>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ManagementLockOwner System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagementLockOwner>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagementLockOwner>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagementLockOwner>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NonComplianceMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.NonComplianceMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.NonComplianceMessage>
    {
        public NonComplianceMessage(string message) { }
        public string Message { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.NonComplianceMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.NonComplianceMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.NonComplianceMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.NonComplianceMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.NonComplianceMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.NonComplianceMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.NonComplianceMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PairedRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PairedRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PairedRegion>
    {
        internal PairedRegion() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PairedRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PairedRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PairedRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PairedRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PairedRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PairedRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PairedRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParameterDefinitionsValueMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata>
    {
        public ParameterDefinitionsValueMetadata() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? AssignPermissions { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string StrongType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ParameterDefinitionsValueMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Permission : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.Permission>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.Permission>
    {
        internal Permission() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AllowedDataActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DeniedActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DeniedDataActions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.Permission System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.Permission>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.Permission>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.Permission System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.Permission>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.Permission>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.Permission>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyAssignmentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch>
    {
        public PolicyAssignmentPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.PolicyOverride> Overrides { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ResourceSelector> ResourceSelectors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyAssignmentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyDefinitionGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup>
    {
        public PolicyDefinitionGroup(string name) { }
        public string AdditionalMetadataId { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyDefinitionReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference>
    {
        public PolicyDefinitionReference(string policyDefinitionId) { }
        public System.Collections.Generic.IList<string> GroupNames { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmPolicyParameterValue> Parameters { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PolicyDefinitionReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PolicyDefinitionReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyDefinitionReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyOverride>
    {
        public PolicyOverride() { }
        public Azure.ResourceManager.Resources.Models.PolicyOverrideKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ResourceSelectorExpression> Selectors { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PolicyOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PolicyOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PolicyOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PolicyOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyOverrideKind : System.IEquatable<Azure.ResourceManager.Resources.Models.PolicyOverrideKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyOverrideKind(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.PolicyOverrideKind PolicyEffect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.PolicyOverrideKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.PolicyOverrideKind left, Azure.ResourceManager.Resources.Models.PolicyOverrideKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.PolicyOverrideKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.PolicyOverrideKind left, Azure.ResourceManager.Resources.Models.PolicyOverrideKind right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class PredefinedTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PredefinedTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTag>
    {
        internal PredefinedTag() { }
        public Azure.ResourceManager.Resources.Models.PredefinedTagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.PredefinedTagValue> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PredefinedTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PredefinedTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PredefinedTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PredefinedTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredefinedTagCount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PredefinedTagCount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTagCount>
    {
        internal PredefinedTagCount() { }
        public string PredefinedTagCountType { get { throw null; } }
        public int? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PredefinedTagCount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PredefinedTagCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PredefinedTagCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PredefinedTagCount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTagCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTagCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTagCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredefinedTagValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PredefinedTagValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTagValue>
    {
        internal PredefinedTagValue() { }
        public Azure.ResourceManager.Resources.Models.PredefinedTagCount Count { get { throw null; } }
        public string Id { get { throw null; } }
        public string TagValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PredefinedTagValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PredefinedTagValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.PredefinedTagValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.PredefinedTagValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTagValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTagValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.PredefinedTagValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProviderExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderExtendedLocation>
    {
        internal ProviderExtendedLocation() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProviderExtendedLocationType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ProviderExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ProviderExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderPermission : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderPermission>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderPermission>
    {
        internal ProviderPermission() { }
        public string ApplicationId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AzureRoleDefinition ManagedByRoleDefinition { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProviderAuthorizationConsentState? ProviderAuthorizationConsentState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.AzureRoleDefinition RoleDefinition { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ProviderPermission System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderPermission>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderPermission>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ProviderPermission System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderPermission>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderPermission>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderPermission>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderRegistrationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderRegistrationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderRegistrationContent>
    {
        public ProviderRegistrationContent() { }
        public bool? ConsentToAuthorization { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ProviderRegistrationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderRegistrationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderRegistrationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ProviderRegistrationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderRegistrationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderRegistrationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderRegistrationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderResourceType>
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ZoneMapping> ZoneMappings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ProviderResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ProviderResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ProviderResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ProviderResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResourceGroupExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>
    {
        internal ResourceGroupExportResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public System.BinaryData Template { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceGroupExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceGroupExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceGroupExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceGroupPatch>
    {
        public ResourceGroupPatch() { }
        public string ManagedBy { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroupProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNameValidationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationContent>
    {
        public ResourceNameValidationContent(string name, Azure.Core.ResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceNameValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceNameValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceNameValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationResult>
    {
        internal ResourceNameValidationResult() { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceNameValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceNameValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceNameValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceNameValidationStatus : System.IEquatable<Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceNameValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus Allowed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus Reserved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus left, Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus left, Azure.ResourceManager.Resources.Models.ResourceNameValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceSelector>
    {
        public ResourceSelector() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ResourceSelectorExpression> Selectors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSelectorExpression : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceSelectorExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceSelectorExpression>
    {
        public ResourceSelectorExpression() { }
        public System.Collections.Generic.IList<string> In { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceSelectorKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotIn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceSelectorExpression System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceSelectorExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceSelectorExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceSelectorExpression System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceSelectorExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceSelectorExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceSelectorExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSelectorKind : System.IEquatable<Azure.ResourceManager.Resources.Models.ResourceSelectorKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSelectorKind(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceSelectorKind PolicyDefinitionReferenceId { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceSelectorKind ResourceLocation { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceSelectorKind ResourceType { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceSelectorKind ResourceWithoutLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ResourceSelectorKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ResourceSelectorKind left, Azure.ResourceManager.Resources.Models.ResourceSelectorKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ResourceSelectorKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ResourceSelectorKind left, Azure.ResourceManager.Resources.Models.ResourceSelectorKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourcesMoveContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourcesMoveContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourcesMoveContent>
    {
        public ResourcesMoveContent() { }
        public System.Collections.Generic.IList<string> Resources { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string TargetResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourcesMoveContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourcesMoveContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourcesMoveContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourcesMoveContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourcesMoveContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourcesMoveContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourcesMoveContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourcesSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourcesSku>
    {
        public ResourcesSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourcesSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourcesSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourcesSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourcesSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourcesSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourcesSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourcesSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeAlias : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAlias>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAlias>
    {
        internal ResourceTypeAlias() { }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasType? AliasType { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata DefaultMetadata { get { throw null; } }
        public string DefaultPath { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern DefaultPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath> Paths { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAlias System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAlias>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAlias>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAlias System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAlias>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAlias>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAlias>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeAliases : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliases>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliases>
    {
        internal ResourceTypeAliases() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceTypeAlias> Aliases { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAliases System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliases>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliases>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAliases System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliases>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliases>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliases>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeAliasPath : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath>
    {
        internal ResourceTypeAliasPath() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata Metadata { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern Pattern { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPath>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResourceTypeAliasPathMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata>
    {
        internal ResourceTypeAliasPathMetadata() { }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathAttributes? Attributes { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathTokenType? TokenType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPathMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResourceTypeAliasPattern : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern>
    {
        internal ResourceTypeAliasPattern() { }
        public Azure.ResourceManager.Resources.Models.ResourceTypeAliasPatternType? PatternType { get { throw null; } }
        public string Phrase { get { throw null; } }
        public string Variable { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceTypeAliasPattern>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public enum SpendingLimit
    {
        On = 0,
        Off = 1,
        CurrentPeriodOff = 2,
    }
    public partial class SubResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.SubResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.SubResource>
    {
        public SubResource() { }
        protected internal SubResource(Azure.Core.ResourceIdentifier id) { }
        public virtual Azure.Core.ResourceIdentifier Id { get { throw null; } }
        Azure.ResourceManager.Resources.Models.SubResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.SubResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.SubResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.SubResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.SubResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.SubResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.SubResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionPolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.SubscriptionPolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.SubscriptionPolicies>
    {
        internal SubscriptionPolicies() { }
        public string LocationPlacementId { get { throw null; } }
        public string QuotaId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SpendingLimit? SpendingLimit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.SubscriptionPolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.SubscriptionPolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.SubscriptionPolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.SubscriptionPolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.SubscriptionPolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.SubscriptionPolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.SubscriptionPolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SubscriptionState
    {
        Enabled = 0,
        Warned = 1,
        PastDue = 2,
        Disabled = 3,
        Deleted = 4,
    }
    public partial class Tag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.Tag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.Tag>
    {
        public Tag() { }
        public System.Collections.Generic.IDictionary<string, string> TagValues { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.Tag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.Tag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.Tag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.Tag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.Tag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.Tag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.Tag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagPatchMode : System.IEquatable<Azure.ResourceManager.Resources.Models.TagPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TagPatchMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.TagPatchMode Merge { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.TagPatchMode Replace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.TagPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.TagPatchMode left, Azure.ResourceManager.Resources.Models.TagPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.TagPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.TagPatchMode left, Azure.ResourceManager.Resources.Models.TagPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TagResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TagResourcePatch>
    {
        public TagResourcePatch() { }
        public Azure.ResourceManager.Resources.Models.TagPatchMode? PatchMode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> TagValues { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TagResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TagResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TagResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TagResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TagResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TagResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TagResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum TenantCategory
    {
        Home = 0,
        ProjectedBy = 1,
        ManagedBy = 2,
    }
    public partial class TenantResourceProvider : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TenantResourceProvider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TenantResourceProvider>
    {
        internal TenantResourceProvider() { }
        public string Namespace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TenantResourceProvider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TenantResourceProvider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TenantResourceProvider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TenantResourceProvider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TenantResourceProvider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TenantResourceProvider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TenantResourceProvider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrackedResourceExtendedData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData>
    {
        public TrackedResourceExtendedData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TrackedResourceExtendedData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WritableSubResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WritableSubResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WritableSubResource>
    {
        public WritableSubResource() { }
        protected internal WritableSubResource(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        Azure.ResourceManager.Resources.Models.WritableSubResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WritableSubResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WritableSubResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WritableSubResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WritableSubResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WritableSubResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WritableSubResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ZoneMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ZoneMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ZoneMapping>
    {
        internal ZoneMapping() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ZoneMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ZoneMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ZoneMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ZoneMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ZoneMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ZoneMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ZoneMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ArmClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.ResourceManager.ArmClient, Azure.ResourceManager.ArmClientOptions> AddArmClient<TBuilder>(this TBuilder builder, string defaultSubscription) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.ResourceManager.ArmClient, Azure.ResourceManager.ArmClientOptions> AddArmClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
