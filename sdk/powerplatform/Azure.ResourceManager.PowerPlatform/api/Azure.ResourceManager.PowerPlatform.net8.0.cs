namespace Azure.ResourceManager.PowerPlatform
{
    public partial class AzureResourceManagerPowerPlatformContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPowerPlatformContext() { }
        public static Azure.ResourceManager.PowerPlatform.AzureResourceManagerPowerPlatformContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EnterprisePolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>, System.Collections.IEnumerable
    {
        protected EnterprisePolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string enterprisePolicyName, Azure.ResourceManager.PowerPlatform.EnterprisePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string enterprisePolicyName, Azure.ResourceManager.PowerPlatform.EnterprisePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> Get(string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> GetAsync(string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> GetIfExists(string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> GetIfExistsAsync(string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnterprisePolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>
    {
        public EnterprisePolicyData(Azure.Core.AzureLocation location, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind kind) { }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus? HealthStatus { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState? LockboxState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties> NetworkInjectionVirtualNetworks { get { throw null; } }
        public string SystemId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.EnterprisePolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.EnterprisePolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnterprisePolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnterprisePolicyResource() { }
        public virtual Azure.ResourceManager.PowerPlatform.EnterprisePolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string enterprisePolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> GetPowerPlatformPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>> GetPowerPlatformPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionCollection GetPowerPlatformPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource> GetPowerPlatformPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource>> GetPowerPlatformPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceCollection GetPowerPlatformPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PowerPlatform.EnterprisePolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.EnterprisePolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.EnterprisePolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> Update(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> UpdateAsync(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PowerPlatformAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>, System.Collections.IEnumerable
    {
        protected PowerPlatformAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PowerPlatformAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>
    {
        public PowerPlatformAccountData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public string SystemId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PowerPlatformAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PowerPlatformAccountResource() { }
        public virtual Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> Update(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> UpdateAsync(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PowerPlatformExtensions
    {
        public static Azure.ResourceManager.PowerPlatform.EnterprisePolicyCollection GetEnterprisePolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> GetEnterprisePolicies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> GetEnterprisePoliciesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> GetEnterprisePolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> GetEnterprisePolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource GetEnterprisePolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> GetPowerPlatformAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> GetPowerPlatformAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource GetPowerPlatformAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.PowerPlatformAccountCollection GetPowerPlatformAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> GetPowerPlatformAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> GetPowerPlatformAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource GetPowerPlatformPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource GetPowerPlatformPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PowerPlatformPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PowerPlatformPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PowerPlatformPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>
    {
        public PowerPlatformPrivateEndpointConnectionData() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PowerPlatformPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PowerPlatformPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string enterprisePolicyName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PowerPlatformPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PowerPlatformPrivateLinkResource() { }
        public virtual Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string enterprisePolicyName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PowerPlatformPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PowerPlatformPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PowerPlatformPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>
    {
        internal PowerPlatformPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.PowerPlatform.Mocking
{
    public partial class MockablePowerPlatformArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePowerPlatformArmClient() { }
        public virtual Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource GetEnterprisePolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource GetPowerPlatformAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionResource GetPowerPlatformPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResource GetPowerPlatformPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePowerPlatformResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePowerPlatformResourceGroupResource() { }
        public virtual Azure.ResourceManager.PowerPlatform.EnterprisePolicyCollection GetEnterprisePolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> GetEnterprisePolicy(string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource>> GetEnterprisePolicyAsync(string enterprisePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> GetPowerPlatformAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource>> GetPowerPlatformAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PowerPlatform.PowerPlatformAccountCollection GetPowerPlatformAccounts() { throw null; }
    }
    public partial class MockablePowerPlatformSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePowerPlatformSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> GetEnterprisePolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerPlatform.EnterprisePolicyResource> GetEnterprisePoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> GetPowerPlatformAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerPlatform.PowerPlatformAccountResource> GetPowerPlatformAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PowerPlatform.Models
{
    public static partial class ArmPowerPlatformModelFactory
    {
        public static Azure.ResourceManager.PowerPlatform.EnterprisePolicyData EnterprisePolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string systemId = null, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties encryption = null, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus? healthStatus = default(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus?), Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState? lockboxState = default(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties> networkInjectionVirtualNetworks = null, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity identity = null, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind kind = default(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind)) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties EnterprisePolicyEncryptionProperties(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties keyVault = null, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState? state = default(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState?)) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity EnterprisePolicyIdentity(System.Guid? systemAssignedIdentityPrincipalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentityType? type = default(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentityType?)) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch EnterprisePolicyPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity identity = null, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind? kind = default(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind?), string systemId = null, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties encryption = null, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus? healthStatus = default(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus?), Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState? lockboxState = default(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties> networkInjectionVirtualNetworks = null) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.PowerPlatformAccountData PowerPlatformAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string systemId = null, string description = null) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch PowerPlatformAccountPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string systemId = null, string description = null) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties PowerPlatformKeyProperties(string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties PowerPlatformKeyVaultProperties(System.Uri vaultUri = null, Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties key = null) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateEndpointConnectionData PowerPlatformPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.PowerPlatformPrivateLinkResourceData PowerPlatformPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState PowerPlatformPrivateLinkServiceConnectionState(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch PowerPlatformTrackedResourcePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties PowerPlatformVirtualNetworkProperties(Azure.Core.ResourceIdentifier id = null, string subnetName = null) { throw null; }
    }
    public partial class EnterprisePolicyEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties>
    {
        public EnterprisePolicyEncryptionProperties() { }
        public Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties KeyVault { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnterprisePolicyHealthStatus : System.IEquatable<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnterprisePolicyHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus Undetermined { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus left, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus left, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnterprisePolicyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity>
    {
        public EnterprisePolicyIdentity() { }
        public System.Guid? SystemAssignedIdentityPrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentityType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum EnterprisePolicyIdentityType
    {
        SystemAssigned = 0,
        None = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnterprisePolicyKind : System.IEquatable<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnterprisePolicyKind(string value) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind Encryption { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind Identity { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind Lockbox { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind NetworkInjection { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind PrivateEndpoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind left, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind left, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnterprisePolicyOnboardingState : System.IEquatable<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnterprisePolicyOnboardingState(string value) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState Disabled { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState Enabled { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState NotConfigured { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState left, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState left, Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnterprisePolicyPatch : Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch>
    {
        public EnterprisePolicyPatch() { }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyHealthStatus? HealthStatus { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyOnboardingState? LockboxState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties> NetworkInjectionVirtualNetworks { get { throw null; } }
        public string SystemId { get { throw null; } }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.EnterprisePolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PowerPlatformAccountPatch : Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch>
    {
        public PowerPlatformAccountPatch() { }
        public string Description { get { throw null; } set { } }
        public string SystemId { get { throw null; } }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PowerPlatformKeyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties>
    {
        public PowerPlatformKeyProperties() { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PowerPlatformKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties>
    {
        public PowerPlatformKeyVaultProperties() { }
        public Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyProperties Key { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PowerPlatformPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerPlatformPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PowerPlatformPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerPlatformPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PowerPlatformPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState>
    {
        public PowerPlatformPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PowerPlatformTrackedResourcePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch>
    {
        public PowerPlatformTrackedResourcePatch() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformTrackedResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PowerPlatformVirtualNetworkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties>
    {
        public PowerPlatformVirtualNetworkProperties() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string SubnetName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerPlatform.Models.PowerPlatformVirtualNetworkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
