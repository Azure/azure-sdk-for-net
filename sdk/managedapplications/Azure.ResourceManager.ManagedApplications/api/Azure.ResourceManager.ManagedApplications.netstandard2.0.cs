namespace Azure.ResourceManager.ManagedApplications
{
    public partial class ApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedApplications.ApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.ApplicationResource>, System.Collections.IEnumerable
    {
        protected ApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ManagedApplications.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.ManagedApplications.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedApplications.ApplicationResource>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedApplications.ApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedApplications.ApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedApplications.ApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.ApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationData>
    {
        public ApplicationData(string kind) { }
        public string ApplicationDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public string BillingDetailsResourceUsageId { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.Identity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode? ManagementMode { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls SupportUrls { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails UpdatedBy { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.ApplicationData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.ApplicationData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.ApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.ApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource>, System.Collections.IEnumerable
    {
        protected ApplicationDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationDefinitionName, Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationDefinitionName, Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> Get(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource>> GetAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> GetIfExists(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource>> GetIfExistsAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationDefinitionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>
    {
        public ApplicationDefinitionData(Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel lockLevel) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public System.BinaryData CreateUiDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.DeploymentMode? DeploymentMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy LockingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel LockLevel { get { throw null; } set { } }
        public System.BinaryData MainTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode? ManagementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint> NotificationEndpoints { get { throw null; } }
        public string PackageFileUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy> Policies { get { throw null; } }
        public string StorageAccountId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationDefinitionResource() { }
        public virtual Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName) { throw null; }
        Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationResource() { }
        public virtual Azure.ResourceManager.ManagedApplications.ApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult> GetAllowedUpgradePlans(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult>> GetAllowedUpgradePlansAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult> GetTokens(Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult>> GetTokensAsync(Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshPermissions(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshPermissionsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedApplications.ApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.ApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.ApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent> UpdateAccess(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent>> UpdateAccessAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerManagedApplicationsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerManagedApplicationsContext() { }
        public static Azure.ResourceManager.ManagedApplications.AzureResourceManagerManagedApplicationsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class JitRequestDefinitionCollection : Azure.ResourceManager.ArmCollection
    {
        protected JitRequestDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jitRequestName, Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jitRequestName, Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> Get(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> GetAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> GetIfExists(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> GetIfExistsAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JitRequestDefinitionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>
    {
        public JitRequestDefinitionData() { }
        public string ApplicationResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails CreatedBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies> JitAuthorizationPolicies { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.JitRequestState? JitRequestState { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy JitSchedulingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails UpdatedBy { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JitRequestDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JitRequestDefinitionResource() { }
        public virtual Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jitRequestName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> Update(Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> UpdateAsync(Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ManagedApplicationsExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource> CreateOrUpdateById(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.ManagedApplications.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource>> CreateOrUpdateByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.ManagedApplications.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation DeleteById(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetApplication(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource>> GetApplicationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource GetApplicationDefinition(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> GetApplicationDefinition(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource>> GetApplicationDefinitionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource GetApplicationDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.ApplicationDefinitionCollection GetApplicationDefinitions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> GetApplicationDefinitions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> GetApplicationDefinitionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.ApplicationResource GetApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.ApplicationCollection GetApplications(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetApplications(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetApplicationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetById(this Azure.ResourceManager.Resources.TenantResource tenantResource, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource>> GetByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult> GetByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>> GetByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult> GetBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>> GetBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> GetJitRequestDefinition(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> GetJitRequestDefinitionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource GetJitRequestDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.JitRequestDefinitionCollection GetJitRequestDefinitions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage> PortalRegistryPackage(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan registryPackagePlan, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage>> PortalRegistryPackageAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan registryPackagePlan, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource> UpdateById(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource>> UpdateByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedApplications.Mocking
{
    public partial class MockableManagedApplicationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedApplicationsArmClient() { }
        public virtual Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource GetApplicationDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedApplications.ApplicationResource GetApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource GetJitRequestDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableManagedApplicationsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedApplicationsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource>> GetApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource GetApplicationDefinition() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> GetApplicationDefinition(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource>> GetApplicationDefinitionAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedApplications.ApplicationDefinitionCollection GetApplicationDefinitions() { throw null; }
        public virtual Azure.ResourceManager.ManagedApplications.ApplicationCollection GetApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult> GetByResourceGroup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>> GetByResourceGroupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource> GetJitRequestDefinition(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionResource>> GetJitRequestDefinitionAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedApplications.JitRequestDefinitionCollection GetJitRequestDefinitions() { throw null; }
    }
    public partial class MockableManagedApplicationsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedApplicationsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> GetApplicationDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedApplications.ApplicationDefinitionResource> GetApplicationDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetApplications(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetApplicationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult> GetBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>> GetBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableManagedApplicationsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedApplicationsTenantResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource> CreateOrUpdateById(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.ManagedApplications.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource>> CreateOrUpdateByIdAsync(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.ManagedApplications.ApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteById(Azure.WaitUntil waitUntil, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteByIdAsync(Azure.WaitUntil waitUntil, string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource> GetById(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.ApplicationResource>> GetByIdAsync(string applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage> PortalRegistryPackage(Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan registryPackagePlan, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage>> PortalRegistryPackageAsync(Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan registryPackagePlan, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource> UpdateById(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedApplications.ApplicationResource>> UpdateByIdAsync(Azure.WaitUntil waitUntil, string applicationId, Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedApplications.Models
{
    public partial class AllowedUpgradePlansResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult>
    {
        internal AllowedUpgradePlansResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationArtifact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact>
    {
        internal ApplicationArtifact() { }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName Name { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactType Type { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationArtifactName : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationArtifactName(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName Authorizations { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName CustomRoleDefinition { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName ViewDefinition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName left, Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName left, Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ApplicationArtifactType
    {
        NotSpecified = 0,
        Template = 1,
        Custom = 2,
    }
    public partial class ApplicationAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization>
    {
        public ApplicationAuthorization(string principalId, string roleDefinitionId) { }
        public string PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationClientDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails>
    {
        internal ApplicationClientDetails() { }
        public string ApplicationId { get { throw null; } }
        public string Oid { get { throw null; } }
        public string Puid { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationDefinitionArtifact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact>
    {
        public ApplicationDefinitionArtifact(Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName name, string uri, Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactType type) { }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName Name { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationDefinitionArtifactName : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationDefinitionArtifactName(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName ApplicationResourceTemplate { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName CreateUiDefinition { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName MainTemplateParameters { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName left, Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName left, Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationDefinitionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch>
    {
        public ApplicationDefinitionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationJitAccessPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy>
    {
        public ApplicationJitAccessPolicy(bool jitAccessEnabled) { }
        public bool JitAccessEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode? JitApprovalMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedApplications.Models.JitApprover> JitApprovers { get { throw null; } }
        public string MaximumJitAccessDuration { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationLockLevel : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationLockLevel(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel CanNotDelete { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel None { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel ReadOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel left, Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel left, Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationManagementMode : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationManagementMode(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode Managed { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode Unmanaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode left, Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode left, Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationNotificationEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint>
    {
        public ApplicationNotificationEndpoint(string uri) { }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationPackageContact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact>
    {
        internal ApplicationPackageContact() { }
        public string ContactName { get { throw null; } }
        public string Email { get { throw null; } }
        public string Phone { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationPackageLockingPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy>
    {
        public ApplicationPackageLockingPolicy() { }
        public System.Collections.Generic.IList<string> AllowedActions { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedDataActions { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationPackageSupportUrls : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls>
    {
        internal ApplicationPackageSupportUrls() { }
        public string GovernmentCloud { get { throw null; } }
        public string PublicAzure { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationPatch : Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch>
    {
        public ApplicationPatch() { }
        public string ApplicationDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public string BillingDetailsResourceUsageId { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.Identity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode? ManagementMode { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.PlanPatchable Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls SupportUrls { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails UpdatedBy { get { throw null; } }
        protected override Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy>
    {
        public ApplicationPolicy() { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmManagedApplicationsModelFactory
    {
        public static Azure.ResourceManager.ManagedApplications.Models.AllowedUpgradePlansResult AllowedUpgradePlansResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan> value = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact ApplicationArtifact(Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName name = default(Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactName), string uri = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactType type = Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactType.NotSpecified) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization ApplicationAuthorization(string principalId = null, string roleDefinitionId = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails ApplicationClientDetails(string oid = null, string puid = null, string applicationId = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.ApplicationData ApplicationData(string managedResourceGroupId = null, string applicationDefinitionId = null, System.BinaryData parameters = null, System.BinaryData outputs = null, Azure.ResourceManager.ManagedApplications.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedApplications.Models.ProvisioningState?), Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy jitAccessPolicy = null, string publisherTenantId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization> authorizations = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode? managementMode = default(Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode?), Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact customerSupport = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls supportUrls = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact> artifacts = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails createdBy = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails updatedBy = null, string billingDetailsResourceUsageId = null, Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan plan = null, string kind = null, Azure.ResourceManager.ManagedApplications.Models.Identity identity = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact ApplicationDefinitionArtifact(Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName name = default(Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifactName), string uri = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactType type = Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifactType.NotSpecified) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.ApplicationDefinitionData ApplicationDefinitionData(Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel lockLevel = default(Azure.ResourceManager.ManagedApplications.Models.ApplicationLockLevel), string displayName = null, bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization> authorizations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionArtifact> artifacts = null, string description = null, string packageFileUri = null, string storageAccountId = null, System.BinaryData mainTemplate = null, System.BinaryData createUiDefinition = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy lockingPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy> policies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint> notificationEndpoints = null, Azure.ResourceManager.ManagedApplications.Models.DeploymentMode? deploymentMode = default(Azure.ResourceManager.ManagedApplications.Models.DeploymentMode?), Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode? managementMode = default(Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode?)) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationDefinitionPatch ApplicationDefinitionPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy ApplicationJitAccessPolicy(bool jitAccessEnabled = false, Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode? jitApprovalMode = default(Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.JitApprover> jitApprovers = null, string maximumJitAccessDuration = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationNotificationEndpoint ApplicationNotificationEndpoint(string uri = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact ApplicationPackageContact(string contactName = null, string email = null, string phone = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageLockingPolicy ApplicationPackageLockingPolicy(System.Collections.Generic.IEnumerable<string> allowedActions = null, System.Collections.Generic.IEnumerable<string> allowedDataActions = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls ApplicationPackageSupportUrls(string publicAzure = null, string governmentCloud = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationPatch ApplicationPatch(string id = null, string name = null, string type = null, string location = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.SystemData systemData = null, string managedBy = null, Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku sku = null, string managedResourceGroupId = null, string applicationDefinitionId = null, System.BinaryData parameters = null, System.BinaryData outputs = null, Azure.ResourceManager.ManagedApplications.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedApplications.Models.ProvisioningState?), Azure.ResourceManager.ManagedApplications.Models.ApplicationJitAccessPolicy jitAccessPolicy = null, string publisherTenantId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ApplicationAuthorization> authorizations = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode? managementMode = default(Azure.ResourceManager.ManagedApplications.Models.ApplicationManagementMode?), Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageContact customerSupport = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationPackageSupportUrls supportUrls = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ApplicationArtifact> artifacts = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails createdBy = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails updatedBy = null, string billingDetailsResourceUsageId = null, Azure.ResourceManager.ManagedApplications.Models.PlanPatchable plan = null, string kind = null, Azure.ResourceManager.ManagedApplications.Models.Identity identity = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ApplicationPolicy ApplicationPolicy(string name = null, string policyDefinitionId = null, string parameters = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo GenericResourceInfo(string id = null, string name = null, string type = null, string location = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.SystemData systemData = null, string managedBy = null, Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku sku = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.Identity Identity(string principalId = null, string tenantId = null, Azure.ResourceManager.ManagedApplications.Models.ResourceIdentityType? type = default(Azure.ResourceManager.ManagedApplications.Models.ResourceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitApprover JitApprover(string id = null, Azure.ResourceManager.ManagedApplications.Models.JitApproverType? type = default(Azure.ResourceManager.ManagedApplications.Models.JitApproverType?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies JitAuthorizationPolicies(string principalId = null, string roleDefinitionId = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData JitRequestDefinitionData(string applicationResourceId = null, string publisherTenantId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies> jitAuthorizationPolicies = null, Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy jitSchedulingPolicy = null, Azure.ResourceManager.ManagedApplications.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedApplications.Models.ProvisioningState?), Azure.ResourceManager.ManagedApplications.Models.JitRequestState? jitRequestState = default(Azure.ResourceManager.ManagedApplications.Models.JitRequestState?), Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails createdBy = null, Azure.ResourceManager.ManagedApplications.Models.ApplicationClientDetails updatedBy = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult JitRequestDefinitionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch JitRequestDefinitionPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata JitRequestMetadata(string originRequestId = null, string requestorId = null, string tenantDisplayName = null, string subjectDisplayName = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy JitSchedulingPolicy(Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType type = default(Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType), System.TimeSpan duration = default(System.TimeSpan), System.DateTimeOffset startOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo ManagedApplicationResourceInfo(string id = null, string name = null, string type = null, string location = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent ManagedApplicationsListTokenRequestContent(string authorizationAudience = null, System.Collections.Generic.IEnumerable<string> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan ManagedApplicationsPlan(string name = null, string publisher = null, string product = null, string promotionCode = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku ManagedApplicationsSku(string name = null, string tier = null, string size = null, string family = null, string model = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken ManagedIdentityToken(string accessToken = null, string expiresIn = null, string expiresOn = null, string notBefore = null, string authorizationAudience = null, string resourceId = null, string tokenType = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult ManagedIdentityTokenResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken> value = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.PlanPatchable PlanPatchable(string name = null, string publisher = null, string product = null, string promotionCode = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.RegistryPackage RegistryPackage(string publisher = null, string offer = null, string plan = null, string version = null, Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks packageLinks = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks RegistryPackageLinks(string createUiDefinitionLink = null, string deploymentTemplateLink = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan RegistryPackagePlan(string publisher = null, string offer = null, string plan = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent UpdateAccessContent(string approver = null, Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata metadata = null, Azure.ResourceManager.ManagedApplications.Models.Status status = default(Azure.ResourceManager.ManagedApplications.Models.Status), Azure.ResourceManager.ManagedApplications.Models.Substatus subStatus = default(Azure.ResourceManager.ManagedApplications.Models.Substatus)) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity UserAssignedResourceIdentity(string principalId = null, string tenantId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentMode : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.DeploymentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentMode(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.DeploymentMode Complete { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.DeploymentMode Incremental { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.DeploymentMode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.DeploymentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.DeploymentMode left, Azure.ResourceManager.ManagedApplications.Models.DeploymentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.DeploymentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.DeploymentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.DeploymentMode left, Azure.ResourceManager.ManagedApplications.Models.DeploymentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenericResourceInfo : Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo>
    {
        public GenericResourceInfo() { }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku Sku { get { throw null; } set { } }
        protected override Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.GenericResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Identity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.Identity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.Identity>
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.Identity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.Identity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.Identity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.Identity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.Identity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.Identity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.Identity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.Identity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.Identity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitApprovalMode : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitApprovalMode(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode AutoApprove { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode ManualApprove { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode left, Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode left, Azure.ResourceManager.ManagedApplications.Models.JitApprovalMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JitApprover : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitApprover>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitApprover>
    {
        public JitApprover(string id) { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.JitApproverType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitApprover JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitApprover PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.JitApprover System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitApprover>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitApprover>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.JitApprover System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitApprover>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitApprover>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitApprover>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitApproverType : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.JitApproverType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitApproverType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitApproverType Group { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitApproverType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.JitApproverType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.JitApproverType left, Azure.ResourceManager.ManagedApplications.Models.JitApproverType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.JitApproverType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.JitApproverType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.JitApproverType left, Azure.ResourceManager.ManagedApplications.Models.JitApproverType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JitAuthorizationPolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies>
    {
        public JitAuthorizationPolicies(string principalId, string roleDefinitionId) { }
        public string PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitAuthorizationPolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JitRequestDefinitionListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>
    {
        internal JitRequestDefinitionListResult() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedApplications.JitRequestDefinitionData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JitRequestDefinitionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch>
    {
        public JitRequestDefinitionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestDefinitionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JitRequestMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata>
    {
        public JitRequestMetadata() { }
        public string OriginRequestId { get { throw null; } set { } }
        public string RequestorId { get { throw null; } set { } }
        public string SubjectDisplayName { get { throw null; } set { } }
        public string TenantDisplayName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitRequestState : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.JitRequestState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitRequestState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestState Approved { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestState Denied { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestState Expired { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestState Pending { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitRequestState Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.JitRequestState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.JitRequestState left, Azure.ResourceManager.ManagedApplications.Models.JitRequestState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.JitRequestState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.JitRequestState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.JitRequestState left, Azure.ResourceManager.ManagedApplications.Models.JitRequestState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JitSchedulingPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy>
    {
        public JitSchedulingPolicy(Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType type, System.TimeSpan duration, System.DateTimeOffset startOn) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.JitSchedulingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitSchedulingType : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitSchedulingType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType Once { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType Recurring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType left, Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType left, Azure.ResourceManager.ManagedApplications.Models.JitSchedulingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedApplicationResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo>
    {
        public ManagedApplicationResourceInfo() { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedApplicationsListTokenRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent>
    {
        public ManagedApplicationsListTokenRequestContent() { }
        public string AuthorizationAudience { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsListTokenRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedApplicationsPlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan>
    {
        public ManagedApplicationsPlan(string name, string publisher, string product, string version) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsPlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedApplicationsSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku>
    {
        public ManagedApplicationsSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedApplicationsSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedIdentityToken : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken>
    {
        internal ManagedIdentityToken() { }
        public string AccessToken { get { throw null; } }
        public string AuthorizationAudience { get { throw null; } }
        public string ExpiresIn { get { throw null; } }
        public string ExpiresOn { get { throw null; } }
        public string NotBefore { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string TokenType { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedIdentityTokenResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult>
    {
        internal ManagedIdentityTokenResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityToken> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.ManagedIdentityTokenResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlanPatchable : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.PlanPatchable>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.PlanPatchable>
    {
        public PlanPatchable() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.PlanPatchable JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.PlanPatchable PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.PlanPatchable System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.PlanPatchable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.PlanPatchable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.PlanPatchable System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.PlanPatchable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.PlanPatchable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.PlanPatchable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.ProvisioningState left, Azure.ResourceManager.ManagedApplications.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.ProvisioningState left, Azure.ResourceManager.ManagedApplications.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistryPackage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage>
    {
        internal RegistryPackage() { }
        public string Offer { get { throw null; } }
        public Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks PackageLinks { get { throw null; } }
        public string Plan { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.RegistryPackage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.RegistryPackage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.RegistryPackage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.RegistryPackage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistryPackageLinks : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks>
    {
        internal RegistryPackageLinks() { }
        public string CreateUiDefinitionLink { get { throw null; } }
        public string DeploymentTemplateLink { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackageLinks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistryPackagePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan>
    {
        public RegistryPackagePlan(string publisher, string offer, string plan) { }
        public string Offer { get { throw null; } }
        public string Plan { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.RegistryPackagePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.Status Elevate { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.Status NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.Status Remove { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.Status other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.Status left, Azure.ResourceManager.ManagedApplications.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.Status (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.Status? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.Status left, Azure.ResourceManager.ManagedApplications.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Substatus : System.IEquatable<Azure.ResourceManager.ManagedApplications.Models.Substatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Substatus(string value) { throw null; }
        public static Azure.ResourceManager.ManagedApplications.Models.Substatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.Substatus Denied { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.Substatus Expired { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.Substatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.Substatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ManagedApplications.Models.Substatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedApplications.Models.Substatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedApplications.Models.Substatus left, Azure.ResourceManager.ManagedApplications.Models.Substatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.Substatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedApplications.Models.Substatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedApplications.Models.Substatus left, Azure.ResourceManager.ManagedApplications.Models.Substatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateAccessContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent>
    {
        public UpdateAccessContent(Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata metadata, Azure.ResourceManager.ManagedApplications.Models.Status status, Azure.ResourceManager.ManagedApplications.Models.Substatus subStatus) { }
        public string Approver { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.JitRequestMetadata Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.Status Status { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedApplications.Models.Substatus SubStatus { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.UpdateAccessContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedResourceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity>
    {
        public UserAssignedResourceIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedApplications.Models.UserAssignedResourceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
