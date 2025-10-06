namespace Azure.ResourceManager.ManagedServiceIdentities
{
    public partial class AzureResourceManagerManagedServiceIdentitiesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerManagedServiceIdentitiesContext() { }
        public static Azure.ResourceManager.ManagedServiceIdentities.AzureResourceManagerManagedServiceIdentitiesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class FederatedIdentityCredentialCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>, System.Collections.IEnumerable
    {
        protected FederatedIdentityCredentialCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string federatedIdentityCredentialResourceName, Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string federatedIdentityCredentialResourceName, Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string federatedIdentityCredentialResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string federatedIdentityCredentialResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> Get(string federatedIdentityCredentialResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> GetAll(int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> GetAllAsync(int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>> GetAsync(string federatedIdentityCredentialResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> GetIfExists(string federatedIdentityCredentialResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>> GetIfExistsAsync(string federatedIdentityCredentialResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FederatedIdentityCredentialData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>
    {
        public FederatedIdentityCredentialData() { }
        public System.Collections.Generic.IList<string> Audiences { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Issuer { get { throw null; } set { } }
        public System.Uri IssuerUri { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FederatedIdentityCredentialResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FederatedIdentityCredentialResource() { }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string federatedIdentityCredentialResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ManagedServiceIdentitiesExtensions
    {
        public static Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource GetFederatedIdentityCredentialResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource GetSystemAssignedIdentity(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource GetSystemAssignedIdentity(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource GetSystemAssignedIdentityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityCollection GetUserAssignedIdentities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> GetUserAssignedIdentities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> GetUserAssignedIdentitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> GetUserAssignedIdentity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> GetUserAssignedIdentityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource GetUserAssignedIdentityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SystemAssignedIdentityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>
    {
        public SystemAssignedIdentityData(Azure.Core.AzureLocation location) { }
        public System.Guid? ClientId { get { throw null; } }
        public System.Uri ClientSecretUri { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemAssignedIdentityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SystemAssignedIdentityResource() { }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedIdentityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>, System.Collections.IEnumerable
    {
        protected UserAssignedIdentityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UserAssignedIdentityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>
    {
        public UserAssignedIdentityData(Azure.Core.AzureLocation location) { }
        public System.Guid? ClientId { get { throw null; } }
        public Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope? IsolationScope { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedIdentityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserAssignedIdentityResource() { }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServiceIdentities.Models.IdentityAssociatedResourceData> GetAssociatedResources(string filter = null, string orderby = null, int? top = default(int?), int? skip = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServiceIdentities.Models.IdentityAssociatedResourceData> GetAssociatedResourcesAsync(string filter = null, string orderby = null, int? top = default(int?), int? skip = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource> GetFederatedIdentityCredential(string federatedIdentityCredentialResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource>> GetFederatedIdentityCredentialAsync(string federatedIdentityCredentialResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialCollection GetFederatedIdentityCredentials() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> Update(Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> UpdateAsync(Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedServiceIdentities.Mocking
{
    public partial class MockableManagedServiceIdentitiesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedServiceIdentitiesArmClient() { }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialResource GetFederatedIdentityCredentialResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource GetSystemAssignedIdentity(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource GetSystemAssignedIdentityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource GetUserAssignedIdentityResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableManagedServiceIdentitiesArmResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedServiceIdentitiesArmResource() { }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityResource GetSystemAssignedIdentity() { throw null; }
    }
    public partial class MockableManagedServiceIdentitiesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedServiceIdentitiesResourceGroupResource() { }
        public virtual Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityCollection GetUserAssignedIdentities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> GetUserAssignedIdentity(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource>> GetUserAssignedIdentityAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableManagedServiceIdentitiesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedServiceIdentitiesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> GetUserAssignedIdentities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityResource> GetUserAssignedIdentitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedServiceIdentities.Models
{
    public static partial class ArmManagedServiceIdentitiesModelFactory
    {
        public static Azure.ResourceManager.ManagedServiceIdentities.FederatedIdentityCredentialData FederatedIdentityCredentialData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Uri issuerUri = null, string subject = null, System.Collections.Generic.IEnumerable<string> audiences = null) { throw null; }
        public static Azure.ResourceManager.ManagedServiceIdentities.SystemAssignedIdentityData SystemAssignedIdentityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Guid? tenantId = default(System.Guid?), System.Guid? principalId = default(System.Guid?), System.Guid? clientId = default(System.Guid?), System.Uri clientSecretUri = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData UserAssignedIdentityData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Guid? tenantId, System.Guid? principalId, System.Guid? clientId) { throw null; }
        public static Azure.ResourceManager.ManagedServiceIdentities.UserAssignedIdentityData UserAssignedIdentityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Guid? tenantId = default(System.Guid?), System.Guid? principalId = default(System.Guid?), System.Guid? clientId = default(System.Guid?), Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope? isolationScope = default(Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch UserAssignedIdentityPatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Guid? tenantId, System.Guid? principalId, System.Guid? clientId) { throw null; }
        public static Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch UserAssignedIdentityPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Guid? tenantId = default(System.Guid?), System.Guid? principalId = default(System.Guid?), System.Guid? clientId = default(System.Guid?), Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope? isolationScope = default(Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope?)) { throw null; }
    }
    public partial class IdentityAssociatedResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal IdentityAssociatedResourceData() { }
        public string ResourceGroup { get { throw null; } }
        public string SubscriptionDisplayName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsolationScope : System.IEquatable<Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsolationScope(string value) { throw null; }
        public static Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope None { get { throw null; } }
        public static Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope left, Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope left, Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAssignedIdentityPatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch>
    {
        public UserAssignedIdentityPatch(Azure.Core.AzureLocation location) { }
        public System.Guid? ClientId { get { throw null; } }
        public Azure.ResourceManager.ManagedServiceIdentities.Models.IsolationScope? IsolationScope { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedServiceIdentities.Models.UserAssignedIdentityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
